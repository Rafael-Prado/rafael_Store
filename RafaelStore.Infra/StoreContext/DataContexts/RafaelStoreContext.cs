using RafaelStore.Shared;
using System;
using System.Data.SqlClient;

namespace RafaelStore.Infra.Datacontexts
{
    public class RafaelStoreContext: IDisposable
    {
        public SqlConnection Connection { get; set; }

        public RafaelStoreContext()
        {
            Connection = new SqlConnection(Settings.ConnectionString);
            Connection.Open();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
