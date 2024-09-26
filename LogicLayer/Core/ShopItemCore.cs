using LogicLayer.Interfaces.DataServices;
using LogicLayer.Models.DataModels;

namespace LogicLayer.Core;

public partial class Core
{
    // ReSharper disable once NullableWarningSuppressionIsUsed
    private static IShopItemService _shopItemService = null!;
    
    public static async Task<List<ShopItem>> GetAllShopItems()
    {
        CheckInit();
        
        var shopItems = await _shopItemService.GetAllShopItems();
        
        return shopItems;
    }
}