using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.DirectoryServices.ActiveDirectory;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EmployeeClassLibrary;
using EmployeeContext;
using Microsoft.EntityFrameworkCore;
using Operations;

namespace EmployeesWebForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private static Context action = new Context();// this is clearing a global context field

        public static int ID = 0; // this is declaring a global employee Id field and initializing it to zero
        public static int DeptID { get; set; } // this is declaring a global depertmental Id 
        public static Department department { get; set; } // this is initializing  the department field

        private void button1_Click(object sender, EventArgs e)
        {
            //CUDOperations.Insert();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //comboBox1.DataSource = CUDOperations.AddDept(new Department {DepartmentName = "", });
           // CUDOperations.AddDept(new Department {DepartmentName = "", });
            dataGridView1.DataSource = CRUDperations.getAllEmp(); // on wform load this populates the form with data from the database
            
        }

        private void txtFirstName_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e) // on thsi click of the button a new row is created and populated with a new employee
        {
            // Department dept = new Department();
            CRUDperations.Add(
                new Employees
                {
                    FirstName = txtFirstName.Text,
                    LastName = txtLastName.Text,
                    Email = txtEmail.Text,
                    PhoneNumber = txtPhoneNumber.Text,
                    HireDate = dateTimePicker1.Value,
                    Salary = decimal.Parse(txtSalary.Text)
                }, 
                comboBox1.SelectedIndex + 1);

            dataGridView1.DataSource = CRUDperations.getAllEmp();
            // the following lines clear the text boxes after the program runs the add method
            txtFirstName.Clear();
            txtLastName.Clear();
            txtEmail.Clear();
            txtPhoneNumber.Clear();
            txtSalary.Clear();
        }

        private void updateEmployeeBtn_Click(object sender, EventArgs e)// on the click of the button the database values are updated with the new values
        {
            var dept = deptUpdateCombo.Text;

            CRUDperations.Update(
                new Employees
                {
                    Id = ID,
                    FirstName = txtUpdateFirstName.Text,
                    LastName = txtUpdateLastName.Text,
                    Email = txtUpdatEmail.Text,
                    PhoneNumber = txtUpdatePhoneNumber.Text,
                    Salary = decimal.Parse(txtUpdateSalary.Text)
                }, dept);

                txtUpdateFirstName.Clear();
                txtUpdateLastName.Clear();
                txtUpdatEmail.Clear();
                txtUpdatePhoneNumber.Clear();
                txtUpdateSalary.Clear();
                
            
            dataGridView1.DataSource = CRUDperations.getAllEmp();
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void cell_click(object sender, DataGridViewCellEventArgs e)// this captures all the values in the datagrid and stores them in the text boxes.
        {
            ID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value); //this stores the Id value on the click of the cell
            txtUpdateFirstName.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString(); 
            txtUpdateLastName.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            txtUpdatEmail.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            txtUpdatePhoneNumber.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();            
            deptUpdateCombo.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
            DeptID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[6].Value);
            txtUpdateSalary.Text = dataGridView1.SelectedRows[0].Cells[7].Value.ToString();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            CRUDperations.Delete(ID);
            dataGridView1.DataSource = CRUDperations.getAllEmp();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtUpdateDepartment_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void txtSearchBtn_Click(object sender, EventArgs e)
        {

        }

        private void txtSearchBox_SelectedIndexChanged(object sender, EventArgs e)// thsi method runs the search option in the drop down based on the linq query
        {
            var test = CRUDperations.getAllEmp();
            
            if (txtSearchBox.SelectedIndex == 0)
            {
                using (var emp = new Context())
                {
                    comboSearcrslt.DataSource = emp.Employees.Include(e => e.Department).
                                                 Select(e => new { e.FirstName, e.LastName, e.Department.DepartmentName }).ToList();   //emp.Employees.ToList();
                   
                }
            }
            else if (txtSearchBox.SelectedIndex == 1)
            {
                using (var emps = new Context())
                {
                    comboSearcrslt.DataSource = emps.Employees.Where(e => e.Salary > 150000).Select(e => new {e.FirstName, e.LastName, e.Salary }).ToList();
                }
            }
            else if (txtSearchBox.SelectedIndex == 2)
            {
                using (var empes = new Context())
                {
                    comboSearcrslt.DataSource = empes.Employees.OrderBy(e => e.Department.DepartmentName).Select(s => new { s.FirstName, s.LastName, s.Department.DepartmentName }).ToList();
                }
            }
        }
    }
}
