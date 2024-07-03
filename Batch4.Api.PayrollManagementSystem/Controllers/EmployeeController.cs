using Batch4.Api.PayrollManagementSystem.BusinessLogic.Services;
using Batch4.Api.PayrollManagementSystem.DataAccess.Models;
using Batch4.Api.PayrollManagementSystem.Shared.Constants;
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
            
            return Ok(employee);
        }

        [HttpPost]
        public async Task<IActionResult> Create(EmployeeRequestDTO requestEmployee)
        {
            await _employeeService.CreateEmployee(requestEmployee);
            return Ok(EmployeeApiResponseMessages.CreateSuccess);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, EmployeeRequestDTO requestEmployee)
        {
            await _employeeService.UpdateEmployee(id, requestEmployee);
            return Ok(EmployeeApiResponseMessages.UpdateSuccess);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _employeeService.DeleteEmployee(id);
            return Ok(EmployeeApiResponseMessages.DeleteSuccess);
        }
    }
}
