using System.Data;
using System.Data.SqlClient;

namespace SeeMyPoints;

public abstract class ADO
{
    static string connectionString = @"Data Source=PC_JULIEN;Initial Catalog=SeeMyPoints;User ID=root;Password=Azerty@123;";
    //static string connectionString = @"Data Source=WIN-10L382S9TJE;Initial Catalog=SeeMyPoints;User ID=aalpha;Password=Azerty@123;";
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