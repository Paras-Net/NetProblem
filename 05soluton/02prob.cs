using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

public class Customer
{
    public int Id { get; set; }
    public string Name { get; set; }
    public bool IsDeleted { get; set; }

    public virtual ICollection<Order> Orders { get; set; }
        = new List<Order>();
}

public class Order
{
    public int Id { get; set; }
    public decimal Amount { get; set; }
    public int CustomerId { get; set; }

    public virtual Customer Customer { get; set; }
}

public class AppDbContext : DbContext
{
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Order> Orders { get; set; }

    protected override void OnConfiguring(
        DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(
            "Server=localhost;Database=EFCoreDemo;Trusted_Connection=True;TrustServerCertificate=True;"
        );
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>()
            .HasQueryFilter(c => !c.IsDeleted);
    }
}

class Program
{
    static async Task Main()
    {
        using AppDbContext context = new AppDbContext();

        // Only non-deleted customers are returned.
        var customers = await context.Customers
            .ToListAsync();

        // Soft delete example.
        Customer customer = await context.Customers
            .FirstAsync(c => c.Id == 1);

        customer.IsDeleted = true;

        await context.SaveChangesAsync();

        // Get all customers, including soft-deleted records.
        var allCustomers = await context.Customers
            .IgnoreQueryFilters()
            .ToListAsync();
    }
}
