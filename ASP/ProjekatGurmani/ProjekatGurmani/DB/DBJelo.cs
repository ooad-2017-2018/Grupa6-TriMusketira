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
    class DBJelo
    {
        public List<Jelo> Jela { get; set; }
        public List<int> jelaObjekta { get; set; }
        public DBJelo()
        {
            Jela = new List<Jelo>();
        }
        public void ucitajJela()
        {
            try
            {
                Jela = new List<Jelo>();
                String query = "SELECT * FROM Jelo;";
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
                            Jelo a = new Jelo(Convert.ToInt32(reader.GetString(0)), reader.GetString(1), reader.GetString(2), reader.GetInt32(3), reader.GetInt32(4));
                            Jela.Add(a);
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

        public void ucitajJelaObjekta(int idObjektaa)
        {
            try
            {
                jelaObjekta = new List<int>();
                String query = "SELECT * FROM Jelo WHERE idObjekta = @idObj;";
                using (SqlConnection con = new SqlConnection("AzureConnection"))
                {
                    con.Open();
                    if (con.State == System.Data.ConnectionState.Open)
                    {
                        SqlCommand cmd = con.CreateCommand();
                        cmd.CommandText = query;
                        SqlParameter id = new SqlParameter();
                        id.Value = idObjektaa;
                        id.ParameterName = "idObj";
                        cmd.Parameters.Add(id);
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            jelaObjekta.Add(Convert.ToInt32(reader.GetString(0)));
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

        public int brisiJelo(Jelo a)
        {
            try
            {
                String query = "DELETE FROM Jelo WHERE id = @id;";
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
        public int unesiJelo(Jelo a)
        {
            try
            {
                String query = "insert into Jelo " +
                    "values (@id,@nazivJela,@vrsta,@cijena,@idObjekta)";
                using (SqlConnection con = new SqlConnection("AzureConnection"))
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandText = query;

                    SqlParameter id = new SqlParameter();
                    id.Value = Convert.ToString(a.id);
                    id.ParameterName = "id";

                    SqlParameter nazivJela = new SqlParameter();
                    nazivJela.Value = a.nazivJela;
                    nazivJela.ParameterName = "nazivJela";

                    SqlParameter vrsta = new SqlParameter();
                    vrsta.Value = a.vrsta;
                    vrsta.ParameterName = "vrsta";

                    SqlParameter cijena = new SqlParameter();
                    cijena.Value = a.cijena;
                    cijena.ParameterName = "cijena";

                    SqlParameter idObjekta = new SqlParameter();
                    idObjekta.Value = a.cijena;
                    idObjekta.ParameterName = "idObjekta";

                    cmd.Parameters.Add(id);
                    cmd.Parameters.Add(nazivJela);
                    cmd.Parameters.Add(vrsta);
                    cmd.Parameters.Add(cijena);
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
