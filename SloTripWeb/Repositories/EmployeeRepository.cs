using System;
using System.Collections.Generic;
using System.Data;

namespace SloTripWeb
{
    public class EmployeeRepository
    {
        public void SaveNew(Employee employee)
        {
            string fieldlist = "FirstName, MiddleName, LastName, Birthday";
            string valuelist = $"'{employee.FirstName}','{employee.MiddleName}','{employee.LastName}','{employee.Birthday.ToShortDateString()}'";
            string command = $"Insert Into Employee ({fieldlist}) Values ({valuelist})";
            DataBaseFunctions.ExecuteNonQuery(command);
        }
        public Employee Get(int EmployeeId)
        {
            string query = $"Select * From Employee Where ID = {EmployeeId}";
            DataTable result = DataBaseFunctions.GetDataTable(query);
            if (result.Rows.Count > 0)
            {
                DataRow row = result.Rows[0];
                Employee employee = new Employee()
                {
                    Id = Convert.ToInt32(row["ID"]),
                    FirstName = row["FirstName"].ToString(),
                    MiddleName = row["MiddleName"].ToString(),
                    LastName = row["LastName"].ToString(),
                    Birthday = Convert.ToDateTime(row["Birthday"])
                };
                return employee;
            }
            return null;
        }
        public List<Employee> GetAll()
        {
            string query = "Select * From Employee";
            DataTable result = DataBaseFunctions.GetDataTable(query);
            if (result.Rows.Count > 0)
            {
                List<Employee> employees = new List<Employee>();
                foreach (DataRow row in result.Rows)
                {
                    Employee employee = new Employee()
                    {
                        Id = Convert.ToInt32(row["ID"]),
                        FirstName = row["FirstName"].ToString(),
                        MiddleName = row["MiddleName"].ToString(),
                        LastName = row["LastName"].ToString(),
                        Birthday = Convert.ToDateTime(row["Birthday"])
                    };
                    employees.Add(employee);
                }
                return employees;
            }
            return null;
        }
        public void Update(Employee employee)
        {
            //Write this code
            string fieldlist = "FirstName, MiddleName, LastName, Birthday";
            string valuelist = $"'{employee.FirstName}','{employee.MiddleName}','{employee.LastName}','{employee.Birthday.ToShortDateString()}'";
            string command = $"Update Employee ({fieldlist}) Values ({valuelist})";
            DataBaseFunctions.ExecuteNonQuery(command);
        }
        public void Delete(int EmployeeID)
        {
            //Write this code
            string command = $"Delete From Employee Where ID = {EmployeeID}";
            DataBaseFunctions.ExecuteNonQuery(command);
        }
    }
}
