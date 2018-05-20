using ProjekatGurmani1.Modeli;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjekatGurmani1.DB;

namespace ProjekatGurmani1.DB
{
    public class DBObjekat
    {
        public List<Objekat> Objekti { get; set; }
        public DBObjekat()
        {
            Objekti = new List<Objekat>();
        }
        public void ucitajObjekte()
        {
            try
            {
                Objekti = new List<Objekat>();
                String query = "SELECT * FROM Objekat;";
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
                            Objekat a = new Objekat(Convert.ToInt32(reader.GetString(0)), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetString(5), reader.GetString(6), reader.GetString(7), reader.GetString(8));
                            DBJelo dbj = new DBJelo();
                            dbj.ucitajJelaObjekta(a.id);
                            a.jela = dbj.jelaObjekta;
                            Objekti.Add(a);
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
        public int brisiObjekat(Objekat a)
        {
            try
            {
                String query = "DELETE FROM Objekat WHERE id = @id;";
                DBConnectionString s = new DBConnectionString();
                using (SqlConnection con = new SqlConnection(s.GetString()))
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandText = query;
                    SqlParameter id = new SqlParameter();
                    id.Value = Convert.ToString(a.id);
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
        public int unesiObjekat(Objekat a)
        {
            try
            {
                String query = "insert into Objekat " +
                    "values (@id,@Ime,@Prezime,@Adresa,@Telefon,@Username,@Password,@Mail,@Grad)";
                DBConnectionString s = new DBConnectionString();
                using (SqlConnection con = new SqlConnection(s.GetString()))
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandText = query;

                    SqlParameter id = new SqlParameter();
                    id.Value = Convert.ToString(a.id);
                    id.ParameterName = "id";

                    SqlParameter Ime = new SqlParameter();
                    Ime.Value = a.ime;
                    Ime.ParameterName = "Ime";

                    SqlParameter Prezime = new SqlParameter();
                    Prezime.Value = a.prezime;
                    Prezime.ParameterName = "Prezime";

                    SqlParameter Adresa = new SqlParameter();
                    Adresa.Value = a.adresa;
                    Adresa.ParameterName = "Adresa";

                    SqlParameter Telefon = new SqlParameter();
                    Telefon.Value = a.telefon;
                    Telefon.ParameterName = "Telefon";

                    SqlParameter Username = new SqlParameter();
                    Username.Value = a.username;
                    Username.ParameterName = "Username";

                    SqlParameter Password = new SqlParameter();
                    Password.Value = a.password;
                    Password.ParameterName = "Password";

                    SqlParameter Mail = new SqlParameter();
                    Mail.Value = a.email;
                    Mail.ParameterName = "Mail";

                    SqlParameter Grad = new SqlParameter();
                    Grad.Value = a.grad;
                    Grad.ParameterName = "Grad";

                    cmd.Parameters.Add(id);
                    cmd.Parameters.Add(Ime);
                    cmd.Parameters.Add(Prezime);
                    cmd.Parameters.Add(Adresa);
                    cmd.Parameters.Add(Telefon);
                    cmd.Parameters.Add(Username);
                    cmd.Parameters.Add(Password);
                    cmd.Parameters.Add(Mail);
                    cmd.Parameters.Add(Grad);

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
