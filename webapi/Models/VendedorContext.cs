using Microsoft.EntityFrameworkCore;

namespace webapi.Models;
public class VendedorContext : DbContext
{
    public VendedorContext(DbContextOptions<VendedorContext> options) : base(options) { }
    public DbSet<Vendedor> Vendedores { get; set; } = null!;
}