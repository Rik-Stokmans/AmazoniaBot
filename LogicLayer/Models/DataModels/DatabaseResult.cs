namespace LogicLayer.Models.DataModels;

/// <summary>
/// Represents the possible results of a database operation.
/// </summary>
public enum DatabaseResult
{
    /// <summary>
    /// Indicates that the database operation was successful.
    /// </summary>
    Success,

    /// <summary>
    /// Indicates that the database operation failed.
    /// </summary>
    Fail,

    /// <summary>
    /// Indicates that the database operation failed because of a duplicate entry.
    /// </summary>
    Duplicate,
    
    /// <summary>
    /// indicates that the database operation failed because the entry was not found.
    /// </summary>
    NotFound
}
