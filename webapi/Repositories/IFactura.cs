using MongoDB.Bson;
using webapi.Models;

namespace webapi.Repositories
{
    public interface IFactura
    {
        // Create
        Task<ObjectId> Create(Factura Student);

        // Read
        Task<Factura> Get(ObjectId objectId);
        Task<IEnumerable<Factura>> Get();

        // Update
        Task<bool> Update(ObjectId objectId, Factura Student);

        // Delete
        Task<bool> Delete(ObjectId objectId);
    }
}
