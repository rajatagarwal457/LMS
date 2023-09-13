using System.Collections.Generic;
using System.Threading.Tasks;
using LMS.Models;

namespace LMS.Services
{
    public interface IEmployeeLoanCardService
    {
        Task<List<LoanCardMaster>> GetLoanCardsByEmployeeIdAsync(string employeeId);
    }
}