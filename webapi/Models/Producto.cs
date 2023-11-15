using MongoDB.Bson;

namespace webapi.Models;

public class Producto
{
    public ObjectId Id { get; set; }
    public string? IdCafeteria { get; set; }
    public string? Name { get; set; }
    public string? Imagen { get; set; }
    public string? Descripcpion { get; set; }
    public double Precio { get; set; }
    public int Cantidad { get; set; }
    public Boolean Disponible { get; set; } = true;
    public string IdProducto => IdVac(Id);
    public String IdVac(ObjectId id)
    {
        return id.ToString();
    }
}