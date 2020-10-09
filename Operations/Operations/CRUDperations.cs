using EmployeeClassLibrary;
using EmployeeContext;
using Microsoft.Data.SqlClient.Server;
using Microsoft.EntityFrameworkCore;
using Operations.Operations;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Operations
{
    public class CRUDperations
    {
        private static Context _context = new Context();
        public static List<string> getAll()
        {
            var dept = new List<string>();
            var list = new List<Department>();
            using (var dpx = new Context())
            {
                list = dpx.Departments.OrderBy(e => e.DepartmentName).ToList();
            }
            foreach (var item in list)
            {
                dept.Add(item.DepartmentName);
            }
            return dept;
        }

        public static IEnumerable getAllEmp()
        {
            //var dept = new List<string>();            
            return _context.Employees.Include(s => s.Department).Select(e => new {e.Id, e.FirstName, e.LastName, e.Email, e.PhoneNumber, e.Department.DepartmentName, e.Department.DepartmentId, e.Salary}).ToList();            
        }
        public static void Add(Employees employee, int dept)
        {
            //using ;
            using (var ctx = new Context())
            {
                var D = ctx.Departments.Find(dept);
                employee.Department = D;
                ctx.Employees.Add(employee);
                ctx.SaveChanges();
            }            
        }

        public static void AddDept(Department dept)
        {

            //using (var ctx = new Context())
            //{
            //    //var dpt = new Department
            //    //{
            //    //    DepartmentName = "HR"
            //    //};
            //    //var dpta = new Department
            //    //{
            //    //    DepartmentName = "Finance"
            //    //};
            //    //var dpts = new Department
            //    //{
            //    //    DepartmentName = "Projects"
            //    //};
            //    //var dp = new Department
            //    //{
            //    //    DepartmentName = "Sales"
            //    //};

            //    //ctx.Departments.AddRange(dpt, dpta, dpts, dp );
            //   // ctx.SaveChanges();
            //}

                //ctx.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [dbo].[Employees] ON");
            
        }

        public static void Update(Employees employee, string department)
        {

            using (var but = new Context())
            {
                var de = but.Departments.Where(s =>s.DepartmentName == department).FirstOrDefault();
                employee.Department = de;
                but.Employees.Update(employee);
                but.SaveChanges();
            }
        }

        public static void Delete(int ID)
        {
            var employee = _context.Employees.Where(e => e.Id == ID).FirstOrDefault();
            using (var del = new Context())
            {
                //var employee = del.Employees.Where(e => e.Id == ID);
                del.Employees.Remove(employee);
                del.SaveChanges();
            }
        }


    }
}
