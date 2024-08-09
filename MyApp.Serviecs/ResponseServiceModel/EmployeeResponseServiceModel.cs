using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Serviecs.ResponseServiceModel
{
    public class EmployeeResponseServiceModel
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public double MonthlySalary { get; set; }
    }
}
