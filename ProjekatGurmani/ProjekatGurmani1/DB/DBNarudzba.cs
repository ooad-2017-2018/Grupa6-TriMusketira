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
    public class DBNarudzba
    {
        public List<NarudzbaHrane> Narudzbe { get; set; }
        public List<int> narudzbeKupca { get; set; }
        public DBNarudzba()
        {
            Narudzbe = new List<NarudzbaHrane>();
        }
        public void ucitajNarudzbe()
        {
            try
            {
                Narudzbe = new List<NarudzbaHrane>();
                String query = "SELECT * FROM NarudzbaHrane;";
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
                            NarudzbaHrane a = new NarudzbaHrane(Convert.ToInt32(reader.GetString(0)), reader.GetInt32(1));
                            Narudzbe.Add(a);
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
        public void ucitajNarudzbeKupca(int idKupca)
        {
            try
            {
                narudzbeKupca = new List<int>();
                String query = "SELECT * FROM Narudzba WHERE idKupca = @idObj;";
                DBConnectionString s = new DBConnectionString();
                using (SqlConnection con = new SqlConnection(s.GetString()))
                {
                    con.Open();
                    if (con.State == System.Data.ConnectionState.Open)
                    {
                        SqlCommand cmd = con.CreateCommand();
                        cmd.CommandText = query;
                        SqlParameter id = new SqlParameter();
                        id.Value = idKupca;
                        id.ParameterName = "idObj";
                        cmd.Parameters.Add(id);
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            narudzbeKupca.Add(Convert.ToInt32(reader.GetString(0)));
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

        public int brisiNarudzbu(NarudzbaHrane a)
        {
            try
            {
                String query = "DELETE FROM NarudzbaHrane WHERE id = @id;";
                DBConnectionString s = new DBConnectionString();
                using (SqlConnection con = new SqlConnection(s.GetString()))
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandText = query;
                    SqlParameter id = new SqlParameter();
                    id.Value = Convert.ToString(a.idNarudzbe);
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
        public int unesiNarudzbu(NarudzbaHrane a)
        {
            try
            {
                String query = "insert into NarudzbaHrane " +
                    "values (@id,@idKupca)";
                DBConnectionString s = new DBConnectionString();
                using (SqlConnection con = new SqlConnection(s.GetString()))
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandText = query;

                    SqlParameter id = new SqlParameter();
                    id.Value = Convert.ToString(a.idNarudzbe);
                    id.ParameterName = "id";

                    SqlParameter idKupca = new SqlParameter();
                    idKupca.Value = a.idKupca;
                    idKupca.ParameterName = "idKupca";
                    

                    cmd.Parameters.Add(id);
                    cmd.Parameters.Add(idKupca);

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
