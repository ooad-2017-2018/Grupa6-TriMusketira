using System;

namespace ProjekatGurmani1.DB
{
    public class DBConnectionString
    {
        private String s;
        public DBConnectionString()
        {
            s = "Server = tcp: gurmaniserver.database.windows.net,1433; Initial Catalog = GurmaniBaza; Persist Security Info = False; User ID = gurmaniadmin; Password = ProjekatGurmani1; MultipleActiveResultSets = False; Encrypt = True; TrustServerCertificate = False; Connection Timeout = 30;";
        }
        public String GetString() { return s; }
    }
}