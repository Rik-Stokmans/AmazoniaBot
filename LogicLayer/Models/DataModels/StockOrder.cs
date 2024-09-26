namespace LogicLayer.Models.DataModels;

public class StockOrder(ulong userId, int companyId, int shareAmount, bool buyType, long price, int bankAccountId, int orderId = 0)
{
    public int OrderId { get; set; } = orderId;
    
    public ulong userId { get; set; } = userId;

    public int companyId { get; set; } = companyId;

    public int shareAmount { get; set; } = shareAmount;

    public bool buyType { get; set; } = buyType;

    public long price { get; set; } = price;

    public int bankAccountId { get; set; } = bankAccountId;
}