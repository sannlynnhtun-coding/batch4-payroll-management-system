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
        public PayrollService(EmployeeDataAccess employeeDataAccess)
        {
            _employeeDA = employeeDataAccess;
        }

        public async Task<decimal?> CalculatePayroll(int id, Employee requestEmployee)
        {
            var existingEmployeeByRate = await _employeeDA.GetEmployeeByRate(id) ?? throw new Exception("Employee Not Found");
            var existingEmployeeByHour = await _employeeDA.GetEmployeeByWork(id) ?? throw new Exception("Employee Not Found");
            var amt = requestEmployee.HourlyRate * existingEmployeeByHour.HoursWork;
            return amt;
        }
    }
}
