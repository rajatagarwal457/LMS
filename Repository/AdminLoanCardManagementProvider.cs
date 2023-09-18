using LMS.Models;
using Microsoft.EntityFrameworkCore;

namespace LMS.Data
{
    public class AdminLoanCardManagementProvider : IAdminLoanCardManagementProvider
    {
        private readonly LmsContext _context;

        public AdminLoanCardManagementProvider(LmsContext context)
        {
            _context = context;
        }
        public async Task<LoanCardMaster> GetLoanCardByIdAsync(string loanId)
        {
            return await _context.LoanCardMasters.FindAsync(loanId);
        }
        public async Task AddLoanCardAsync(LoanCardMaster loanCard)
        {
            _context.LoanCardMasters.Add(loanCard);
            await _context.SaveChangesAsync();
        }
        public async Task<List<LoanCardMaster>> GetAllLoanCardsAsync()
        {
            return await _context.LoanCardMasters.ToListAsync();
        }
        public async Task UpdateLoanCardAsync(LoanCardMaster loanCard)
        {
            _context.Entry(loanCard).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteLoanCardAsync(string loanId)
        {
            var _loancard = await _context.LoanCardMasters.FindAsync(loanId);
            if (_loancard != null) 
            {
                _context.LoanCardMasters.Remove(_loancard);
                await _context.SaveChangesAsync();
            }
        }
    }
}
