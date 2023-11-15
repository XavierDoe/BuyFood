using MongoDB.Bson;

namespace webapi.Models;
public class Cliente
{
    public ObjectId Id { get; set; }
    public string? Name { get; set; }
    public string? Correo { get; set; }
    public long Telefono { get; set; }
    public string IdCliente => IdVac(Id);
    public String IdVac(ObjectId id)
    {
        return id.ToString();
    }
}
