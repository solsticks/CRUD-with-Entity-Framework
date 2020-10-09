using EmployeeClassLibrary;
using EmployeeContext;
using System;

namespace EmployeeConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            static void Insert()
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
}
