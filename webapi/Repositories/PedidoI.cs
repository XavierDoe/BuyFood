using MongoDB.Bson;
using MongoDB.Driver;
using webapi.Models;

namespace webapi.Repositories
{
    public class PedidoI : IPedido
    {
        private readonly IMongoCollection<Pedido> _Pedido;

        public PedidoI(IMongoClient client)
        {
            var database = client.GetDatabase("Pedido");
            var collection = database.GetCollection<Pedido>(nameof(Pedido));

            _Pedido = collection;
        }

        public async Task<ObjectId> Create(Pedido Pedido)
        {
            await _Pedido.InsertOneAsync(Pedido);

            return Pedido.Id;
        }

        public Task<Pedido> Get(ObjectId objectId)
        {
            var filter = Builders<Pedido>.Filter.Eq(c => c.Id, objectId);
            var Pedido = _Pedido.Find(filter).FirstOrDefaultAsync();

            return Pedido;
        }

        public async Task<IEnumerable<Pedido>> Get()
        {
            var Cafeterias = await _Pedido.Find(_ => true).ToListAsync();

            return Cafeterias;
        }

        public async Task<bool> Update(ObjectId objectId, Pedido Pedido)
        {
            var filter = Builders<Pedido>.Filter.Eq(c => c.Id, objectId);
            var update = Builders<Pedido>.Update
                .Set(c => c.FechaCompra, Pedido.FechaCompra)
                .Set(c => c.IdCafeteria, Pedido.IdCafeteria)
                .Set(c => c.IdCliente, Pedido.IdCliente)
                .Set(c => c.IdProducto, Pedido.IdProducto)
                .Set(c => c.estado, Pedido.estado)
                .Set(c => c.IdVendedor, Pedido.IdVendedor)
                .Set(c => c.Total, Pedido.Total);
            var result = await _Pedido.UpdateOneAsync(filter, update);

            return result.ModifiedCount == 1;
        }

        public async Task<bool> Delete(ObjectId objectId)
        {
            var filter = Builders<Pedido>.Filter.Eq(c => c.Id, objectId);
            var result = await _Pedido.DeleteOneAsync(filter);

            return result.DeletedCount == 1;
        }
    }
}
