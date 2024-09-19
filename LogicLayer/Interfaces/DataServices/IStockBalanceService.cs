using LogicLayer.Models.DataModels;

namespace LogicLayer.Interfaces.DataServices;

public interface IStockBalanceService
{
    public Task<DatabaseResult> ChangeStockBalance(ulong discordId, int companyId, int shareAmount);
    
    public Task<(DatabaseResult, StockBalance)> GetStockBalance(ulong discordId, int companyId);
    
    public Task<(DatabaseResult, List<StockBalance>)> GetStockBalances(ulong discordId);
    
    public Task<(DatabaseResult, List<StockBalance>)> GetStockBalances(int companyId);
}