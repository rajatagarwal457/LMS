using LMS.Models;
using LMS.Services;
using LMS.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DisplayItemPurchaseByIdController : ControllerBase
    {
        private readonly IDisplayAllItemsPurchasedService _service;

        public DisplayItemPurchaseByIdController(IDisplayAllItemsPurchasedService service)
        {
            _service=service;
        }

        [HttpGet("{employeeId}")]
        public async Task<ActionResult<List<ItemPurchaseDto>>> DisplayAllItemsPurchasedById(string employeeId)
        {
            var itemsPurchased =await _service.DisplayItemPurchasedBYEmployeeIdAsync(employeeId);
            if (itemsPurchased == null || itemsPurchased.Count == 0)
            {
                return NotFound();
            }

            return Ok(itemsPurchased);
        }
    }
}
