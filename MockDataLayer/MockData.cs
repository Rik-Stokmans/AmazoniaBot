using LogicLayer.Models;

namespace MockDataLayer;

public class MockData
{
    public static List<User> Users { get; set; } = [];

    public static List<BankAccount> BankAccounts { get; set; } = [];
    
    public static List<StockBalance> StockBalances { get; set; } = [];

    public static List<Company> Companies { get; set; } = [];

    public static List<CompanyHistory> CompanyHistories { get; set; } = [];
}