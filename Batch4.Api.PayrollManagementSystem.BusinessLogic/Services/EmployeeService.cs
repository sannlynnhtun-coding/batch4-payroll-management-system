using Batch4.Api.PayrollManagementSystem.DataAccess.Models;
using Batch4.Api.PayrollManagementSystem.DataAccess.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Batch4.Api.PayrollManagementSystem.BusinessLogic.Services
{
    public class EmployeeService
    {
        private readonly EmployeeDataAccess _employeeDA;

        public EmployeeService(EmployeeDataAccess employeeDataAccess)
        {
            _employeeDA = employeeDataAccess;
        }

        public async Task<List<Employee>> GetEmployees()
        {
            var employees = await _employeeDA.GetEmployees();
            return employees;
        }

        public async Task<Employee?> GetbyEmployeeId(int id)
        {
            var employee = await _employeeDA.GetEmployeeById(id);
            return employee;
        }

        public async Task<int> CreateEmployee(Employee requestModel)
        {
            var result = await _employeeDA.CreateEmployee(requestModel);
            return result;
        }

        public async Task<int> UpdateEmployee(int id, Employee requestModel)
        {
            var result = await _employeeDA.UpdateEmployee(id, requestModel);
            return result;
        }

        public async Task<int> DeleteEmployee(int id)
        {
            var result = await _employeeDA.DeleteEmployee(id);
            return result;
        }
    }
}
