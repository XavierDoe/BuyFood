using MongoDB.Bson;

namespace webapi.Models;

public class Factura
{
    public ObjectId Id { get; set; }
    public DateOnly fechaVenta { get; set; }
    public string? nombreCliente { get; set; }
    public string? IdCafeteria { get; set; }
    public string? IdPedido { get; set; }
    public string? estado { get; set; }
    public string IdFactura => IdVac(Id);
    public String IdVac(ObjectId id)
    {
        return id.ToString();
    }
}
