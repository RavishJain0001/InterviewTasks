using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;


namespace KPMG.Interview.TaskOne.DbRepository
{
    public class DbRepository
    {
        private IConfiguration configuration;

        public DbRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public string GetData()
        {
            try
            {
                var builder = new SqlConnectionStringBuilder(configuration["Conn"]);

                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {
                    connection.Open();

                    String sql = "SELECT Top(1) * FROM ChallengeData";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                return reader.GetString(1);
                            }
                        }
                    }
                }
            }
            catch
            {
                throw;
            }

            throw new Exception();
        }
    }
}