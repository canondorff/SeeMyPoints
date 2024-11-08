using System.Data;
using System.Data.SqlClient;

namespace SeeMyPoints;

public abstract class ADO
{
    static string connectionString = @"Data Source=WIN-10L382S9TJE;Initial Catalog=bd_alpha;Integrated Security=SSPI;";
    // static string connectionString = @"Data Source=DESKTOP-PT0UKEB;Initial Catalog=SeeMyPoints;User ID=root;Password=admin123;";
    public static SqlConnection cnn = new SqlConnection(connectionString);
    
    public static void OpenSqlConnection()
    {
        
        {
            try
            {
                cnn.Open();
            }
            catch (SqlException ex)
            {
            }
        }
    }
    
    public static void closeSqlConnection()
    {
        cnn.Close();
    }
}