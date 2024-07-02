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

        public async Task<List<Employee>> GetEmployees()
        {
            var lst =await _employeeDA.GetEmployees();
            return lst;
        }

        public async Task<int> CreateEmployee(Employee requestModel)
        {
            var result =await _employeeDA.CreateEmployee(requestModel);
            return result;
        }

        public async Task<Employee?> GetbyEmployeeId(int id)
        {
            var item = await _employeeDA.GetEmployeeById(id);         
            return item;
        }

        public async Task<decimal> CalculatePayroll(int id, Employee requestEmployee)
        {
            var existingEmployeeByRate = await _employeeDA.GetEmployeeByRate(id) ?? throw new Exception("Employee Not Found");
            var existingEmployeeByHour = await _employeeDA.GetEmployeeByWork(id) ?? throw new Exception("Employee Not Found");
            var amt = requestEmployee.HourlyRate * existingEmployeeByHour.HoursWork;

            return amt;
        }
    }
}
