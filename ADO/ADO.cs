using System.Data;
using System.Data.SqlClient;
using System.Windows;

namespace SeeMyPoints;

public abstract class ADO
{
    static string ConnectionString = @"Data Source=PC_JULIEN;Initial Catalog=SeeMyPoints;User ID=root;Password=Azerty@123;";
    //static string ConnectionString = "Data Source=WIN-10L382S9TJE;Initial Catalog=bd_alpha;Integrated Security=SSPI;";
    public static SqlConnection cnn = new SqlConnection(ConnectionString);    
    
    public static void OpenSqlConnection()
    {
        try
        {
            ADO.cnn.Open();
        }
        catch (SqlException ex)
        {
            MessageBox.Show(ex.Message);
        }
    }
    
    public static void closeSqlConnection()
    {
        cnn.Close();
    }
}