using LogicLayer.Models.DataModels;

namespace LogicLayer.Interfaces.DataServices;

public interface ICompanyHistoryService
{
    /// <summary>
    /// Retrieves the history of a specific company based on the provided company ID.
    /// </summary>
    /// <param name="companyId">The unique identifier of the company whose history is being retrieved.</param>
    /// <returns>
    /// A tuple containing:
    /// - <see cref="DatabaseResult"/>: The result of the database query, indicating success or failure.
    /// - <see cref="List{CompanyHistory}"/>: A list of company history records for the specified company.
    /// </returns>
    public Task<(DatabaseResult, List<CompanyHistory>)> GetCompanyHistory(int companyId);

    /// <summary>
    /// Retrieves the complete history of all companies in the system.
    /// </summary>
    /// <returns>
    /// A tuple containing:
    /// - <see cref="DatabaseResult"/>: The result of the database query, indicating success or failure.
    /// - <see cref="List{CompanyHistory}"/>: A list of all company history records in the system.
    /// </returns>
    public Task<(DatabaseResult, List<CompanyHistory>)> GetAllCompanyHistory();

    /// <summary>
    /// Creates or updates a company history record in the system.
    /// </summary>
    /// <param name="companyHistory">The company history object to create or update.</param>
    /// <returns>
    /// A <see cref="DatabaseResult"/> indicating the success or failure of the operation.
    /// </returns>
    public Task<DatabaseResult> CreateUpdateCompanyHistory(CompanyHistory companyHistory);

}