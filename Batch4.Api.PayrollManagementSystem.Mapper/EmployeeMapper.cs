using Batch4.Api.PayrollManagementSystem.DataAccess.Models;
using Batch4.Api.PayrollManagementSystem.Dtos.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Batch4.Api.PayrollManagementSystem.Mapper
{
    public static class EmployeeMapper
    {
        public static Employee? Change(this EmployeeRequestDTO employeeRequest)
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
