using System.Data;
using Dapper;
namespace ORM_Dapper;

public class DapperProductRepository : IProductRepository
{
    private readonly IDbConnection _conn;

    public DapperProductRepository(IDbConnection conn)
    {
        _conn = conn;
    }

    public IEnumerable<Product> GetAllProducts()
    {
        return _conn.Query<Product>("SELECT * FROM Products");
    }

    public Product GetProduct(int id)
    {
        return _conn.QuerySingle<Product>("SELECT * FROM Products WHERE ProductId = @id;", new { id = id });
    }

    public void UpdateProduct(Product product)
    {

        _conn.Execute(
            "UPDATE products" + " SET Name = @name," + " Price = @price," + " StockLevel = @stock" +
            ", OnSale = @onSale, CategoryId = @categoryId" + " WHERE ProductId = @productId;", new
            {
                name = product.Name,
                price = product.Price,
                stock = product.StockLevel,
                productId = product.ProductId,
                onSale = product.OnSale,
                categoryId = product.CategoryId
            });


    }
}               