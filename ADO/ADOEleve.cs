using System.Data;
using System.Data.SqlClient;

namespace SeeMyPoints;

public class ADOEleve : ADO
{
    public static void insertEleve(Eleve eleve)
    {
        OpenSqlConnection();
        SqlCommand command;
        SqlDataAdapter adapter = new SqlDataAdapter();
        string sql = "";
        sql = $"INSERT INTO Eleve (nom_eleve, classe) VALUES ('{eleve.Nom}', '{eleve.Classe}')";
        command = new SqlCommand(sql, cnn);
        adapter.InsertCommand = new SqlCommand(sql, cnn);
        adapter.InsertCommand.ExecuteNonQuery();
        command.Dispose();
        closeSqlConnection();
    }
    
    public static Eleve getAllEleve()
        {
            OpenSqlConnection();
            SqlCommand command;
            SqlDataAdapter adapter = new SqlDataAdapter();
            string sql = "SELECT * FROM Eleve";
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
        
        public static Eleve getEleve(int id_eleve)
        {
            OpenSqlConnection();
            SqlCommand command;
            SqlDataAdapter adapter = new SqlDataAdapter();
            string sql = $"SELECT * FROM Eleve WHERE id_eleve = '{id_eleve}'";
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
            SqlCommand command;
            SqlDataAdapter adapter = new SqlDataAdapter();
            string sql = "";
            sql = $"UPDATE Eleve SET nom_eleve = '{eleve.Nom}', classe = '{eleve.Classe}' WHERE id_eleve = '{id_eleve}'";
            command = new SqlCommand(sql, cnn);
            adapter.UpdateCommand = new SqlCommand(sql, cnn);
            adapter.UpdateCommand.ExecuteNonQuery();
            command.Dispose();
            closeSqlConnection();
        }
        
        public static void deleteEleve(int id_eleve)
        {
            OpenSqlConnection();
            SqlCommand command;
            SqlDataAdapter adapter = new SqlDataAdapter();
            string sql = "";
            sql = $"DELETE FROM Eleve WHERE id_eleve = '{id_eleve}'";
            command = new SqlCommand(sql, cnn);
            adapter.DeleteCommand = new SqlCommand(sql, cnn);
            adapter.DeleteCommand.ExecuteNonQuery();
            command.Dispose();
            closeSqlConnection();
        }
}