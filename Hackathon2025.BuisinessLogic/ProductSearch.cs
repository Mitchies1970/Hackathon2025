using Hackathon2025.DTOs;

namespace Hackathon2025.BuisinessLogic
{
    public class ProductSearch(AiService.SqlGenerator _aiServiceSqlGenerator, Hackathon2025.DbRepo.Query _queryRunner)
    {
        private Hackathon2025.AiService.SqlGenerator aiServiceSqlGenerator = _aiServiceSqlGenerator;
        private Hackathon2025.DbRepo.Query queryRunner = _queryRunner;

        public List<Product> FindProducts(string searchText)
        {
            //First thing we need to do is to ask AI to take the search text and generate a SQL query from it. 
            string sql = aiServiceSqlGenerator.GenerateSqlQuery<Product>(searchText);

            //Take the SQL and run it to return the results
            List<Product> products = queryRunner.GetProducts(sql);

            //with that SQL we can go and get the products
            return products;
        }
    }
}
