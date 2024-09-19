using LogicLayer.Interfaces.DataServices;
using LogicLayer.Models.DataModels;

namespace LogicLayer.Core;

public static partial class Core
{
    // ReSharper disable once NullableWarningSuppressionIsUsed
    private static ICompanyService _companyService = null!;

    public static async Task<List<Company>> GetAllCompanies()
    {
        CheckInit();
        
        var (result, companies) = await _companyService.GetAllCompanies();
        
        return result == DatabaseResult.Success ? companies : [];
    }
    
    public static async Task<(List<Company>, List<Company>)> GetAllCompanies(ulong discordId)
    {
        CheckInit();
        
        var (result, companies) = await _companyService.GetAllCompanies();
        
        if (result != DatabaseResult.Success)
        {
            return ([],[]);
        }
        
        var userCompanies = companies.Where(x => x.OwnerId == discordId).ToList();
        var otherCompanies = companies.Where(x => x.OwnerId != discordId).ToList();
        
        return (userCompanies, otherCompanies);
    }
}