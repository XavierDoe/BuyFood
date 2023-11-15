using MongoDB.Bson;
using webapi.Models;

namespace webapi.Repositories
{
    public interface IVendedor
    {
        // Create
        Task<ObjectId> Create(Vendedor Student);

        // Read
        Task<Vendedor> Get(ObjectId objectId);
        Task<IEnumerable<Vendedor>> Get();

        // Update
        Task<bool> Update(ObjectId objectId, Vendedor Student);

        // Delete
        Task<bool> Delete(ObjectId objectId);
    }
}
