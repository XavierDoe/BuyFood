using Microsoft.EntityFrameworkCore;

namespace webapi.Models;

public class FacturaContext : DbContext
{
    public FacturaContext(DbContextOptions<FacturaContext> options) : base(options) { }
    public DbSet<Factura> TodoFacturas { get; set; } = null!;
}
