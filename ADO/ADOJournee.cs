using System.Data;
using System.Data.SqlClient;

namespace SeeMyPoints;

public class ADOJournee : ADO
{
    public static void insertJournee(Journee journee)
    {
        OpenSqlConnection();
        SqlCommand command;
        SqlDataAdapter adapter = new SqlDataAdapter();
        string sql = "";
        sql = $"INSERT INTO Journee (nom_journee, date_journee, lieu_journee) VALUES ('{journee.Nom}', '{journee.Date}', '{journee.Lieu}')";
        command = new SqlCommand(sql, cnn);
        adapter.InsertCommand = new SqlCommand(sql, cnn);
        adapter.InsertCommand.ExecuteNonQuery();
        command.Dispose();
        closeSqlConnection();
    }
    
    public static List<Journee> getAllJournee()
    {
        OpenSqlConnection();
        SqlCommand command;
        SqlDataAdapter adapter = new SqlDataAdapter();
        string sql = "SELECT * FROM Journee";
        command = new SqlCommand(sql, cnn);
        List<Journee> journees = new List<Journee>();

        using (SqlDataReader reader = command.ExecuteReader())
        {
            while (reader.Read())
            {
                string nom = reader["nom_journee"].ToString();
                DateTime date = Convert.ToDateTime(reader["dateJournee"]);
                string lieu = reader["lieu_journee"].ToString();
                Journee journee = new Journee(nom, date, lieu);
                journees.Add(journee);
            }
        }

        command.Dispose();
        closeSqlConnection();
        return journees;
    }
        
    public static void getJournee(int id_journee)
    {
        OpenSqlConnection();
        SqlCommand command;
        SqlDataAdapter adapter = new SqlDataAdapter();
        string sql = "";
        sql = $"SELECT * FROM Journee WHERE id_journee = '{id_journee}'";
        command = new SqlCommand(sql, cnn);
        command.Dispose();
        closeSqlConnection();
    }
        
    protected static void updateJournee(string nom_journee, DateTime date_journee, string lieu_journee, int id_journee)
    {
        OpenSqlConnection();
        SqlCommand command;
        SqlDataAdapter adapter = new SqlDataAdapter();
        string sql = "";
        sql = $"UPDATE Journee SET nom_journee = '{nom_journee}', date_journee = '{date_journee}', lieu_journee = '{lieu_journee}' WHERE id_journee = '{id_journee}'";
        command = new SqlCommand(sql, cnn);
        adapter.UpdateCommand = new SqlCommand(sql, cnn);
        adapter.UpdateCommand.ExecuteNonQuery();
        command.Dispose();
        closeSqlConnection();
    }
        
    protected static void deleteJournee(int id_journee)
    {
        OpenSqlConnection();
        SqlCommand command;
        SqlDataAdapter adapter = new SqlDataAdapter();
        string sql = "";
        sql = $"DELETE FROM Journee WHERE id_journee = '{id_journee}'";
        command = new SqlCommand(sql, cnn);
        adapter.DeleteCommand = new SqlCommand(sql, cnn);
        adapter.DeleteCommand.ExecuteNonQuery();
        command.Dispose();
        closeSqlConnection();
    }
}