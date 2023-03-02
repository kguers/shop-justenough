using JustEnough.Models;
using Microsoft.EntityFrameworkCore;


namespace JustEnough.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {

    }
    
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Purchase> Purchases { get; set; }
    public DbSet<PurchaseProduct> PurchaseProducts { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder) 
    {
        modelBuilder.Entity<Product>().Property(p => p.Price).HasColumnType("decimal(18,2)");
        modelBuilder.Entity<Product>().Property(p => p.Rating).HasColumnType("decimal(2,1)");
        modelBuilder.Entity<Purchase>().Property(p => p.Total).HasColumnType("decimal(18,2)");
        
        //Establish many-to-many relationship between purchases and products
        modelBuilder.Entity<PurchaseProduct>()
            .HasKey(pp => new {pp.PurchaseId, pp.ProductId});

        modelBuilder.Entity<PurchaseProduct>()
            .HasOne(p => p.Purchase)
            .WithMany(pp => pp.PurchaseProducts)
            .HasForeignKey(p => p.PurchaseId);

        modelBuilder.Entity<PurchaseProduct>()
            .HasOne(p => p.Product)
            .WithMany(pp => pp.PurchaseProducts)
            .HasForeignKey(p => p.ProductId);
    }
    
}