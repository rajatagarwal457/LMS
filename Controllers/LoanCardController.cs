using LMS.Models;
using LMS.Services;
using LMS.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LMS.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoanCardController : ControllerBase
    {
        private readonly LoanCardProvider _loanCardProvider;

        public LoanCardController(LoanCardProvider loanCardProvider)
        {
            _loanCardProvider = loanCardProvider;
        }

        [HttpGet("employee/{employeeId}")]
        public async Task<ActionResult<List<LoanCardMaster>>> GetLoanCardsByEmployeeId(string employeeId)
        {
            var loanCards = await _loanCardProvider.GetLoanCardsByEmployeeIdAsync(employeeId);

            if (loanCards == null || loanCards.Count == 0)
            {
                return NotFound();
            }

            return Ok(loanCards);
        }
    }
}