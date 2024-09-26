using LogicLayer.Models.DataModels;

namespace LogicLayer.Interfaces.DataServices;

public interface IShopItemService
{
    public Task<List<ShopItem>> GetAllShopItems();
}