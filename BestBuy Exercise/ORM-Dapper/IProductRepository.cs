namespace ORM_Dapper;
public interface IProductRepository
{
    IEnumerable<Product> GetAllProducts();

    public static void CreateProduct(string name, decimal price, int quantity)
    {
        
    }
}