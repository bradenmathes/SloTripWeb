using System.Collections.Generic;

namespace SloTripWeb
{
    public class Manager : Employee 
    {
        public List<Employee> employees { get; set; }
        public Manager()
        {
            employees = new List<Employee>();
        }

    }
}
