using Microsoft.EntityFrameworkCore;
using FreezerInventory.Models;

namespace FreezerInventory.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) { }

    public DbSet<FreezerItem> FreezerItems => Set<FreezerItem>();
}