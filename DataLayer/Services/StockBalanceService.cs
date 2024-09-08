using LogicLayer.Interfaces;
using LogicLayer.Models;

namespace DataLayer.Services;

public class StockBalanceService : IStockBalanceService
{
    public (DatabaseResult, List<StockBalance>) GetStockBalances(ulong discordId)
    {
        throw new NotImplementedException();
    }

    public (DatabaseResult, List<StockBalance>) GetAllStockBalances(int companyId)
    {
        throw new NotImplementedException();
    }

    public (DatabaseResult, List<StockBalance>) GetAllStockBalances()
    {
        throw new NotImplementedException();
    }

    public DatabaseResult CreateUpdateStockBalance(StockBalance stockBalance)
    {
        throw new NotImplementedException();
    }

    public DatabaseResult DeleteStockBalance(ulong discordId, int companyId)
    {
        throw new NotImplementedException();
    }
}