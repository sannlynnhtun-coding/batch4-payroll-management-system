using Batch4.Api.PayrollManagementSystem.DataAccess.Models;
using Batch4.Api.PayrollManagementSystem.Shared.DTOs.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Batch4.Api.PayrollManagementSystem.Shared.Mapper
{
    public static class EmployeeMapper
    {
        public static Employee? ChangeToDBModel(this EmployeeRequestDTO employeeRequest)
        {
            if (employeeRequest is null)
            {
                return null;
            }

            return new Employee
            {
                HourlyRate = employeeRequest.HourlyRate,
                HoursWork = employeeRequest.HoursWork,
                Name = employeeRequest.Name
            };
        }
    }
}
