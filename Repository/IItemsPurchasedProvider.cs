using LMS.Models;

namespace LMS.Data
{
    public interface IItemsPurchasedProvider
    {
        Task<List<ItemPurchaseDto>> GetItemPurchasedByEmployeeIdAsync(string employeeId);
    }
}
