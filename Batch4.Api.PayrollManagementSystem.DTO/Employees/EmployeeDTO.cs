using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Batch4.Api.PayrollManagementSystem.Dtos.Employees
{

    public class EmployeeRequestDTO
    {
        public string Name { get; set; }
        public decimal HourlyRate { get; set; }
        public decimal HoursWork { get; set; }
    }
}
