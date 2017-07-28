using NRules.Fluent.Dsl;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessRulesApp.Rules
{
    public class BasicCashRule : Rule
    {
        public override void Define()
        {
            Employee employee = null;

            When()
                .Match<Employee>(() => employee, e => e.FB01 == 0);

            Then()
                .Do(_ => Console.WriteLine($"Basic Cash should not be 0 for employee {employee.EmployeeNumber} - FB01 =({employee.FB01})"));
        }
    }
}
