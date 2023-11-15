using MongoDB.Bson;

namespace webapi.Models;
public class Vendedor
{
    public ObjectId Id { get; set; }
    public string? Name { get; set; }
    public string? Apellido { get; set; }
    public string? Correo { get; set; }
    public long Telefono { get; set; }
    public string? CafeteriaId { get; set; }
    public string IdVendedor => IdVac(Id);
    public String IdVac(ObjectId id)
    {
        return id.ToString();
    }
}
