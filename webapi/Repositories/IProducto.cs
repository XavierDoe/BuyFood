using MongoDB.Bson;
using webapi.Models;

namespace webapi.Repositories
{
    public interface IProducto
    {
        // Create
        Task<ObjectId> Create(Producto Student);

        // Read
        Task<Producto> Get(ObjectId objectId);
        Task<IEnumerable<Producto>> Get();

        // Update
        Task<bool> Update(ObjectId objectId, Producto Student);

        // Delete
        Task<bool> Delete(ObjectId objectId);
    }
}
