using MongoDB.Bson;
using webapi.Models;

namespace webapi.Repositories
{
    public interface IPedido
    {
        // Create
        Task<ObjectId> Create(Pedido Student);

        // Read
        Task<Pedido> Get(ObjectId objectId);
        Task<IEnumerable<Pedido>> Get();

        // Update
        Task<bool> Update(ObjectId objectId, Pedido Student);

        // Delete
        Task<bool> Delete(ObjectId objectId);
    }
}
