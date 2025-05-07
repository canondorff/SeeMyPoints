using System.Data;
using System.Data.SqlClient;

namespace SeeMyPoints;

public class ADOEquipe : ADO
{
    public static int insertEquipe(Equipe equipe)
    {
        OpenSqlConnection();
        SqlCommand command;
        string sql = $"INSERT INTO Equipe (nom_equipe, score) VALUES ('{equipe.Nom}', '{equipe.Score}'); SELECT SCOPE_IDENTITY();";
        command = new SqlCommand(sql, cnn);
        int newId = Convert.ToInt32(command.ExecuteScalar());
        equipe.Id = newId;
        command.Dispose();
        closeSqlConnection();
        return newId;
    }
    
    public static List<Equipe> GetAllEquipes()
    {
        OpenSqlConnection();
        SqlCommand command;
        SqlDataAdapter adapter = new SqlDataAdapter();
        string sql = "SELECT * FROM Equipe";
        command = new SqlCommand(sql, cnn);
        List<Equipe> equipes = new List<Equipe>();

        using (SqlDataReader reader = command.ExecuteReader())
        {
            while (reader.Read())
            {
                string nom = reader["nom_equipe"].ToString();
                int score = Convert.ToInt16(reader["score"]);
                Equipe equipe = new Equipe(nom);
                equipes.Add(equipe);
            }
        }

        command.Dispose();
        closeSqlConnection();
        return equipes;
    }
        
    public static Equipe getEquipe(int id_equipe)
    {
        OpenSqlConnection();
        SqlCommand command;
        SqlDataAdapter adapter = new SqlDataAdapter();
        string sql = $"SELECT * FROM Equipe WHERE id_equipe = '{id_equipe}'";
        command = new SqlCommand(sql, cnn);
        Equipe equipe = null;
        using (SqlDataReader reader = command.ExecuteReader())
        {
            if (reader.Read())
            {
                string nom = reader["nom_equipe"].ToString();
                equipe = new Equipe(nom);
            }
        }
        command.Dispose();
        closeSqlConnection();
        return equipe;
    }
        
    protected static void updateEquipe(Equipe equipe, int id_equipe)
    {
        OpenSqlConnection();
        SqlCommand command;
        SqlDataAdapter adapter = new SqlDataAdapter();
        string sql = "";
        sql = $"UPDATE Equipe SET nom_equipe = '{equipe.Nom}', score = '{equipe.Score}' WHERE id_equipe = '{id_equipe}'";
        command = new SqlCommand(sql, cnn);
        adapter.UpdateCommand = new SqlCommand(sql, cnn);
        adapter.UpdateCommand.ExecuteNonQuery();
        command.Dispose();
        closeSqlConnection();
    }
        
    protected static void deleteEquipe(int id_equipe)
    {
        OpenSqlConnection();
        SqlCommand command;
        SqlDataAdapter adapter = new SqlDataAdapter();
        string sql = "";
        sql = $"DELETE FROM Equipe WHERE id_equipe = '{id_equipe}'";
        command = new SqlCommand(sql, cnn);
        adapter.DeleteCommand = new SqlCommand(sql, cnn);
        adapter.DeleteCommand.ExecuteNonQuery();
        command.Dispose();
        closeSqlConnection();
    }
}