using Microsoft.Data.SqlClient;
using System.Data;

namespace ErrorHandlingTasks
{
    public class AdoDbConnection
    {
        private readonly SqlConnection _connection;
        public AdoDbConnection(SqlConnection connection) 
        {
            _connection = connection;
            StaticClass.DoWork(_connection);
        }

        public string ExecuteScalar(string sql)
        {
            using (var command = new SqlCommand())
            {
                command.Connection = _connection;
                command.CommandType = CommandType.Text;
                command.CommandText = sql;
                return (string)command.ExecuteScalar();
            }
        }

        public void ExecuteNonQuery()
        {
            SqlParameter parameter;

            using (var command = new SqlCommand())
            {
                command.Connection = _connection;
                command.CommandType = CommandType.Text;
                command.CommandText = @"  
INSERT INTO SalesLT.Product  
		(Name,  
		ProductNumber,  
		StandardCost,  
		ListPrice,  
		SellStartDate  
		)  
	OUTPUT  
		INSERTED.ProductID  
	VALUES  
		(@Name,  
		@ProductNumber,  
		@StandardCost,  
		CURRENT_TIMESTAMP  
		); ";

                parameter = new SqlParameter("@Name", SqlDbType.NVarChar, 50);
                parameter.Value = "SQL Server Express 2014";
                command.Parameters.Add(parameter);

                parameter = new SqlParameter("@ProductNumber", SqlDbType.NVarChar, 25);
                parameter.Value = "SQLEXPRESS2014";
                command.Parameters.Add(parameter);

                parameter = new SqlParameter("@StandardCost", SqlDbType.Int);
                parameter.Value = 11;
                command.Parameters.Add(parameter);

                parameter = new SqlParameter("@ListPrice", SqlDbType.Int);
                parameter.Value = 12;
                command.Parameters.Add(parameter);

                int productId = (int)command.ExecuteNonQuery();
                Console.WriteLine("The generated ProductID = {0}.", productId);
            }
        }
    }
}
