using Microsoft.EntityFrameworkCore;

namespace webapi.Models;
    public class ProductoContext : DbContext {
        public ProductoContext(DbContextOptions<ProductoContext> options)
            : base(options)
        {
        }
        public DbSet<Producto> TodoProductos { get; set; } = null!;
    }
