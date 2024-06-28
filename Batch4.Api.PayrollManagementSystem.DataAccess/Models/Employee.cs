using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Batch4.Api.PayrollManagementSystem.DataAccess.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal HourlyRate { get; set; }
        public decimal HoursWork { get; set; }
    }
}
