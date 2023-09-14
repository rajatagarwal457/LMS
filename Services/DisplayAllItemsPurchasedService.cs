using LMS.Data;
using LMS.Models;

namespace LMS.Services
{
    public class DisplayAllItemsPurchasedService : IDisplayAllItemsPurchasedService
    {
        private readonly ItemsPurchasedProvider _itemsPurchasedProvider;

        public DisplayAllItemsPurchasedService(ItemsPurchasedProvider itemsPurchasedProvider)
        {
            _itemsPurchasedProvider=itemsPurchasedProvider;
        }
        public async Task<List<ItemPurchaseDto>> DisplayItemPurchasedBYEmployeeIdAsync(string employeeId)
        { 
            var itemsPurchased = await _itemsPurchasedProvider.GetItemPurchasedByEmployeeIdAsync(employeeId);

               return itemsPurchased.ToList();
    

        }
    }
}
