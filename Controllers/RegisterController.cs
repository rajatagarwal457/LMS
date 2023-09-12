﻿using LMS.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LMS.Data;
using LMS.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace LMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly LMSContext _db;

        public RegisterController(LMSContext db)
        {
            _db = db;
        }

        [HttpPost]
        public async Task<ActionResult> RegisterEmployee(EmployeeMaster e)
        {
            Debug.WriteLine(e);
            await _db.EmployeeCredentials.AddAsync(e.Employee);
            await _db.SaveChangesAsync();
            await _db.EmployeeMasters.AddAsync(e);
            await _db.SaveChangesAsync();
            return Ok();
        }
    }
}
