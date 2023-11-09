using Microsoft.EntityFrameworkCore;

namespace webapi.Models;
public class CafeteriaContext : DbContext
{
    public CafeteriaContext(DbContextOptions<CafeteriaContext> options) : base(options) { }
    public DbSet<Cafeteria> Cafeterias { get; set; } = null!;
}
