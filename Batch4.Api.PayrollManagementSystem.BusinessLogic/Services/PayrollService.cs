using Batch4.Api.PayrollManagementSystem.DataAccess.Db;
using Batch4.Api.PayrollManagementSystem.DataAccess.Models;
using Batch4.Api.PayrollManagementSystem.DataAccess.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Batch4.Api.PayrollManagementSystem.BusinessLogic.Services
{
    public class PayrollService
    {
        private readonly EmployeeDataAccess _employeeDA;
        public PayrollService()
        {
            _employeeDA = new EmployeeDataAccess();
        }

        public async Task<decimal> CalculateEmployeePayById(int employeeId)
        {
            var employee = await _employeeDA.GetEmployeeById(employeeId) ?? throw new Exception("Employee Not Found");
            return employee.CalculatePay();
        }
    }
}
