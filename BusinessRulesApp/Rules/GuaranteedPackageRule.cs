using NRules.Fluent.Dsl;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessRulesApp.Rules
{
    public class GuaranteedPackageRule : Rule
    {
        public override void Define()
        {
            Employee employee = null;

            When()
                .Match<Employee>(() => employee, e => e.FB16 < e.FB01);

            Then()
                .Do(_ => Console.WriteLine($"Guaranteed Package may not be less than Basic Cash for employee {employee.EmployeeNumber} - FB16 ({employee.FB16}) < FB01 ({employee.FB01}) "));
        }
    }
}
