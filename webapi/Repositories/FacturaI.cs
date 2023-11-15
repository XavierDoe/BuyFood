using MongoDB.Bson;
using MongoDB.Driver;
using webapi.Models;

namespace webapi.Repositories
{
    public class FacturaI : IFactura
    {
        private readonly IMongoCollection<Factura> _Factura;

        public FacturaI(IMongoClient client)
        {
            var database = client.GetDatabase("Factura");
            var collection = database.GetCollection<Factura>(nameof(Factura));

            _Factura = collection;
        }

        public async Task<ObjectId> Create(Factura Factura)
        {
            await _Factura.InsertOneAsync(Factura);

            return Factura.Id;
        }

        public Task<Factura> Get(ObjectId objectId)
        {
            var filter = Builders<Factura>.Filter.Eq(c => c.Id, objectId);
            var Factura = _Factura.Find(filter).FirstOrDefaultAsync();

            return Factura;
        }

        public async Task<IEnumerable<Factura>> Get()
        {
            var Cafeterias = await _Factura.Find(_ => true).ToListAsync();

            return Cafeterias;
        }

        public async Task<bool> Update(ObjectId objectId, Factura Factura)
        {
            var filter = Builders<Factura>.Filter.Eq(c => c.Id, objectId);
            var update = Builders<Factura>.Update
                .Set(c => c.fechaVenta, Factura.fechaVenta)
                .Set(c => c.nombreCliente, Factura.nombreCliente)
                .Set(c => c.IdProducto, Factura.IdProducto)
                .Set(c => c.IdCafeteria, Factura.IdCafeteria)
                .Set(c => c.IdPedido, Factura.IdPedido);
            var result = await _Factura.UpdateOneAsync(filter, update);

            return result.ModifiedCount == 1;
        }

        public async Task<bool> Delete(ObjectId objectId)
        {
            var filter = Builders<Factura>.Filter.Eq(c => c.Id, objectId);
            var result = await _Factura.DeleteOneAsync(filter);

            return result.DeletedCount == 1;
        }
    }
}
