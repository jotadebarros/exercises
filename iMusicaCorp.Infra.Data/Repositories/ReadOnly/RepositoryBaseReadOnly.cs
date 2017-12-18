using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace iMusicaCorp.Infra.Data.Repositories.ReadOnly
{
    public class RepositoryBaseReadOnly
    {
        public IDbConnection Connection
        {
            get
            {
                return new SqlConnection(ConfigurationManager.ConnectionStrings["iMusicaCorp"].ConnectionString);
            }
        }

        public void ClearPoolConnection(IDbConnection cn)
        {
            SqlConnection.ClearPool((SqlConnection)cn);
        }
    }
}
