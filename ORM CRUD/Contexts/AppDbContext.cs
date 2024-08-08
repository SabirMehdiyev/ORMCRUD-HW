using Microsoft.EntityFrameworkCore;
using ORM_CRUD.Models;

namespace ORM_CRUD.Contexts;

public class AppDbContext : DbContext
{
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var connectionString = "Server=DESKTOP-OP8UPED\\TESTSERVER2;Database=ORMCRUD-HW;Trusted_Connection=True;MultipleActiveResultSets=true";
        optionsBuilder.UseSqlServer(connectionString);
    }
}


