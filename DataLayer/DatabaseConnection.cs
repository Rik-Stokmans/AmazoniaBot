namespace DataLayer;

using MySql.Data.MySqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;

/// <summary>
/// Manages the database connection for MySQL and implements asynchronous disposal.
/// </summary>
public class DatabaseConnection : IAsyncDisposable
{
    /// <summary>
    /// Gets the MySQL connection instance.
    /// </summary>
    public readonly MySqlConnection Connection;

    /// <summary>
    /// Initializes a new instance of the <see cref="DatabaseConnection"/> class.
    /// </summary>
    /// <remarks>
    /// Configures and opens the MySQL database connection using settings from a JSON file.
    /// </remarks>
    public DatabaseConnection()
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(AppContext.BaseDirectory)
            .AddJsonFile("databasesettings.json", optional: false, reloadOnChange: true)
            .Build();
        
        Connection = new MySqlConnection(configuration.GetConnectionString("DefaultConnection"));

        try
        {
            Connection.Open();
        }
        catch (MySqlException exception)
        {
            Console.WriteLine("Error: " + exception.Message);
        }
    }

    /// <summary>
    /// Asynchronously disposes of the database connection by closing it.
    /// </summary>
    /// <returns>A <see cref="ValueTask"/> that represents the asynchronous dispose operation.</returns>
    public async ValueTask DisposeAsync()
    {
        await Connection.CloseAsync();
    }
}
