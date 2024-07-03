using Batch4.Api.PayrollManagementSystem.DataAccess.Models;
using Batch4.Api.PayrollManagementSystem.DataAccess.Services;
using Batch4.Api.PayrollManagementSystem.Shared.Constants;
using Batch4.Api.PayrollManagementSystem.Shared.DTOs.Employees;
using Batch4.Api.PayrollManagementSystem.Shared.Exceptions;
using Batch4.Api.PayrollManagementSystem.Shared.Mapper;
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
            var employee = requestModel.ChangeToDBModel();
            var result = await _employeeDA.CreateEmployee(employee);
            if(result < 1)
            {
                throw new DBModifyException(EmployeeErrorMessages.CreateFail);
            }
        }

        public async Task UpdateEmployee(int id, EmployeeRequestDTO requestModel)
        {
            var requestEmployee = requestModel.ChangeToDBModel();
            var existingEmployee = await GetbyEmployeeId(id);
            var result = await _employeeDA.UpdateEmployee(id, requestEmployee, existingEmployee);
            if (result < 1)
            {
                throw new DBModifyException(EmployeeErrorMessages.UpdateFail);
            }
        }

        public async Task DeleteEmployee(int id)
        {
            var result = await _employeeDA.DeleteEmployee(id);
            if (result < 1)
            {
                throw new DBModifyException(EmployeeErrorMessages.DeleteFail);
            }
        }
    }
}
