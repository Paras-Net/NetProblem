using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

public class Customer
{
    public int Id { get; set; }
    public string Name { get; set; }

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
        optionsBuilder
            .UseSqlServer(
                "Server=localhost;Database=EFCoreDemo;Trusted_Connection=True;TrustServerCertificate=True;"
            )
            .UseLazyLoadingProxies();
    }
}

class Program
{
    static async Task Main()
    {
        using AppDbContext context = new AppDbContext();

        // EAGER LOADING
        var customers = await context.Customers
            .Include(c => c.Orders)
            .ToListAsync();

        foreach (var customer in customers)
        {
            Console.WriteLine("Customer: " + customer.Name);

            foreach (var order in customer.Orders)
            {
                Console.WriteLine("Order Amount: " + order.Amount);
            }
        }

        // EXPLICIT LOADING
        Customer customer = await context.Customers
            .FirstAsync(c => c.Id == 1);

        await context.Entry(customer)
            .Collection(c => c.Orders)
            .LoadAsync();

        foreach (var order in customer.Orders)
        {
            Console.WriteLine("Order Amount: " + order.Amount);
        }

        // LAZY LOADING
        var lazyCustomers = await context.Customers
            .ToListAsync();

        foreach (var lazyCustomer in lazyCustomers)
        {
            Console.WriteLine("Customer: " + lazyCustomer.Name);

            // Orders are loaded automatically when accessed.
            foreach (var order in lazyCustomer.Orders)
            {
                Console.WriteLine("Order Amount: " + order.Amount);
            }
        }
    }
}
