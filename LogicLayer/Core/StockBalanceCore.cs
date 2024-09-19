using LogicLayer.Interfaces.DataServices;
using LogicLayer.Models.DataModels;

namespace LogicLayer.Core;

public partial class Core
{
    private static IStockBalanceService _stockBalanceService = null!;

    public static async Task<bool> ChangeStockBalance(ulong discordId, int companyId, int shareAmount)
    {
        CheckInit();
        
        return await _stockBalanceService.ChangeStockBalance(discordId, companyId, shareAmount) == DatabaseResult.Success;
    }
    
    public static async Task<(bool, StockBalance)> GetStockBalance(ulong discordId, int companyId)
    {
        CheckInit();
        
        var (databaseResult, stockBalance) = await _stockBalanceService.GetStockBalance(discordId, companyId);
        
        
        return (databaseResult == DatabaseResult.Success, stockBalance);
    }
    
    public static async Task<(bool, List<StockBalance>)> GetStockBalances(ulong discordId)
    {
        CheckInit();
        
        var (databaseResult, stockBalances) = await _stockBalanceService.GetStockBalances(discordId);
        
        return (databaseResult == DatabaseResult.Success, stockBalances);
    }
    
    public static async Task<(bool, List<StockBalance>)> GetStockBalances(int companyId)
    {
        CheckInit();
        
        var (databaseResult, stockBalances) = await _stockBalanceService.GetStockBalances(companyId);
        
        return (databaseResult == DatabaseResult.Success, stockBalances);
    }
    
}