using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

public class Customer
{
    public int Id { get; set; }
    public string Name { get; set; }

    public virtual ICollection<Order> Orders { get; set; }
        = new List<Order>();

    public virtual ICollection<Address> Addresses { get; set; }
        = new List<Address>();
}

public class Order
{
    public int Id { get; set; }
    public decimal Amount { get; set; }

    public int CustomerId { get; set; }

    public virtual Customer Customer { get; set; }
}

public class Address
{
    public int Id { get; set; }
    public string City { get; set; }

    public int CustomerId { get; set; }

    public virtual Customer Customer { get; set; }
}

public class AppDbContext : DbContext
{
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Address> Addresses { get; set; }

    protected override void OnConfiguring(
        DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(
            "Server=localhost;Database=EFCoreDemo;Trusted_Connection=True;TrustServerCertificate=True;"
        );
    }
}

class Program
{
    static async Task Main()
    {
        using AppDbContext context = new AppDbContext();

        // Read-only query:
        var readOnlyCustomers = await context.Customers
            .AsNoTracking()
            .ToListAsync();

        // Multiple collection Includes:
        var customers = await context.Customers
            .AsNoTracking()
            .Include(c => c.Orders)
            .Include(c => c.Addresses)
            .AsSplitQuery()
            .ToListAsync();

        foreach (var customer in customers)
        {
            System.Console.WriteLine(
                $"Customer: {customer.Name}");

            foreach (var order in customer.Orders)
            {
                System.Console.WriteLine(
                    $"Order: {order.Amount}");
            }

            foreach (var address in customer.Addresses)
            {
                System.Console.WriteLine(
                    $"Address: {address.City}");
            }
        }
    }
}
