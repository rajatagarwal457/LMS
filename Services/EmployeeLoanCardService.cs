using System.Collections.Generic;
using System.Threading.Tasks;
using LMS.Models;
using LMS.Data;

namespace LMS.Services
{
    public class EmployeeLoanCardService : IEmployeeLoanCardService
    {
        private readonly LoanCardProvider _loanCardProvider;

        public EmployeeLoanCardService(LoanCardProvider loanCardProvider)
        {
            _loanCardProvider = loanCardProvider;
        }

        public async Task<List<LoanCardMaster>> GetLoanCardsByEmployeeIdAsync(string employeeId)
        {
            return await _loanCardProvider.GetLoanCardsByEmployeeIdAsync(employeeId);
        }
    }
}