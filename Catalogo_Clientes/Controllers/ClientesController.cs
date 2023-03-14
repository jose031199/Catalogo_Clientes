using Catalogo_Clientes.ConnectDB;
using Catalogo_Clientes.Models;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Catalogo_Clientes.Controllers
{
    public class ClientesController : Controller
    {
        private readonly IConfiguration configuration;
        ConnectionDB client;
        public ClientesController(IConfiguration _configuration) { 
            configuration = _configuration;
        }
        public IActionResult Index()
        {
            client = new ConnectionDB(configuration);
            IMongoDatabase db = client.isConnected();
            List<Clientes> clients = null;

            if (db!=null)
            {
              clients = db.GetCollection<Clientes>("cliente").Find(new BsonDocument()).SortBy(e => e.Name).ToList(); // Metohd to return clients
            }

            return View(clients);
        }

        
        public ActionResult Delete(string id)
        {
            client = new ConnectionDB(configuration);
            IMongoDatabase db = client.isConnected();
            

            if (db != null)
            {
                var collection = db.GetCollection<Clientes>("cliente");
                var DeleteRecored = collection.DeleteOneAsync(
                       Builders<Clientes>.Filter.Eq("_id", id));
                return RedirectToAction("Index");
            }

            return View();
        }




        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Clientes clientes)
        {
            client = new ConnectionDB(configuration);
            IMongoDatabase db = client.isConnected();

            if (db!=null && clientes.Name!=null && clientes.Address!=null)
            {
                var collection = db.GetCollection<Clientes>("cliente");
                collection.InsertOneAsync(clientes);
                return RedirectToAction("Index");
            }


            return View();
        }
    }
}
