using EmployeeClassLibrary;
using System;
using System.Collections.Generic;
using System.Text;

namespace Operations.Operations
{
   public class deptandemployanon
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Department department { get; set; }
        public deptandemployanon(string FirstName, string LastName, Department department)
        {
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.department = department;
        }
    }
}
