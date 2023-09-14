using LMS.Models;

namespace LMS.Services
{
    public interface IDisplayAllItemsPurchasedService
    {
        Task<List<ItemPurchaseDto>> DisplayItemPurchasedBYEmployeeIdAsync(string employeeId);
    }
}
