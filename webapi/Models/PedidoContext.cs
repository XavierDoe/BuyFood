using Microsoft.EntityFrameworkCore;

namespace webapi.Models;
public class PedidoContext : DbContext
{
    public PedidoContext(DbContextOptions<PedidoContext> options) : base(options) { }
    public DbSet<Pedido> Pedidos { get; set; } = null!;
}