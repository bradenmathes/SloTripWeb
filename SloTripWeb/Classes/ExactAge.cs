using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SloTripWeb
{
    static public class ExactAge
    {
        static public int GetAge(Employee employee)
        {
            int ageTS = DateTime.Now.Year - employee.Birthday.Year;
            DateTime ThisYearBD = employee.Birthday.AddYears(ageTS);
            if (ThisYearBD > DateTime.Now) return ageTS - 1;
            return ageTS;
        }
    }
}