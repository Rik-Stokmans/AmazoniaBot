using LogicLayer.Interfaces;
using LogicLayer.Models;

namespace DataLayer.Services;

public class CompanyService : ICompanyService
{
    public (DatabaseResult, Company) GetCompany(int id)
    {
        throw new NotImplementedException();
    }

    public (DatabaseResult, List<Company>) GetAllCompanies()
    {
        throw new NotImplementedException();
    }

    public DatabaseResult CreateUpdateCompany(Company company)
    {
        throw new NotImplementedException();
    }
}