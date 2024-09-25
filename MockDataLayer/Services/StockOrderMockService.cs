using LogicLayer.Core;
using LogicLayer.Interfaces.DataServices;
using LogicLayer.Models.DataModels;

namespace MockDataLayer.Services;

public class StockOrderMockService : IStockOrderService
{
    public Task<DatabaseResult> RegisterStockOrder(StockOrder order)
    {
        MockData.StockOrders.Add(order);
        
        return Task.FromResult(DatabaseResult.Success);
    }

    public async Task<DatabaseResult> TryFulfillStockOrder(StockOrder order)
    {
        // Check if company exists
        if (!MockData.Companies.Exists(company => company.Id == order.companyId)) return await Task.FromResult(DatabaseResult.NotFound);
        
        //sets the query parameters
        var orderTypeQuery/*sell*/ = !order.buyType;
        var companyQuery = order.companyId;
        
        
        var stockOrders = MockData.StockOrders.Where(stockOrder => 
            stockOrder.buyType == orderTypeQuery && 
            stockOrder.companyId == companyQuery).ToList();
        
        // order the stock orders by price ascending for sell orders and descending for buy orders
        stockOrders = order.buyType ? 
            stockOrders.OrderBy(stockOrder => stockOrder.price).ToList() : 
            stockOrders.OrderByDescending(stockOrder => stockOrder.price).ToList();
        
        
        var shareAmountToFulFill = order.shareAmount;
        var shareAmountThatCanFullFill = order.shareAmount;
        
        var loopOrdersToRemove = new List<StockOrder>();
        
        if (order.buyType) stockOrders.ForEach(BuyAction);
        else stockOrders.ForEach(SellAction);
        
        loopOrdersToRemove.ForEach(orderToRemove => MockData.StockOrders.Remove(orderToRemove));

        if (shareAmountToFulFill <= 0) return await Task.FromResult(DatabaseResult.Success);
        
        var uniqueId = MockData.StockOrders.OrderByDescending(x => x.OrderId).FirstOrDefault()?.OrderId + 1 ?? 0;
            
        MockData.StockOrders.Add(new StockOrder(order.userId, order.companyId, shareAmountToFulFill, order.buyType, order.price, order.bankAccountId, uniqueId));

        return await Task.FromResult(DatabaseResult.Success);
        
        //TODO Polish this
        async void BuyAction(StockOrder loopOrder)
        {
            if (shareAmountThatCanFullFill <= 0) return;
            
            if (loopOrder.price > order.price) return;
            
            var balance = await Core.GetBalance(order.bankAccountId);
            
            var maxShareAmount = (int) ( balance / loopOrder.price);
            
            if (maxShareAmount < shareAmountThatCanFullFill) shareAmountThatCanFullFill = maxShareAmount;
            
            if (loopOrder.shareAmount > shareAmountThatCanFullFill)
            {
                var (_, sellerStockBalance) = await Core.GetStockBalance(loopOrder.userId, loopOrder.companyId);
                
                if (sellerStockBalance.ShareAmount < shareAmountThatCanFullFill) return;
                
                var stockTransferred = await Core.TransferStockBalance(loopOrder.userId, order.userId, loopOrder.companyId, shareAmountThatCanFullFill);
                var orderPayed = await Core.TransferBalance(order.userId, order.bankAccountId, loopOrder.bankAccountId, shareAmountThatCanFullFill * loopOrder.price);

                if (!orderPayed || !stockTransferred)
                {
                    Console.WriteLine("Failed to pay or transfer stock");
                    return;
                }
                
                shareAmountToFulFill -= shareAmountThatCanFullFill;
                shareAmountThatCanFullFill = 0;
            }
            else
            {
                var stockTransferred = await Core.TransferStockBalance(loopOrder.userId, order.userId, loopOrder.companyId, loopOrder.shareAmount);
                var orderPayed = await Core.TransferBalance(order.userId, order.bankAccountId, loopOrder.bankAccountId, loopOrder.shareAmount * loopOrder.price);
                
                
                if (!orderPayed || !stockTransferred)
                {
                    Console.WriteLine("Failed to pay or transfer stock");
                    return;
                }
                
                shareAmountThatCanFullFill -= loopOrder.shareAmount;
                shareAmountToFulFill -= loopOrder.shareAmount;
                
                loopOrdersToRemove.Add(loopOrder);
            }
        }
        
        async void SellAction(StockOrder loopOrder)
        {
            throw new NotImplementedException();
        }
    }

    public Task<(bool, List<StockOrder>)> GetStockOrders(ulong userId)
    {
        var stockOrders = MockData.StockOrders.Where(stockOrder => stockOrder.userId == userId).ToList();
        
        return Task.FromResult((true, stockOrders));
    }
}