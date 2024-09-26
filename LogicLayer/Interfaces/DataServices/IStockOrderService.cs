using LogicLayer.Models.DataModels;

namespace LogicLayer.Interfaces.DataServices;

public interface IStockOrderService
{
    
    
    public Task<DatabaseResult> RegisterStockOrder(StockOrder order);
    
    public Task<DatabaseResult> TryFulfillStockOrder(StockOrder order);
    
    public Task<(bool, List<StockOrder>)> GetStockOrders(ulong userId);
    
    public Task<bool> CancelStockOrder(ulong userId, int orderId);
}