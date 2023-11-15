using MongoDB.Bson;
using webapi.Models;

namespace webapi.Repositories
{
    public interface ICliente
    {
        // Create
        Task<ObjectId> Create(Cliente Student);

        // Read
        Task<Cliente> Get(ObjectId objectId);
        Task<IEnumerable<Cliente>> Get();

        // Update
        Task<bool> Update(ObjectId objectId, Cliente Student);

        // Delete
        Task<bool> Delete(ObjectId objectId);
    }
}
