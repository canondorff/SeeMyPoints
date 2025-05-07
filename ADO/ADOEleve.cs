using System.Data;
using System.Data.SqlClient;

namespace SeeMyPoints;

public class ADOEleve : ADO
{
    public static void insertEleve(Eleve eleve)
    {
        OpenSqlConnection();
        string sql = "INSERT INTO eleve (nom_eleve, classe) VALUES (@nom, @classe)";
        using (SqlCommand command = new SqlCommand(sql, cnn))
        {
            command.Parameters.AddWithValue("@nom", eleve.Nom);
            command.Parameters.AddWithValue("@classe", eleve.Classe);
            command.ExecuteNonQuery();
        }
        closeSqlConnection();
    }
    
    public static List<Eleve> GetAllEleves()
    {
        OpenSqlConnection();
        SqlCommand command;
        SqlDataAdapter adapter = new SqlDataAdapter();
        string sql = "SELECT * FROM eleve";
        command = new SqlCommand(sql, cnn);
        List<Eleve> eleves = new List<Eleve>();

        using (SqlDataReader reader = command.ExecuteReader())
        {
            while (reader.Read())
            {
                string nom_eleve = reader["nom_eleve"].ToString();
                string classe = reader["classe"].ToString();
                int? id_equipe = reader["id_equipe"] != DBNull.Value ? Convert.ToInt32(reader["id_equipe"]) : null;
                Eleve eleve = new Eleve(nom_eleve, classe);
                if (id_equipe.HasValue) eleve.IdEquipe = id_equipe.Value;
                eleves.Add(eleve);
            }
        }

        command.Dispose();
        closeSqlConnection();
        return eleves;
    }
        
        public static Eleve getEleve(int id_eleve)
        {
            OpenSqlConnection();
            SqlCommand command;
            SqlDataAdapter adapter = new SqlDataAdapter();
            string sql = $"SELECT * FROM eleve WHERE id_eleve = '{id_eleve}'";
            command = new SqlCommand(sql, cnn);
            Eleve eleve = null;
            using (SqlDataReader reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    string nom = reader["nom_eleve"].ToString();
                    string classe = reader["classe"].ToString();
                    eleve = new Eleve(nom, classe);
                }
            }
            command.Dispose();
            closeSqlConnection();
            return eleve;
        }
        
        public static void updateEleve(Eleve eleve, int id_eleve)
        {
            OpenSqlConnection();
            string sql = "UPDATE eleve SET nom_eleve = @nom, classe = @classe, id_equipe = @idEquipe WHERE id_eleve = @idEleve";
            using (SqlCommand command = new SqlCommand(sql, cnn))
            {
                command.Parameters.AddWithValue("@nom", eleve.Nom);
                command.Parameters.AddWithValue("@classe", eleve.Classe);
                command.Parameters.AddWithValue("@idEquipe", eleve.IdEquipe > 0 ? (object)eleve.IdEquipe : DBNull.Value);
                command.Parameters.AddWithValue("@idEleve", id_eleve);
                command.ExecuteNonQuery();
            }
            closeSqlConnection();
        }
        
        public static void deleteEleve(int id_eleve)
        {
            OpenSqlConnection();
            SqlCommand command;
            SqlDataAdapter adapter = new SqlDataAdapter();
            string sql = "";
            sql = $"DELETE FROM eleve WHERE id_eleve = '{id_eleve}'";
            command = new SqlCommand(sql, cnn);
            adapter.DeleteCommand = new SqlCommand(sql, cnn);
            adapter.DeleteCommand.ExecuteNonQuery();
            command.Dispose();
            closeSqlConnection();
        }
}