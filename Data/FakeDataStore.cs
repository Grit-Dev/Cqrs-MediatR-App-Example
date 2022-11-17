using CqrsMediatRExample.Queries;
using System.Collections;

namespace CqrsMediatRExample.Data
{
    public class FakeDataStore
    {
        //Fields
        private static List<Product> _products = new List<Product>();


        //constructor
        public FakeDataStore()
        {
            //initialize new product list with a product
            _products = new List<Product>()
            {
                new Product{ Id = 1, Name = "Test Product One"},
                new Product{ Id = 2, Name = "Test Product Two"},
                new Product{ Id = 3, Name = "Test Product Three"}
            };

        }

        // Add product method as it needs no return type for the task
        // passing a value to be added to the fake the db
        public async Task AddProduct(Product pProduct)
        {
            _products.Add(pProduct);

            await Task.CompletedTask;

        }

        public async Task<IEnumerable<Product>> GetAllProducts() => await Task.FromResult(_products);

        public async Task<Product> GetProductById(int pId) => await Task.FromResult(_products.Single(p => p.Id == pId));
            
   
    }
}
