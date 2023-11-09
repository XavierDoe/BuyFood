namespace webapi.Models;
public class Vendedor
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Apellido { get; set; }
    public string? Correo { get; set; }
    public long Telefono { get; set; }
    public int CafeteriaId { get; set; }
}
