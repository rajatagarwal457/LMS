﻿using LMS.Models;
using LMS.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeApplyForLoanController : ControllerBase
    {
        private readonly IApplyForLoanService _service;
        public EmployeeApplyForLoanController(IApplyForLoanService service) 
        {
            _service = service;
        }
        [HttpPost("ApplyForLoan")]
        public async Task<IActionResult> ApplyLoanAsync(LoanApplicationDto application,string employeeId)
        {
            try 
            {
                var _requestId =await _service.ApplyForLoanAsync(application, employeeId);
                return Ok(_requestId);
            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }
            
        }
    }
}
