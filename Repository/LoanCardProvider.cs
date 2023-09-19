using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LMS.Models; // Replace with your actual namespace

namespace LMS.Data
{
    public class LoanCardProvider
    {
        private readonly LmsContext _context;

        public LoanCardProvider(LmsContext context)
        {
            _context = context;
        }

        // Define a method to fetch loan card details of an employee by employee_id
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