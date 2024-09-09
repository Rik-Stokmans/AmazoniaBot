using LogicLayer.Interfaces;
using LogicLayer.Models;

namespace MockDataLayer.Services;
public class CompanyService : ICompanyService
{
    public (DatabaseResult, Company) GetCompany(int id)
    {
        var company = MockData.Companies.Find(company => company.Id == id);
        
        return company == null
            ? (DatabaseResult.NotFound, new Company(0, "", 0))
            : (DatabaseResult.Success, company);
    }

    public (DatabaseResult, List<Company>) GetAllCompanies()
    {
        return (DatabaseResult.Success, MockData.Companies);
    }

    public DatabaseResult CreateUpdateCompany(Company company)
    {
        var existingCompany = MockData.Companies.Find(c => c.Id == company.Id);
        if (existingCompany != null)
        {
            existingCompany.StockSymbol = company.StockSymbol;
            existingCompany.TotalShares = company.TotalShares;
            return DatabaseResult.Success;
        }

        MockData.Companies.Add(company);
        return DatabaseResult.Success;
    }
}