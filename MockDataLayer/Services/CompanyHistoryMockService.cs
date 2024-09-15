using LogicLayer.Interfaces.DataServices;
using LogicLayer.Models.DataModels;

namespace MockDataLayer.Services;

public class CompanyHistoryMockService : ICompanyHistoryService
{
    public Task<(DatabaseResult, List<CompanyHistory>)> GetCompanyHistory(int companyId)
    {
        var companies =  MockData.CompanyHistories.FindAll(ch => ch.CompanyId == companyId);
        
        return Task.FromResult(companies.Count == 0
            ? (DatabaseResult.NotFound, new List<CompanyHistory>())
            : (DatabaseResult.Success, companies));
    }

    public Task<(DatabaseResult, List<CompanyHistory>)> GetAllCompanyHistory()
    {
        return Task.FromResult((DatabaseResult.Success, MockData.CompanyHistories));
    }

    public Task<DatabaseResult> CreateUpdateCompanyHistory(CompanyHistory companyHistory)
    {
        var existingCompanyHistory = MockData.CompanyHistories.Find(ch => ch.CompanyId == companyHistory.CompanyId && ch.Date == companyHistory.Date);
        if (existingCompanyHistory != null)
        {
            existingCompanyHistory.Profit = companyHistory.Profit;
            existingCompanyHistory.DividendPerShare = companyHistory.DividendPerShare;
            return Task.FromResult(DatabaseResult.Success);
        }

        MockData.CompanyHistories.Add(companyHistory);
        return Task.FromResult(DatabaseResult.Success);
    }
}