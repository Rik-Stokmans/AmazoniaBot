using LogicLayer.Interfaces.DataServices;
using LogicLayer.Models.DataModels;

namespace MockDataLayer.Services;

public class ShopItemMockService : IShopItemService
{
    public Task<List<ShopItem>> GetAllShopItems()
    {
        return Task.FromResult(MockData.ShopItems);
    }
}