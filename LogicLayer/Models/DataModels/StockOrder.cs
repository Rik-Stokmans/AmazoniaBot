namespace LogicLayer.Models.DataModels;

public class StockOrder(ulong userId, int companyId, int shareAmount, OrderType orderType)
{
    public ulong userId { get; set; }
    
    public int companyId { get; set; }
    
    public int shareAmount { get; set; }
    
    public OrderType orderType { get; set; }
}

public enum OrderType
{
    Buy,
    Sell
}