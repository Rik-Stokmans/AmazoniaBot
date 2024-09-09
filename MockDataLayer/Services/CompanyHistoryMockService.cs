using LogicLayer.Interfaces;
using LogicLayer.Models;

namespace MockDataLayer.Services;

public class CompanyHistoryMockService : ICompanyHistoryService
{
    public (DatabaseResult, List<CompanyHistory>) GetCompanyHistory(int companyId)
    {
        var companies =  MockData.CompanyHistories.FindAll(ch => ch.CompanyId == companyId);
        
        return companies.Count == 0
            ? (DatabaseResult.NotFound, new List<CompanyHistory>())
            : (DatabaseResult.Success, companies);
    }

    public (DatabaseResult, List<CompanyHistory>) GetAllCompanyHistory()
    {
        return (DatabaseResult.Success, MockData.CompanyHistories);
    }

    public DatabaseResult CreateUpdateCompanyHistory(CompanyHistory companyHistory)
    {
        var existingCompanyHistory = MockData.CompanyHistories.Find(ch => ch.CompanyId == companyHistory.CompanyId && ch.Date == companyHistory.Date);
        if (existingCompanyHistory != null)
        {
            existingCompanyHistory.Profit = companyHistory.Profit;
            existingCompanyHistory.DividendPerShare = companyHistory.DividendPerShare;
            return DatabaseResult.Success;
        }

        MockData.CompanyHistories.Add(companyHistory);
        return DatabaseResult.Success;
    }
}