using MongoDB.Bson;

namespace webapi.Models;

public class Cafeteria
{
    public ObjectId Id { get; set; }
    public string? Name { get; set; }
    public int AdminId { get; set; }
}