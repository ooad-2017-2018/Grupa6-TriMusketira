using ProjekatGurmani1.Modeli;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatGurmani1.DB
{
    public class DBAdministrator
    {
        public List<Administrator> Administratori { get; set; }
        public DBAdministrator()
        {
            Administratori = new List<Administrator>();
        }
        public void ucitajAdministratore()
        {
            try
            {
                Administratori = new List<Administrator>();
                String query = "SELECT * FROM Administrator;";
                DBConnectionString s = new DBConnectionString();
                using (SqlConnection con = new SqlConnection(s.GetString()))
                {
                    con.Open();
                    if (con.State == System.Data.ConnectionState.Open)
                    {
                        SqlCommand cmd = con.CreateCommand();
                        cmd.CommandText = query;
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            Administrator a = new Administrator(Convert.ToInt32(reader.GetString(0)), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4));
                            Administratori.Add(a);
                        }
                    }
                    con.Close();
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine("Exception: " + e.Message);
            }
        }
        public int brisiAdministratora(Administrator a)
        {
            try
            {
                String query = "DELETE FROM Administrator WHERE id = @id;";
                DBConnectionString s = new DBConnectionString();
                using (SqlConnection con = new SqlConnection(s.GetString()))
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandText = query;
                    SqlParameter id = new SqlParameter();
                    id.Value = Convert.ToString(a.ID);
                    id.ParameterName = "id";
                    cmd.Parameters.Add(id);
                    con.Open();
                    int r = 0;
                    if (con.State == System.Data.ConnectionState.Open)
                        r = cmd.ExecuteNonQuery();
                    con.Close();
                    return r;
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine("Exception: " + e.Message);
                return 0;
            }
        }
        public int unesiAdministratora(Administrator a)
        {
            try
            {
                String query = "insert into Administrator " +
                    "values (@id,@Ime,@Prezime,@Username,@Password)";
                DBConnectionString s = new DBConnectionString();
                using (SqlConnection con = new SqlConnection(s.GetString()))
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandText = query;

                    SqlParameter id = new SqlParameter();
                    id.Value = Convert.ToString(a.ID);
                    id.ParameterName = "id";

                    SqlParameter Ime = new SqlParameter();
                    Ime.Value = a.Ime;
                    Ime.ParameterName = "Ime";

                    SqlParameter Prezime = new SqlParameter();
                    Prezime.Value = a.Prezime;
                    Prezime.ParameterName = "Prezime";

                    SqlParameter Username = new SqlParameter();
                    Username.Value = a.Username;
                    Username.ParameterName = "Username";

                    SqlParameter Password = new SqlParameter();
                    Password.Value = a.Password;
                    Password.ParameterName = "Password";

                    cmd.Parameters.Add(id);
                    cmd.Parameters.Add(Ime);
                    cmd.Parameters.Add(Prezime);
                    cmd.Parameters.Add(Username);
                    cmd.Parameters.Add(Password);

                    int k = cmd.ExecuteNonQuery();
                    cmd.Dispose();
                    return k;
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine("Exception: " + e.Message);
                return 0;
            }
        }
    }
}
