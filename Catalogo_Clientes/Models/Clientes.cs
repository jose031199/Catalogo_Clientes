using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Catalogo_Clientes.Models
{
    public class Clientes
    {
        [BsonRepresentation(BsonType.ObjectId)]

        public string _id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
    }
}
