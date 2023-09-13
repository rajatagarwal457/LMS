using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LMS.Models;

namespace LMS.Data
{
    public interface ILoanCardProvider
    {
        Task<List<LoanCardMaster>> GetLoanCardsByEmployeeIdAsync(string employeeId);
    }
}
