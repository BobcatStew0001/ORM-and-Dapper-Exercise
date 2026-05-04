namespace ORM_Dapper;
public class Product
{
   

    public int  ProductId { get; set; }
    public string? Name { get; set; }
    public decimal Price { get; set; }
    public int StockLevel { get; set; }
    public int CategoryId { get; set; } 
    public bool  OnSale { get; set;}
    
}