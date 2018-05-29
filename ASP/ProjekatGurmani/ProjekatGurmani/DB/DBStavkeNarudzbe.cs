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
    public class DBStavkeNarudzbe
    {
        public List<StavkeNarudzbe> Narudzbe { get; set; }
        public DBStavkeNarudzbe()
        {
            Narudzbe = new List<StavkeNarudzbe>();
        }
        public void ucitajStavkeNarudzbe()
        {
            try
            {
                Narudzbe = new List<StavkeNarudzbe>();
                String query = "SELECT * FROM StavkeNarudzbe;";
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
                            StavkeNarudzbe a = new StavkeNarudzbe(Convert.ToInt32(reader.GetString(0)), reader.GetInt32(1), reader.GetInt32(2));
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
        public int brisiStavkuNarudzbe(StavkeNarudzbe a)
        {
            try
            {
                String query = "DELETE FROM StavkeNarudzbe WHERE id = @id;";
                using (SqlConnection con = new SqlConnection("AzureConnection"))
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
        public int unesiStavkuNarudzbe(StavkeNarudzbe a)
        {
            try
            {
                String query = "insert into StavkeNarudzbe " +
                    "values (@id,@idKupca,@idObjekta)";
                using (SqlConnection con = new SqlConnection("AzureConnection"))
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandText = query;

                    SqlParameter id = new SqlParameter();
                    id.Value = Convert.ToString(a.idNarudzbe);
                    id.ParameterName = "id";

                    SqlParameter idKupca = new SqlParameter();
                    idKupca.Value = a.idNarudzbe;
                    idKupca.ParameterName = "idKupca";

                    SqlParameter idObjekta = new SqlParameter();
                    idObjekta.Value = a.idJela;
                    idObjekta.ParameterName = "idObjekta";

                    cmd.Parameters.Add(id);
                    cmd.Parameters.Add(idKupca);
                    cmd.Parameters.Add(idObjekta);

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
