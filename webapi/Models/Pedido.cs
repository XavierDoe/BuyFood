namespace webapi.Models;
public class Pedido
{
    public int Id { get; set; }
    public DateOnly FechaCompra {  get; set; }
    public double Total { get; set; }
    public int IdCafeteria { get; set; }
    public int IdCliente { get; set; }
    public int IdVendedor { get; set; }
}
