using Batch4.Api.PayrollManagementSystem.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Batch4.Api.PayrollManagementSystem.Dtos.Payrolls
{
    public class TotalPayrollResponse
    {
        public List<PayrollPerEmployee> PayrollPerEmployees { get; set; }
        public decimal TotalPayAmount { get; set; }
    }

    public class PayrollPerEmployee
    {
        public Employee Employee { get; set; }
        public decimal EmployeePay { get; set; }
    }
}
