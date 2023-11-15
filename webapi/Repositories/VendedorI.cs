using MongoDB.Bson;
using MongoDB.Driver;
using webapi.Models;

namespace webapi.Repositories
{
    public class VendedorI : IVendedor
    {
        private readonly IMongoCollection<Vendedor> _Vendedor;

        public VendedorI(IMongoClient client)
        {
            var database = client.GetDatabase("Vendedor");
            var collection = database.GetCollection<Vendedor>(nameof(Vendedor));

            _Vendedor = collection;
        }

        public async Task<ObjectId> Create(Vendedor Vendedor)
        {
            await _Vendedor.InsertOneAsync(Vendedor);

            return Vendedor.Id;
        }

        public Task<Vendedor> Get(ObjectId objectId)
        {
            var filter = Builders<Vendedor>.Filter.Eq(c => c.Id, objectId);
            var Vendedor = _Vendedor.Find(filter).FirstOrDefaultAsync();

            return Vendedor;
        }

        public async Task<IEnumerable<Vendedor>> Get()
        {
            var Cafeterias = await _Vendedor.Find(_ => true).ToListAsync();

            return Cafeterias;
        }

        public async Task<bool> Update(ObjectId objectId, Vendedor Vendedor)
        {
            var filter = Builders<Vendedor>.Filter.Eq(c => c.Id, objectId);
            var update = Builders<Vendedor>.Update
                .Set(c => c.Name, Vendedor.Name)
                .Set(c => c.Apellido, Vendedor.Apellido)
                .Set(c => c.Correo, Vendedor.Correo)
                .Set(c => c.Telefono, Vendedor.Telefono)
                .Set(c => c.CafeteriaId, Vendedor.CafeteriaId);
            var result = await _Vendedor.UpdateOneAsync(filter, update);

            return result.ModifiedCount == 1;
        }

        public async Task<bool> Delete(ObjectId objectId)
        {
            var filter = Builders<Vendedor>.Filter.Eq(c => c.Id, objectId);
            var result = await _Vendedor.DeleteOneAsync(filter);

            return result.DeletedCount == 1;
        }
    }
}
