using Batch4.Api.PayrollManagementSystem.BusinessLogic.Services;
using Batch4.Api.PayrollManagementSystem.DataAccess.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Update.Internal;

namespace Batch4.Api.PayrollManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PayrollController : ControllerBase
    {
        private readonly PayrollService _payrollService;
        public PayrollController()
        {
            _payrollService = new PayrollService();
        }

        [HttpGet("{employeeId}")]
        public async Task<IActionResult> CalculateEmployeePayById(int employeeId)
        {
            var payPerEmployee = await _payrollService.CalculateEmployeePayById(employeeId);
            return Ok(payPerEmployee);
        }

    }
}
