using MongoDB.Bson;
using MongoDB.Driver;
using webapi.Models;

namespace webapi.Repositories
{
    public class CafeteriaI : ICafeteria
    {
        private readonly IMongoCollection<Cafeteria> _Cafeteria;

        public CafeteriaI(IMongoClient client)
        {
            var database = client.GetDatabase("CafeteriaDB");
            var collection = database.GetCollection<Cafeteria>(nameof(Cafeteria));

            _Cafeteria = collection;
        }

        public async Task<ObjectId> Create(Cafeteria Cafeteria)
        {
            await _Cafeteria.InsertOneAsync(Cafeteria);

            return Cafeteria.Id;
        }

        public Task<Cafeteria> Get(ObjectId objectId)
        {
            var filter = Builders<Cafeteria>.Filter.Eq(c => c.Id, objectId);
            var Cafeteria = _Cafeteria.Find(filter).FirstOrDefaultAsync();

            return Cafeteria;
        }

        public async Task<IEnumerable<Cafeteria>> Get()
        {
            var Cafeterias = await _Cafeteria.Find(_ => true).ToListAsync();

            return Cafeterias;
        }

        public async Task<bool> Update(ObjectId objectId, Cafeteria Cafeteria)
        {
            var filter = Builders<Cafeteria>.Filter.Eq(c => c.Id, objectId);
            var update = Builders<Cafeteria>.Update
                .Set(c => c.Name, Cafeteria.Name)
                .Set(c => c.Correo, Cafeteria.Correo)
                .Set(c => c.AdminId, Cafeteria.AdminId);
            var result = await _Cafeteria.UpdateOneAsync(filter, update);

            return result.ModifiedCount == 1;
        }

        public async Task<bool> Delete(ObjectId objectId)
        {
            var filter = Builders<Cafeteria>.Filter.Eq(c => c.Id, objectId);
            var result = await _Cafeteria.DeleteOneAsync(filter);

            return result.DeletedCount == 1;
        }
    }
}
