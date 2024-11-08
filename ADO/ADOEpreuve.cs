using System.Data;
using System.Data.SqlClient;

namespace SeeMyPoints;

public class ADOEpreuve : ADO
{
    public static void insertEpreuve(Epreuve epreuve)
    {
        OpenSqlConnection();
        SqlCommand command;
        SqlDataAdapter adapter = new SqlDataAdapter();
        string sql = "";
        sql = $"INSERT INTO Epreuve (nom_epreuve, desc_epreuve) VALUES ('{epreuve.Nom}', '{epreuve.Description}')";
        command = new SqlCommand(sql, cnn);
        adapter.InsertCommand = new SqlCommand(sql, cnn);
        adapter.InsertCommand.ExecuteNonQuery();
        command.Dispose();
        closeSqlConnection();
    }
    
    public static Epreuve getAllEpreuve()
    {
        OpenSqlConnection();
        SqlCommand command;
        SqlDataAdapter adapter = new SqlDataAdapter();
        string sql = "";
        sql = "SELECT * FROM Epreuve";
        command = new SqlCommand(sql, cnn);
        Epreuve epreuve = null;
        using (SqlDataReader reader = command.ExecuteReader())
        {
            if (reader.Read())
            {
                string nom = reader["nom_epreuve"].ToString();
                string description = reader["desc_epreuve"].ToString();
                epreuve = new Epreuve(nom, description);
            }
        }
        command.Dispose();
        closeSqlConnection();
        return epreuve;
    }
        
    public static Epreuve getEpreuve(int id_epreuve)
    {
        OpenSqlConnection();
        SqlCommand command;
        SqlDataAdapter adapter = new SqlDataAdapter();
        string sql = "";
        sql = $"SELECT * FROM Epreuve WHERE id_epreuve = '{id_epreuve}'";
        command = new SqlCommand(sql, cnn);
        adapter.SelectCommand = command;
        Epreuve epreuve = null;
        using (SqlDataReader reader = command.ExecuteReader())
        {
            if (reader.Read())
            {
                string nom = reader["nom_epreuve"].ToString();
                string description = reader["desc_epreuve"].ToString();
                epreuve = new Epreuve(nom, description);
            }
        }
        command.Dispose();
        closeSqlConnection();
        return null;
    }
        
    protected static void updateEpreuve(Epreuve epreuve, int id_epreuve)
    {
        OpenSqlConnection();
        SqlCommand command;
        SqlDataAdapter adapter = new SqlDataAdapter();
        string sql = "";
        sql = $"UPDATE Epreuve SET nom_epreuve = '{epreuve.Nom}', desc_epreuve = '{epreuve.Description}' WHERE id_epreuve = '{id_epreuve}'";
        command = new SqlCommand(sql, cnn);
        adapter.UpdateCommand = new SqlCommand(sql, cnn);
        adapter.UpdateCommand.ExecuteNonQuery();
        command.Dispose();
        closeSqlConnection();
    }
        
    protected static void deleteEpreuve(int id_epreuve)
    {
        OpenSqlConnection();
        SqlCommand command;
        SqlDataAdapter adapter = new SqlDataAdapter();
        string sql = "";
        sql = $"DELETE FROM Epreuve WHERE id_epreuve = '{id_epreuve}'";
        command = new SqlCommand(sql, cnn);
        adapter.DeleteCommand = new SqlCommand(sql, cnn);
        adapter.DeleteCommand.ExecuteNonQuery();
        command.Dispose();
        closeSqlConnection();
    }
}