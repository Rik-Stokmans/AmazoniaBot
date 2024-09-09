using LogicLayer.Interfaces;
using LogicLayer.Models;

namespace MockDataLayer.Services;

public class StockBalanceMockService : IStockBalanceService
{
    public (DatabaseResult, List<StockBalance>) GetStockBalances(ulong discordId)
    {
        var stockBalances = MockData.StockBalances.FindAll(sb => sb.DiscordId == discordId);
        
        return stockBalances.Count == 0
            ? (DatabaseResult.NotFound, new List<StockBalance>())
            : (DatabaseResult.Success, stockBalances);
    }

    public (DatabaseResult, List<StockBalance>) GetAllStockBalances(int companyId)
    {
        var stockBalances = MockData.StockBalances.FindAll(sb => sb.CompanyId == companyId);
        
        return stockBalances.Count == 0
            ? (DatabaseResult.NotFound, new List<StockBalance>())
            : (DatabaseResult.Success, stockBalances);
    }

    public (DatabaseResult, List<StockBalance>) GetAllStockBalances()
    {
        return (DatabaseResult.Success, MockData.StockBalances);
    }

    public DatabaseResult CreateUpdateStockBalance(StockBalance stockBalance)
    {
        var existingStockBalance = MockData.StockBalances.Find(sb => sb.DiscordId == stockBalance.DiscordId && sb.CompanyId == stockBalance.CompanyId);
        if (existingStockBalance != null)
        {
            existingStockBalance.ShareAmount = stockBalance.ShareAmount;
            return DatabaseResult.Success;
        }

        MockData.StockBalances.Add(stockBalance);
        return DatabaseResult.Success;
    }

    public DatabaseResult DeleteStockBalance(ulong discordId, int companyId)
    {
        var stockBalance = MockData.StockBalances.Find(sb => sb.DiscordId == discordId && sb.CompanyId == companyId);
        if (stockBalance == null)
        {
            return DatabaseResult.NotFound;
        }

        MockData.StockBalances.Remove(stockBalance);
        return DatabaseResult.Success;
    }
}