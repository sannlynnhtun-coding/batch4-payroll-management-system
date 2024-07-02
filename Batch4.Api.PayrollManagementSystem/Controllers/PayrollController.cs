using Batch4.Api.PayrollManagementSystem.BusinessLogic.Services;
using Batch4.Api.PayrollManagementSystem.DataAccess.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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

        [HttpGet]
        public async Task<IActionResult> Read()
        {
            var list =await _payrollService.GetEmployees();
            return Ok(list);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Employee employee)
        {
            var result =await _payrollService.CreateEmployee(employee);
            string message = result > 0 ? "Create Successful" : "Create Failed";
            return Ok(message);
        }



    }
}
