using LogicLayer.Models;

namespace LogicLayer.Interfaces;

public interface ICompanyHistoryService
{
    /// <summary>
    /// get company history by company id
    /// </summary>
    /// <param name="companyId"></param>
    /// <returns>
    /// 
    /// </returns>
    public (DatabaseResult, List<CompanyHistory>) GetCompanyHistory(int companyId);
    
    public (DatabaseResult, List<CompanyHistory>) GetAllCompanyHistory();
    
    public DatabaseResult CreateUpdateCompanyHistory(CompanyHistory companyHistory);
}