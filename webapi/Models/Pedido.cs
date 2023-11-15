using MongoDB.Bson;

namespace webapi.Models;
public class Pedido
{
    public ObjectId Id { get; set; }
    public DateOnly FechaCompra {  get; set; }
    public double Total { get; set; }
    public string? IdCafeteria { get; set; }
    public string? IdCliente { get; set; }
    public string? IdVendedor { get; set; }
    public string IdPedido => IdVac(Id);
    public String IdVac(ObjectId id)
    {
        return id.ToString();
    }
}
