using LogicLayer.Interfaces;
using LogicLayer.Models;

namespace DataLayer.Services;

public class CompanyHistoryService : ICompanyHistoryService
{
    public (DatabaseResult, List<CompanyHistory>) GetCompanyHistory(int companyId)
    {
        throw new NotImplementedException();
    }

    public (DatabaseResult, List<CompanyHistory>) GetAllCompanyHistory()
    {
        throw new NotImplementedException();
    }

    public DatabaseResult CreateUpdateCompanyHistory(CompanyHistory companyHistory)
    {
        throw new NotImplementedException();
    }
}