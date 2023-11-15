using MongoDB.Bson;

namespace webapi.Models;

public class Cafeteria
{
    public ObjectId Id { get; set; }
    public string? Name { get; set; }
    public string? AdminId { get; set; }
    public string IdCafeteria => IdVac(Id);
    public String IdVac(ObjectId id)
    {
        return id.ToString();
    }
}