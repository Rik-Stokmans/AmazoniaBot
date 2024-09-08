namespace LogicLayer.Models;

public class Company(int id, string stockSymbol, int totalShares)
{
    public int Id { get; set; } = id;
    public string StockSymbol { get; set; } = stockSymbol;
    public int TotalShares { get; set; } = totalShares;
}