using Batch4.Api.PayrollManagementSystem.DataAccess.Db;
using Batch4.Api.PayrollManagementSystem.DataAccess.Models;
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

        public EmployeeDataAccess()
        {
            _appDbContext = new AppDbContext();
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

        public async Task<int> CreateEmployee(Employee employee)
        {
            await _appDbContext.Employees.AddAsync(employee);
            var result = await _appDbContext.SaveChangesAsync();
            return result;
        }
      
        public async Task<int> UpdateEmployee(int id, Employee requestEmployee)
        {
            var existingEmployee = await GetEmployeeById(id) ?? throw new Exception("Employee Not Found");

            existingEmployee.HourlyRate = requestEmployee.HourlyRate;
            existingEmployee.HoursWork = requestEmployee.HoursWork;
            existingEmployee.Name = requestEmployee.Name;

            _appDbContext.Entry(existingEmployee).State = EntityState.Modified;
            _appDbContext.Employees.Update(existingEmployee);

            var result = await _appDbContext.SaveChangesAsync();
            return result;
        }

        public async Task<int> DeleteEmployee(int id)
        {
            var existingEmployee = await GetEmployeeById(id) ?? throw new Exception("Employee Not Found");
            _appDbContext.Entry(existingEmployee).State = EntityState.Deleted;
            _appDbContext.Employees.Remove(existingEmployee);
            
            var result = await _appDbContext.SaveChangesAsync();
            return result;
        }
    }
}
