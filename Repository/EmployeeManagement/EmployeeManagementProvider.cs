using LMS.Models;
using Microsoft.EntityFrameworkCore;

namespace LMS.Repository
{
    public class EmployeeManagementProvider : IEmployeeManagementProvider
    {
        private readonly Lms3Context _context;
        public EmployeeManagementProvider(Lms3Context context)
        {
            _context = context;
        }

        public async Task<List<ItemPurchaseDto>> GetItemPurchasedByEmployeeIdAsync(string employeeId)
        {
            Guid convEmployeeId;
            if (!Guid.TryParse(employeeId, out convEmployeeId))
            {
                // Handle invalid employeeId here
                return new List<ItemPurchaseDto>();
            }

            var items = await _context.EmployeeIssueDetails
                .Include(e => e.Item)
                .Where(e => e.EmployeeId == convEmployeeId)
                .Select(e => new ItemPurchaseDto
                {
                    IssueId = e.IssueId,
                    ItemDescription = e.Item.ItemDescription,
                    ItemMake = e.Item.ItemMake,
                    ItemCategory = e.Item.ItemCategory,
                    ItemValuation = e.Item.ItemValuation
                })
                .ToListAsync();

            return items;
        }
        public async Task<List<LoanCardMaster>> GetLoanCardsByEmployeeIdAsync(string employeeId)
        {
            // Query the database to retrieve loan card details for the given employee
            var loanCards = await _context.EmployeeCardDetails
                .Where(e => e.EmployeeId.ToString() == employeeId)
                .Select(e => e.Loan)
                .ToListAsync();

            return loanCards;
        }
    }
}
