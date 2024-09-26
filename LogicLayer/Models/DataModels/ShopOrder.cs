namespace LogicLayer.Models.DataModels;

public class ShopOrder
{
    public int OrderId { get; set; }
    
    public ulong UserId { get; set; }
    
    public int ItemId { get; set; }
    
    public int Quantity { get; set; }
    
    public int TotalPrice { get; set; }
    
    public int AmountPaid { get; set; }
    
    public DateTime OrderDate { get; set; }
    
    public DateTime EstimatedDeliveryDate { get; set; }
    
    
}