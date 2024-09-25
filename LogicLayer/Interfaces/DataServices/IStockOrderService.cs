using LogicLayer.Models.DataModels;

namespace LogicLayer.Interfaces.DataServices;

public interface IStockOrderService
{
    
    
    public Task<DatabaseResult> RegisterStockOrder(StockOrder order);
    
    public Task<DatabaseResult> TryFulfillStockOrder(StockOrder order);
}