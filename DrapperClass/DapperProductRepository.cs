using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;

namespace DrapperClass
{
    public class DapperProductRepository : IProductRepository
    {
            private readonly IDbConnection _connection;

            public DapperProductRepository(IDbConnection connection)
        {
            _connection = connection;
        }

            public IEnumerable<Product> GetAllProducts()
        {
            return _connection.Query<Product>("Select * From products;").ToList();
        }

            public void InsertProducts(string newProductName, double price, int categoryID)
        {
            _connection.Execute("INSERT INTO PRODUCTS (Name, Price, CategoryID) VALUES (@Name, @price, @categoryID);",
            new {Name = newProductName, price = price, categoryID = categoryID });
        }



        

        //public void CreateProduct(string name, double price, int categoryID)
        //{
        //    throw new NotImplementedException();
        //}

       
    }
    
}
