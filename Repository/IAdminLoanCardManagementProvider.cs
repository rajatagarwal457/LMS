using LMS.Models;

namespace LMS.Data
{
    public interface IAdminLoanCardManagementProvider
    {
        Task<LoanCardMaster> GetLoanCardByIdAsync(string loanId);

        Task AddLoanCardAsync(LoanCardMaster loanCard);
        Task<List<LoanCardMaster>> GetAllLoanCardsAsync();
        Task UpdateLoanCardAsync(LoanCardMaster loanCard);
        Task DeleteLoanCardAsync(string loanId);
    }
}
