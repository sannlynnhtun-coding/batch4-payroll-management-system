using Batch4.Api.PayrollManagementSystem.DataAccess.Db;
using Batch4.Api.PayrollManagementSystem.DataAccess.Models;
using Batch4.Api.PayrollManagementSystem.Shared.Constants;
using Batch4.Api.PayrollManagementSystem.Shared.Exceptions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Batch4.Api.PayrollManagementSystem.DataAccess.Services
{
    public class EmployeeDataAccess
    {
        private readonly AppDbContext _appDbContext;

        public EmployeeDataAccess(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<List<Employee>> GetEmployees()
        {
            var employees = await _appDbContext.Employees.AsNoTracking().ToListAsync();
            return employees;
        }

        public async Task<Employee?> GetEmployeeById(int id)
        {
            var employee = await _appDbContext.Employees.AsNoTracking().FirstOrDefaultAsync(e => e.Id == id);
            return employee;
        }

        public async Task CreateEmployee(Employee employee)
        {
            await _appDbContext.Employees.AddAsync(employee);
            var result = await _appDbContext.SaveChangesAsync();
            if (result < 1)
            {
                throw new DBModifyException(EmployeeErrorMessages.CreateFail);
            }
        }

        public async Task UpdateEmployee(int id, Employee requestEmployee)
        {
            var existingEmployee = await GetExistingEmployee(id);
            existingEmployee!.HourlyRate = requestEmployee.HourlyRate;
            existingEmployee.HoursWork = requestEmployee.HoursWork;
            existingEmployee.Name = requestEmployee.Name;

            _appDbContext.Entry(existingEmployee).State = EntityState.Modified;
            _appDbContext.Employees.Update(existingEmployee);

            var result = await _appDbContext.SaveChangesAsync();
            if (result < 1)
            {
                throw new DBModifyException(EmployeeErrorMessages.UpdateFail);
            }
        }

        public async Task DeleteEmployee(int id)
        {
            var existingEmployee = await GetExistingEmployee(id);
            _appDbContext.Entry(existingEmployee!).State = EntityState.Deleted;
            _appDbContext.Employees.Remove(existingEmployee!);

            var result = await _appDbContext.SaveChangesAsync();
            if (result < 1)
            {
                throw new DBModifyException(EmployeeErrorMessages.DeleteFail);
            }
        }

        private async Task<Employee?> GetExistingEmployee(int id)
        {
            var existingEmployee = await GetEmployeeById(id) ?? throw new NotFoundException(EmployeeErrorMessages.NotFound);
            return existingEmployee;
        }
    }
}
