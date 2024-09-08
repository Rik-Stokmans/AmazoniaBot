namespace LogicLayer.Models;

public class CompanyHistory(int companyId, DateTime date, int profit, double dividentPerShare)
{
    public int CompanyId { get; set; } = companyId;
    public DateTime Date { get; set; } = date;
    public int Profit { get; set; } = profit;
    public double DividentPerShare { get; set; } = dividentPerShare;
}