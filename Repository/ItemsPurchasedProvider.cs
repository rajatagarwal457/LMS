using LMS.Models;
using Microsoft.EntityFrameworkCore;

namespace LMS.Data
{
    public class ItemsPurchasedProvider : IItemsPurchasedProvider
    {
        private readonly LmsContext _context;
        public ItemsPurchasedProvider(LmsContext context) 
        {
            _context = context;
        }

        public async Task<List<ItemPurchaseDto>> GetItemPurchasedByEmployeeIdAsync(string employeeId)
        {
            //{0} is place holder employeeId goes into this
            string sqlQuery = @"
            SELECT e.issue_id as IssueId,i.item_description as ItemDescription,i.item_make as ItemMake,i.item_category as ItemCategory,i.item_valuation as ItemValuation
            FROM employee_issue_details e
            INNER JOIN item_master i ON e.item_id = i.item_id
            WHERE e.employee_id = {0}";

            // Use FromSqlRaw to execute the raw SQL query
            return await _context.ItemPurchaseDtos
                .FromSqlRaw(sqlQuery, employeeId)
                .ToListAsync();
        }
    }
}
