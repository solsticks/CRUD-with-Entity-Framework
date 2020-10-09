using System;
using EmployeeClassLibrary;

using System.Collections.Generic;
using System.Text;
using EmployeeContext;

namespace EmployeeClassLibrary.Operations
{
    class OperationsCrud
    {
        public static void Insert()
        {
            using (var ctx = new Context())
            {
                var stud = new Employees()
                {
                    FiratName = "Bill",
                    HireDate = DateTime.Now,
                    Salary = 30
                };
                ctx.Add(stud);
                ctx.SaveChanges();
            }
        }
    }
}
