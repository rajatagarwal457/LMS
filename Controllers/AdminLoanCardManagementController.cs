using LMS.Models;
using LMS.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminLoanCardManagementController : ControllerBase
    {
        private readonly IAdminLoanCardManagementService _service;

        public AdminLoanCardManagementController(IAdminLoanCardManagementService service)
        {
            _service = service;
        }
        [HttpPost]
        public async Task<ActionResult<LoanCardMaster>> AddLoanCardAsync(LoanCardMaster loanCard)
        {
            await _service.AddLoanCardAsync(loanCard);
            var _loanCard = await _service.GetLoanCardByIdAsync(loanCard.LoanId);
            if (_loanCard==null) 
            {
                return BadRequest(loanCard);
            }
            return Ok(_loanCard);
                   
        }
        [HttpGet]
        public async Task<ActionResult<List<LoanCardMaster>>> GetAllLoanCardsAsync()
        { 
            var _loancards = await _service.GetAllLoanCardsAsync();
            return Ok(_loancards);
        }
        [HttpPut("{loanId}")]
        public async Task<IActionResult> UpdateLoanCard(string loanId, LoanCardMaster updatedLoanCard)
        {
            try
            {
                await _service.UpdateLoanCardAsync(loanId, updatedLoanCard);
                return Ok($"Loan card with ID {loanId} updated successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("{loanId}")]
        public async Task<IActionResult> DeleteLoanCardAsync(string loanId)
        {
            await _service.DeleteLoanCardAsync(loanId);
            return NoContent();
        }
    }
}
