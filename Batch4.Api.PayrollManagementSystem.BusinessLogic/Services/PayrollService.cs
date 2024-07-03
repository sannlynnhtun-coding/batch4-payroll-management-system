using Batch4.Api.PayrollManagementSystem.DataAccess.Db;
using Batch4.Api.PayrollManagementSystem.DataAccess.Models;
using Batch4.Api.PayrollManagementSystem.DataAccess.Services;
using Batch4.Api.PayrollManagementSystem.Dtos.Payrolls;
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

        public async Task<TotalPayrollResponse> GenerateTotalPayAmount()
        {
            var employees = await _employeeDA.GetEmployees();

            var totalPay = employees.Sum(employee => employee.CalculatePay());
            var payrollPerEmployees = employees.Select(employee => new PayrollPerEmployee
            {
                Employee = employee,
                EmployeePay = employee.CalculatePay()
            }).ToList();

            return new TotalPayrollResponse
            {
                TotalPayAmount = totalPay,
                PayrollPerEmployees = payrollPerEmployees
            };
        }

        public async Task<PayrollPerEmployee> CalculateEmployeePayById(int employeeId)
        {
            var employee = await _employeeDA.GetEmployeeById(employeeId) ?? throw new Exception("Employee Not Found");

            return new PayrollPerEmployee()
            {
                Employee = employee,
                EmployeePay = employee.CalculatePay(),
            };
        }
    }
}
