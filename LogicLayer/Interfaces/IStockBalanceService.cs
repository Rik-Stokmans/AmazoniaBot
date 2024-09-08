using LogicLayer.Models;

namespace LogicLayer.Interfaces;

public interface IStockBalanceService
{
    public (DatabaseResult, List<StockBalance>) GetStockBalances(ulong discordId);
    
    public (DatabaseResult, List<StockBalance>) GetAllStockBalances(int companyId);
    
    public (DatabaseResult, List<StockBalance>) GetAllStockBalances();
    
    public DatabaseResult CreateUpdateStockBalance(StockBalance stockBalance);
    
    public DatabaseResult DeleteStockBalance(ulong discordId, int companyId);
}