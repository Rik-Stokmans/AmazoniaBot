using LogicLayer.Interfaces;
using LogicLayer.Models;

namespace MockDataLayer.Services;

public class StockBalanceMockService : IStockBalanceService
{
    public Task<(DatabaseResult, List<StockBalance>)> GetStockBalances(ulong discordId)
    {
        var stockBalances = MockData.StockBalances.FindAll(sb => sb.DiscordId == discordId);
        
        return Task.FromResult(stockBalances.Count == 0
            ? (DatabaseResult.NotFound, new List<StockBalance>())
            : (DatabaseResult.Success, stockBalances));
    }

    public Task<(DatabaseResult, List<StockBalance>)> GetAllStockBalances(int companyId)
    {
        var stockBalances = MockData.StockBalances.FindAll(sb => sb.CompanyId == companyId);
        
        return Task.FromResult(stockBalances.Count == 0
            ? (DatabaseResult.NotFound, new List<StockBalance>())
            : (DatabaseResult.Success, stockBalances));
    }

    public Task<(DatabaseResult, List<StockBalance>)> GetAllStockBalances()
    {
        return Task.FromResult((DatabaseResult.Success, MockData.StockBalances));
    }

    public Task<DatabaseResult> CreateUpdateStockBalance(StockBalance stockBalance)
    {
        var existingStockBalance = MockData.StockBalances.Find(sb => sb.DiscordId == stockBalance.DiscordId && sb.CompanyId == stockBalance.CompanyId);
        if (existingStockBalance != null)
        {
            existingStockBalance.ShareAmount = stockBalance.ShareAmount;
            return Task.FromResult(DatabaseResult.Success);
        }

        MockData.StockBalances.Add(stockBalance);
        return Task.FromResult(DatabaseResult.Success);
    }

    public Task<DatabaseResult> DeleteStockBalance(ulong discordId, int companyId)
    {
        var stockBalance = MockData.StockBalances.Find(sb => sb.DiscordId == discordId && sb.CompanyId == companyId);
        if (stockBalance == null)
        {
            return Task.FromResult(DatabaseResult.NotFound);
        }

        MockData.StockBalances.Remove(stockBalance);
        return Task.FromResult(DatabaseResult.Success);
    }
}