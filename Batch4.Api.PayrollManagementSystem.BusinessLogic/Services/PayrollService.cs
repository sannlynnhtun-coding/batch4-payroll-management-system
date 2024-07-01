using Batch4.Api.PayrollManagementSystem.DataAccess.Models;
using Batch4.Api.PayrollManagementSystem.DataAccess.Services;
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
