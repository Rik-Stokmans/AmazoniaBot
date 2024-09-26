using LogicLayer.Interfaces.DataServices;
using LogicLayer.Models.DataModels;

namespace MockDataLayer.Services;

public class StockBalanceMockService : IStockBalanceService
{
    public Task<DatabaseResult> ChangeStockBalance(ulong discordId, int companyId, int shareAmount)
    {
        var stockBalance = MockData.StockBalances.Find(x => x.DiscordId == discordId && x.CompanyId == companyId);
        
        if (stockBalance == null)
        {
            if (shareAmount <= 0) return Task.FromResult(DatabaseResult.Fail);
            
            MockData.StockBalances.Add(new StockBalance(discordId, companyId, shareAmount));
            return Task.FromResult(DatabaseResult.Success);
        }
        
        if (stockBalance.ShareAmount + shareAmount < 0) return Task.FromResult(DatabaseResult.Fail);
        
        stockBalance.ShareAmount += shareAmount;
        return Task.FromResult(DatabaseResult.Success);

    }

    public Task<(DatabaseResult, StockBalance)> GetStockBalance(ulong discordId, int companyId)
    {
        var stockBalance = MockData.StockBalances.Find(x => x.DiscordId == discordId && x.CompanyId == companyId);
        return stockBalance == null 
            ? Task.FromResult((DatabaseResult.Fail, new StockBalance(0, 0, 0))) 
            : Task.FromResult((DatabaseResult.Success, stockBalance));
    }

    public Task<(DatabaseResult, List<StockBalance>)> GetStockBalances(ulong discordId)
    {
        var stockBalances = MockData.StockBalances.FindAll(x => x.DiscordId == discordId);
        
        return Task.FromResult((DatabaseResult.Success, stockBalances));
    }
    
    public Task<(DatabaseResult, List<StockBalance>)> GetStockBalances(int companyId)
    {
        var stockBalances = MockData.StockBalances.FindAll(x => x.CompanyId == companyId);
        
        return Task.FromResult((DatabaseResult.Success, stockBalances));
    }

    public Task<DatabaseResult> TransferStockBalance(ulong fromDiscordId, ulong toDiscordId, int companyId, int shareAmount)
    {
        var fromStockBalance = MockData.StockBalances.Find(x => x.DiscordId == fromDiscordId && x.CompanyId == companyId);
        var toStockBalance = MockData.StockBalances.Find(x => x.DiscordId == toDiscordId && x.CompanyId == companyId);
        
        if (fromStockBalance == null || toStockBalance == null) return Task.FromResult(DatabaseResult.Fail);
        
        if (fromStockBalance.ShareAmount - shareAmount < 0) return Task.FromResult(DatabaseResult.Fail);
        
        fromStockBalance.ShareAmount -= shareAmount;
        toStockBalance.ShareAmount += shareAmount;
        
        return Task.FromResult(DatabaseResult.Success);
    }
}