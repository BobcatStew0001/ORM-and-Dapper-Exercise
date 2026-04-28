using System.Data;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;

namespace ORM_Dapper
{
    public class Program
    {
        static IConfiguration config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();
        
        static string? connString = config.GetConnectionString("DefaultConnection");
        
        static IDbConnection conn = new MySqlConnection(connString);
        
        static void Main(string[] args)
        {
            
            var productRepository = new DapperProductRepository(conn);
            
            var productToUpdate = productRepository.GetProduct(942);
            productToUpdate.Name = "Sweet Ass Gaming Laptop";
            productToUpdate.OnSale = true;
            productToUpdate.StockLevel = 10;
            productToUpdate.Price = 2999;
            
            productRepository.UpdateProduct(productToUpdate);
            
            Console.WriteLine("Sweet Ass Gaming Laptop");
            Console.WriteLine(productToUpdate.Name);
            Console.WriteLine(productToUpdate.Price);
            Console.WriteLine(productToUpdate.StockLevel);
            Console.WriteLine(productToUpdate.OnSale);
            Console.WriteLine("--------------------");
            
            Console.WriteLine("Delete Product");
            var productToDelete = productRepository.GetProduct(943);
            productRepository.DeleteProduct(productToDelete);
            productToDelete.Name ="Gaming Laptop";
            productToDelete.OnSale = false;
            productToDelete.StockLevel = 10;
            productToDelete.Price = 2999;
            Console.WriteLine(productToDelete.Name);
            Console.WriteLine(productToDelete.Price);
            Console.WriteLine(productToDelete.StockLevel);
            Console.WriteLine(productToDelete.OnSale);
            Console.WriteLine("--------------------");
            
            Console.WriteLine("All Products");
            var products = productRepository.GetAllProducts();
            foreach (var product in products)
            {
                Console.WriteLine(product.ProductId);
                Console.WriteLine(product.Name);
                Console.WriteLine(product.Price);
                Console.WriteLine(product.StockLevel);
                Console.WriteLine(product.CategoryId);
                Console.WriteLine(product.OnSale);
                Console.WriteLine("--------------------");
                
            }
        }
    }
}