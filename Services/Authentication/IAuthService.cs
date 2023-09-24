﻿using LMS.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LMS.Services
{
    public interface IAuthService
    {
        public EmployeeCredential GetEmployeeDetail(EmployeeViewModel login);
        public Boolean RegisterEmployee(EmployeeMaster e);
        public string GenerateJSONWebToken(EmployeeCredential employeeInfo);
        public EmployeeCredential AuthenticateEmployee(EmployeeViewModel login);

        Task RegisterEmployeeCredential(EmployeeCredential employeeCredential);
        Task<EmployeeCredential> GetEmployeeByIdAsync(string employeeId);
    }
}