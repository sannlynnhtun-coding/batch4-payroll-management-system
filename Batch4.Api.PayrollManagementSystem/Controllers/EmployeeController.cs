using Batch4.Api.PayrollManagementSystem.BusinessLogic.Services;
using Batch4.Api.PayrollManagementSystem.DataAccess.Models;
using Batch4.Api.PayrollManagementSystem.Shared.DTOs.Employees;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Batch4.Api.PayrollManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeService _employeeService;

        public EmployeeController(EmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEmployees()
        {
            var employees = await _employeeService.GetEmployees();
            return Ok(employees);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployeeById(int id)
        {
            var employee = await _employeeService.GetbyEmployeeId(id);
            if (employee is null)
            {
                return NotFound();
            }
            return Ok(employee);
        }

        [HttpPost]
        public async Task<IActionResult> Create(EmployeeRequestDTO requestEmployee)
        {
            var result = await _employeeService.CreateEmployee(requestEmployee);
            string message = result > 0 ? "Create Successful" : "Create Failed";
            return Ok(message);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, EmployeeRequestDTO requestEmployee)
        {
            var result = await _employeeService.UpdateEmployee(id, requestEmployee);
            string message = result > 0 ? "Update Successful" : "Update Failed";
            return Ok(message);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _employeeService.DeleteEmployee(id);
            string message = result > 0 ? "Delete Successful" : "Delete Failed";
            return Ok(message);
        }
    }
}
