using MongoDB.Driver;

namespace Catalogo_Clientes.ConnectDB
{
    public class ConnectionDB
    {
        private readonly IConfiguration configuration;

        public ConnectionDB(IConfiguration _configuration)
        {
            configuration = _configuration;

        }

        public IMongoDatabase isConnected()
        {
            try
            {
                string connect = configuration.GetConnectionString("MongoDbConnect");
                var client = new MongoClient(connect);
                var db_clientes = client.GetDatabase("clients");
                return db_clientes;
            }
            catch (Exception ex)
            {
                return null;
            }
                       
        }

    }
}
