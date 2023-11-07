namespace webapi.Models;

public class Factura
{
    public int Id { get; set; }
    public DateOnly fechaVenta { get; set; }
    public string? nombreCliente { get; set; }
    public int IdProducto { get; set; }
    public int IdCafeteria { get; set; }
    public int IdPedido { get; set; }

}
