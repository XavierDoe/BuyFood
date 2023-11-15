using MongoDB.Bson;
using MongoDB.Driver;
using webapi.Models;

namespace webapi.Repositories
{
    public class ProductoI : IProducto
    {
        private readonly IMongoCollection<Producto> _Producto;

        public ProductoI(IMongoClient client)
        {
            var database = client.GetDatabase("Producto");
            var collection = database.GetCollection<Producto>(nameof(Producto));

            _Producto = collection;
        }

        public async Task<ObjectId> Create(Producto Producto)
        {
            await _Producto.InsertOneAsync(Producto);

            return Producto.Id;
        }

        public Task<Producto> Get(ObjectId objectId)
        {
            var filter = Builders<Producto>.Filter.Eq(c => c.Id, objectId);
            var Producto = _Producto.Find(filter).FirstOrDefaultAsync();

            return Producto;
        }

        public async Task<IEnumerable<Producto>> Get()
        {
            var Cafeterias = await _Producto.Find(_ => true).ToListAsync();

            return Cafeterias;
        }

        public async Task<bool> Update(ObjectId objectId, Producto Producto)
        {
            var filter = Builders<Producto>.Filter.Eq(c => c.Id, objectId);
            var update = Builders<Producto>.Update
                .Set(c => c.Name, Producto.Name)
                .Set(c => c.Imagen, Producto.Imagen)
                .Set(c => c.Descripcpion, Producto.Descripcpion)
                .Set(c => c.Precio, Producto.Precio)
                .Set(c => c.Cantidad, Producto.Cantidad)
                .Set(c => c.Disponible, Producto.Disponible);
            var result = await _Producto.UpdateOneAsync(filter, update);

            return result.ModifiedCount == 1;
        }

        public async Task<bool> Delete(ObjectId objectId)
        {
            var filter = Builders<Producto>.Filter.Eq(c => c.Id, objectId);
            var result = await _Producto.DeleteOneAsync(filter);

            return result.DeletedCount == 1;
        }
    }
}
