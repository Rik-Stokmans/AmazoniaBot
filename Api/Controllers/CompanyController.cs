using LogicLayer.Core;
using LogicLayer.Models.DataModels;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CompanyController : ControllerBase
{
    [HttpGet("GetAll")]
    public async Task<ActionResult<List<Company>>> GetAllCompanies()
    {
        var companies = await Core.GetAllCompanies();

        return Ok(companies);
    }
    
    [HttpGet("GetAll/{discordId}")]
    public async Task<ActionResult<CompanyList>> GetAllCompanies(ulong discordId)
    {
        var companies = await Core.GetAllCompanies(discordId);
        
        companies.Item1.ForEach(x => Console.WriteLine(x.OwnerId));
        Console.WriteLine("======");
        companies.Item2.ForEach(x => Console.WriteLine(x.OwnerId));

        var companyList = new CompanyList(companies.Item1, companies.Item2);

        return Ok(companyList);
    }

    public class CompanyList(List<Company> userCompanies, List<Company> otherCompanies)
    {
        public List<Company> UserCompanies { get; set; } = userCompanies;

        public List<Company> OtherCompanies { get; set; } = otherCompanies;
    }
}