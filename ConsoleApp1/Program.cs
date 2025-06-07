using Bogus;
using Microsoft.Data.SqlClient;
using System.Data;

namespace ConsoleApp1
{
    internal class Program
    {
        public class Product
        {
            public int Id { get; set; }
            public required string Name { get; set; }
            public required string Description { get; set; }
        }

        static void Main()
        {
            var connectionString = "Server=LocalHost;Database=Hackathon2025;Trusted_Connection=True;TrustServerCertificate=true;";
            for (int i = 0; i < 1000; i++)
            {
                PopulateIt(connectionString, 1000);
            }
        }

        private static void PopulateIt(string connectionString, int numberOfRows)
        {

            // Generate fake data using Bogus
            var productFaker = new Faker<Product>()
                .RuleFor(p => p.Name, f => f.Commerce.ProductName())
                .RuleFor(p => p.Description, f => f.Commerce.ProductDescription());

            var products = productFaker.Generate(numberOfRows);

            // Convert to DataTable
            var table = new DataTable();
            table.Columns.Add("ProductName", typeof(string));
            table.Columns.Add("ProductDescription", typeof(string));

            foreach (var p in products)
            {
                table.Rows.Add(p.Name, p.Description);
            }

            // Use SqlBulkCopy to insert data
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (var bulkCopy = new SqlBulkCopy(connection))
                {
                    bulkCopy.DestinationTableName = "Products";
                    bulkCopy.ColumnMappings.Add("Name", "ProductName");
                    bulkCopy.ColumnMappings.Add("Description", "ProductDescription");

                    bulkCopy.WriteToServer(table);
                }
            }

            Console.WriteLine($"{numberOfRows} rows inserted into the Product table faster than you can say 'ORMs are overrated.'");
        }
    }
}
