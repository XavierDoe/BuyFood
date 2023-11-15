using MongoDB.Bson;
using MongoDB.Driver;
using webapi.Models;

namespace webapi.Repositories
{
    public class ClienteI : ICliente
    {
        private readonly IMongoCollection<Cliente> _Cliente;

        public ClienteI(IMongoClient client)
        {
            var database = client.GetDatabase("Cliente");
            var collection = database.GetCollection<Cliente>(nameof(Cliente));

            _Cliente = collection;
        }

        public async Task<ObjectId> Create(Cliente Cliente)
        {
            await _Cliente.InsertOneAsync(Cliente);

            return Cliente.Id;
        }

        public Task<Cliente> Get(ObjectId objectId)
        {
            var filter = Builders<Cliente>.Filter.Eq(c => c.Id, objectId);
            var Cliente = _Cliente.Find(filter).FirstOrDefaultAsync();

            return Cliente;
        }

        public async Task<IEnumerable<Cliente>> Get()
        {
            var Cafeterias = await _Cliente.Find(_ => true).ToListAsync();

            return Cafeterias;
        }

        public async Task<bool> Update(ObjectId objectId, Cliente Cliente)
        {
            var filter = Builders<Cliente>.Filter.Eq(c => c.Id, objectId);
            var update = Builders<Cliente>.Update
                .Set(c => c.Name, Cliente.Name)
                .Set(c => c.Telefono, Cliente.Telefono)
                .Set(c => c.Correo, Cliente.Correo);
            var result = await _Cliente.UpdateOneAsync(filter, update);

            return result.ModifiedCount == 1;
        }

        public async Task<bool> Delete(ObjectId objectId)
        {
            var filter = Builders<Cliente>.Filter.Eq(c => c.Id, objectId);
            var result = await _Cliente.DeleteOneAsync(filter);

            return result.DeletedCount == 1;
        }
    }
}
