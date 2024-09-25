using LogicLayer.Interfaces.DataServices;
using LogicLayer.Models.DataModels;

namespace LogicLayer.Core;

public partial class Core
{
    // ReSharper disable once NullableWarningSuppressionIsUsed
    private static IStockOrderService _stockOrderService = null!;
    private static readonly Queue<StockOrder> StockOrders = new();

    private const long TaxAddition = 1 * 100;

    private static bool _processing;

    public static async Task<bool> RegisterStockOrder(StockOrder order)
    {
        CheckInit();
        
        var balance = await GetBalance(order.bankAccountId);
        
        if (balance < order.price * order.shareAmount + TaxAddition) return false;
        
        var taxPayed = await Pay(order.bankAccountId, TaxAddition);
        
        if (!taxPayed) return false;
        
        StockOrders.Enqueue(order);

        if (_processing) return true;
        
        _processing = true;
        ProcessStockOrders();
        _processing = false;

        return true;
    }

    private static async void ProcessStockOrders()
    {
        while (StockOrders.Count > 0)
        {
            var order = StockOrders.Dequeue();

            var result = await _stockOrderService.TryFulfillStockOrder(order);

            if (result != DatabaseResult.Success)
            {
                await _stockOrderService.RegisterStockOrder(order);
            }
        }
    }
    
    public static async Task<(bool, List<StockOrder>)> GetStockOrders(ulong userId)
    {
        CheckInit();
        
        return await _stockOrderService.GetStockOrders(userId);
    }
}


























