namespace webapi.Models;

public class Producto
{
    public int Id { get; set; }
    public int IdCafeteria { get; set; }
    public string Name { get; set; }
    public string Imagen { get; set; }
    public string Descripcpion { get; set; }
    public double Precio { get; set; }
    public int Cantidad { get; set; }
    public Boolean Disponible { get; set; } = true;
}
