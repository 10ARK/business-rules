using BusinessRulesApp.Rules;
using NRules;
using NRules.Fluent;
using System;
using System.Reflection;

namespace BusinessRulesApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Initializing Rules Engine");

            // Load rules
            var repository = new RuleRepository();

            repository.Load(x => x.From(typeof(BasicCashRule).GetTypeInfo().Assembly));

            // Compile rules
            var factory = repository.Compile();

            // Create a working session
            var session = factory.CreateSession();

            // Load domain model
            var customer1 = new Employee() { ID = 1, EmployeeNumber = "E0001", JobCode = "A", JobTitle = "Accountant I", FB01 = 1000, FB16 = 1200 };
            var customer2 = new Employee() { ID = 1, EmployeeNumber = "E0002", JobCode = "B", JobTitle = "Accountant II", FB01 = 2000, FB16 = 1400 };
            var customer3 = new Employee() { ID = 1, EmployeeNumber = "E0003", JobCode = "C", JobTitle = "Junior Accountant I", FB01 = 0, FB16 = 1200 };
            var customer4 = new Employee() { ID = 1, EmployeeNumber = "E0004", JobCode = "D", JobTitle = "Junior Accountant II", FB01 = 0, FB16 = 1200 };
            var customer5 = new Employee() { ID = 1, EmployeeNumber = "E0005", JobCode = "E", JobTitle = "Mechanic I", FB01 = 1400, FB16 = 1200 };
            var customer6 = new Employee() { ID = 1, EmployeeNumber = "E0006", JobCode = "F", JobTitle = "Mechanic II", FB01 = 1600, FB16 = 1200 };
            var customer7 = new Employee() { ID = 1, EmployeeNumber = "E0007", JobCode = "G", JobTitle = "Plumber I", FB01 = 0, FB16 = 1200 };
            var customer8 = new Employee() { ID = 1, EmployeeNumber = "E0008", JobCode = "H", JobTitle = "Doctor I", FB01 = 0, FB16 = 1200 };
            var customer9 = new Employee() { ID = 1, EmployeeNumber = "E0009", JobCode = "I", JobTitle = "Surgeon I", FB01 = 1000, FB16 = 1200 };
            var customer10 = new Employee() { ID = 1, EmployeeNumber = "E0010", JobCode = "J", JobTitle = "Jaques I", FB01 = 1000, FB16 = 1200 };

            // Insert facts into rules engine's memory
            session.Insert(customer1);
            session.Insert(customer2);
            session.Insert(customer3);
            session.Insert(customer4);
            session.Insert(customer5);
            session.Insert(customer6);
            session.Insert(customer7);
            session.Insert(customer8);
            session.Insert(customer9);
            session.Insert(customer10);

            // Start match/resolve/act cycle
            session.Fire();

            Console.ReadLine();
        }
    }
}