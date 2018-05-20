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
    class DBJelo
    {
        public List<Jelo> Jela { get; set; }
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
                            Jelo a = new Jelo(Convert.ToInt32(reader.GetString(0)), reader.GetString(1), reader.GetString(2), reader.GetInt32(3));
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
        public int brisiJelo(Jelo a)
        {
            try
            {
                String query = "DELETE FROM Jelo WHERE id = @id;";
                DBConnectionString s = new DBConnectionString();
                using (SqlConnection con = new SqlConnection(s.GetString()))
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandText = query;
                    SqlParameter id = new SqlParameter();
                    id.Value = a.idJela;
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
                    "values (@id,@nazivJela,@vrsta,@cijena)";
                DBConnectionString s = new DBConnectionString();
                using (SqlConnection con = new SqlConnection(s.GetString()))
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandText = query;

                    SqlParameter id = new SqlParameter();
                    id.Value = a.idJela;
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

                    cmd.Parameters.Add(id);
                    cmd.Parameters.Add(nazivJela);
                    cmd.Parameters.Add(vrsta);
                    cmd.Parameters.Add(cijena);

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
