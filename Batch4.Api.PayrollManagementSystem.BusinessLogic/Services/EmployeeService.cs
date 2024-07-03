using Batch4.Api.PayrollManagementSystem.DataAccess.Models;
using Batch4.Api.PayrollManagementSystem.DataAccess.Services;
using Batch4.Api.PayrollManagementSystem.Dtos.Employees;
using Batch4.Api.PayrollManagementSystem.Mapper;
using Batch4.Api.PayrollManagementSystem.Shared.Constants;
using Batch4.Api.PayrollManagementSystem.Shared.Exceptions;
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
            var employee = await _employeeDA.GetEmployeeById(id)?? throw new NotFoundException(EmployeeErrorMessages.NotFound);
            return employee;
        }

        public async Task CreateEmployee(EmployeeRequestDTO requestModel)
        {
            var employee = requestModel.Change();
            await _employeeDA.CreateEmployee(employee);
        }

        public async Task UpdateEmployee(int id, EmployeeRequestDTO requestModel)
        {
            var requestEmployee = requestModel.Change();
            await _employeeDA.UpdateEmployee(id, requestEmployee);

        }

        public async Task DeleteEmployee(int id)
        {
            await _employeeDA.DeleteEmployee(id);
        }
    }
}
