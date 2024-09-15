using LogicLayer.Models.DataModels;

namespace LogicLayer.Interfaces.DataServices;

public interface ICompanyService
{
    /// <summary>
    /// Retrieves the details of a specific company based on the provided company ID.
    /// </summary>
    /// <param name="id">The unique identifier of the company.</param>
    /// <returns>
    /// A tuple containing:
    /// - <see cref="DatabaseResult"/>: The result of the database query, indicating success or failure.
    /// - <see cref="Company"/>: The company object associated with the specified ID, or null if not found.
    /// </returns>
    public Task<(DatabaseResult, Company)> GetCompany(int id);

    /// <summary>
    /// Retrieves a list of all companies in the system.
    /// </summary>
    /// <returns>
    /// A tuple containing:
    /// - <see cref="DatabaseResult"/>: The result of the database query, indicating success or failure.
    /// - <see cref="List{Company}"/>: A list of all company records in the system.
    /// </returns>
    public Task<(DatabaseResult, List<Company>)> GetAllCompanies();

    /// <summary>
    /// Creates a new company or updates an existing company's information in the system.
    /// </summary>
    /// <param name="company">The company object containing the information to create or update.</param>
    /// <returns>
    /// A <see cref="DatabaseResult"/> indicating the success or failure of the create or update operation.
    /// </returns>
    public Task<DatabaseResult> CreateUpdateCompany(Company company);

}