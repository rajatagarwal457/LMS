using LMS.Models;
using LMS.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LMS.Controllers.ApplyLoanControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminLoanRequestListController : ControllerBase
    {
        private readonly IAdminLoanRequestService _service;
        public AdminLoanRequestListController(IAdminLoanRequestService service)
        {
            _service=service;
        }

        [HttpGet("WaitingList")]
        public async Task<IActionResult> GetPendingLoanRequestsListsAsync()
        {
            var pendingRequests = await _service.GetPendingLoanRequestsAsync();
            return Ok(pendingRequests);
        }

        [HttpPost("Approve")]
        public async Task<IActionResult> ApproveLoanRequestAsync(string requestId)
        {
            try
            {
                await _service.ApproveLoanRequestAsync(requestId);
                return Ok("Request Approved");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Decline")]
        public async Task<IActionResult> DeclineLoanRequestAsync(string requestId)
        {
            try
            {
                await _service.DeclineLoanRequestAsync(requestId);
                return Ok("Request Declined");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
