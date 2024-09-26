using System.Net.Mime;

namespace LogicLayer.Models.DataModels;

public class ShopItem(int id, string name, int price, string image)
{
    public int Id { get; set; } = id;
    
    public string Name { get; set; } = name;
    
    public int Price { get; set; } = price;

    public string Image { get; set; } = image;
}