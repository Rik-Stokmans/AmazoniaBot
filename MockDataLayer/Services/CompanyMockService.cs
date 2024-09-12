using LogicLayer.Interfaces;
using LogicLayer.Models;

namespace MockDataLayer.Services;
public class CompanyMockService : ICompanyService
{
    public Task<(DatabaseResult, Company)> GetCompany(int id)
    {
        var company = MockData.Companies.Find(company => company.Id == id);
        
        return Task.FromResult(company == null
            ? (DatabaseResult.NotFound, new Company(0, "", 0))
            : (DatabaseResult.Success, company));
    }

    public Task<(DatabaseResult, List<Company>)> GetAllCompanies()
    {
        return Task.FromResult((DatabaseResult.Success, MockData.Companies));
    }

    public Task<DatabaseResult> CreateUpdateCompany(Company company)
    {
        var existingCompany = MockData.Companies.Find(c => c.Id == company.Id);
        if (existingCompany != null)
        {
            existingCompany.StockSymbol = company.StockSymbol;
            existingCompany.TotalShares = company.TotalShares;
            return Task.FromResult(DatabaseResult.Success);
        }

        MockData.Companies.Add(company);
        return Task.FromResult(DatabaseResult.Success);
    }
}