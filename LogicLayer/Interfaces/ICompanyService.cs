using LogicLayer.Models;

namespace LogicLayer.Interfaces;

public interface ICompanyService
{
    public (DatabaseResult, Company) GetCompany(int id);
    
    public (DatabaseResult, List<Company>) GetAllCompanies();
    
    public DatabaseResult CreateUpdateCompany(Company company);
}