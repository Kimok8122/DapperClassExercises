using System;
using System.Data;
using System.IO;
using MySql.Data.MySqlClient;
using Microsoft.Extensions.Configuration;


namespace DrapperClass
{
    class Program
    {
        static void Main(string[] args)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            string connString = config.GetConnectionString("DefaultConnection");

            IDbConnection conn = new MySqlConnection(connString);

            //------------  above connects the SQL ----------------


            // --- connects Department info and allows to intsert new depatment name

            var repo = new DapperDepartmentRepository(conn);

            Console.WriteLine("Type a New Department name:");

            var newDepartment = Console.ReadLine();

            //repo.CreateDepartment(newDepartment);

            //repo.InsertDepartment(newDepartment);

            var departments = repo.GetAllDepartments();

            foreach (var item in departments)
            {
                Console.WriteLine($" ID: {item.DepartmentID} | Item: {item.Name}");
            }


            // ---------------

            var productRepo = new DapperProductRepository(conn);

            Console.WriteLine("$---------------");
            Console.WriteLine("$ Type a new Product Name:");

            var newProduct = Console.ReadLine();

            Console.WriteLine("$---------------");
            Console.WriteLine("$ Type a new Price for the product:");

            var newPrice = double.Parse(Console.ReadLine());

            Console.WriteLine("$---------------");
            Console.WriteLine("$ Type a Catergory ID to assign the product 1-10:");

            var newCatergoryId = int.Parse(Console.ReadLine());

            productRepo.InsertProducts(newProduct, newPrice, newCatergoryId);

            var addProducts = productRepo.GetAllProducts();

            foreach (var item in addProducts)
            {
                Console.WriteLine($"ID: {item.ProductID} | NAME:{item.Name} | PRICE: {item.Price} ");
            }

        }
    }
}
    
