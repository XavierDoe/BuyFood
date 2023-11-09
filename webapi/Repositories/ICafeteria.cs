using MongoDB.Bson;
using webapi.Models;

namespace webapi.Repositories
{
    public interface ICafeteria
    {
        // Create
        Task<ObjectId> Create(Cafeteria Student);

        // Read
        Task<Cafeteria> Get(ObjectId objectId);

        // Update
        Task<bool> Update(ObjectId objectId, Cafeteria Student);

        // Delete
        Task<bool> Delete(ObjectId objectId);
    }
}
