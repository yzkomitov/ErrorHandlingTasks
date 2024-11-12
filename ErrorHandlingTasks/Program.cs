using ErrorHandlingTasks;
using Microsoft.Data.SqlClient;

namespace EFCore.AdventureWorksLT2022
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var connection = new SqlConnection("Server=localhost;Database=AdventureWorksLT2022;");
            var adoDbReader = new AdoDbConnection(connection);
            
            var customerCount = adoDbReader.ExecuteScalar("SELECT COUNT * FROM Customer");
            
            if (false)
            {
                adoDbReader.ExecuteNonQuery();
            }
        }
    }
}
