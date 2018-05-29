using ProjekatGurmani.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatGurmani1.DB
{
    class DBNarudzba
    {
        public List<Narudzba> Narudzbe { get; set; }
        public List<int> narudzbeKupca { get; set; }
        public DBNarudzba()
        {
            Narudzbe = new List<Narudzba>();
        }
        public void ucitajNarudzbe()
        {
            try
            {
                Narudzbe = new List<Narudzba>();
                String query = "SELECT * FROM Narudzba;";
                using (SqlConnection con = new SqlConnection("AzureConnection"))
                {
                    con.Open();
                    if (con.State == System.Data.ConnectionState.Open)
                    {
                        SqlCommand cmd = con.CreateCommand();
                        cmd.CommandText = query;
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            Narudzba a = new Narudzba(Convert.ToInt32(reader.GetString(0)), reader.GetInt32(1));
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
                using (SqlConnection con = new SqlConnection("AzureConnection"))
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

        public int brisiNarudzbu(Narudzba a)
        {
            try
            {
                String query = "DELETE FROM Narudzba WHERE id = @id;";
                using (SqlConnection con = new SqlConnection("AzureConnection"))
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
        public int unesiNarudzbu(Narudzba a)
        {
            try
            {
                String query = "insert into Narudzba " +
                    "values (@id,@idKupca)";
                using (SqlConnection con = new SqlConnection("AzureConnection"))
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandText = query;

                    SqlParameter id = new SqlParameter();
                    id.Value = Convert.ToString(a.id);
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
