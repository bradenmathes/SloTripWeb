using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SloTripWeb
{
    public class EmployeeService
    {
        public bool AssignJobToEmployee(Employee employee, Job job)
        {
            if (ExactAge.GetAge(employee) >= job.MinimumAge) return true;
            return false;
        }
        public bool IsEmployee18(Employee employee)
        {
            if (ExactAge.GetAge(employee) < 18)
            {
                return false;
            }

            return true;
        }

        public Manager GetManager(int ID)
        {
            Manager manager = new Manager();
            return manager;
        }

    }
}
