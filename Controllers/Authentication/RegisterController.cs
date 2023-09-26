using LMS.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LMS.Data;
using LMS.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace LMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly IAuthService _authService;

        public RegisterController(IAuthService authService)
        {
            _authService=authService;
        }
        [AllowAnonymous]
        [HttpPost("RegisterEmployeeCredential")]
        public async Task<ActionResult> RegisterEmployeeCredential(EmployeeCredential employeeCredential)
        {
            await _authService.RegisterEmployeeCredential(employeeCredential);
            return Ok();
        /*var res = _authService.RegisterEmployee(e);
            if (res)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }*/


    }
    }
}

