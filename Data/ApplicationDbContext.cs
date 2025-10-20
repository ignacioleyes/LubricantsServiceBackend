using LubricantsServiceBackend.Entities;
using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<CarInformation> CarInformation { get; set; }
    public DbSet<CarServiceHistory> CarServiceHistory { get; set; }
    public DbSet<ServiceProductsUsed> ServiceProductsUsed { get; set; }
    public DbSet<Client> Client { get; set; }
    public DbSet<Employee> Employee { get; set; }
    public DbSet<Product> Product { get; set; }
    public DbSet<ProductType> ProductType { get; set; }
    public DbSet<Brand> Brand { get; set; }
    public DbSet<State> State { get; set; }
    public DbSet<Purchase> Purchase { get; set; }
    public DbSet<Appointment> Appointment { get; set; }
    public DbSet<Sale> Sale { get; set; }
    public DbSet<PayType> PayType { get; set; }
    public DbSet<PurchaseProduct> PurchaseProduct { get; set; }
    public DbSet<ApplicationUser> ApplicationUsers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Client>().ToTable("client");
        modelBuilder.Entity<CarInformation>().ToTable("car_information");
        modelBuilder.Entity<CarServiceHistory>().ToTable("car_service_history");
        modelBuilder.Entity<ServiceProductsUsed>().ToTable("service_products_used");
        modelBuilder.Entity<Employee>().ToTable("employee");
        modelBuilder.Entity<Product>().ToTable("product");
        modelBuilder.Entity<ProductType>().ToTable("product_type");
        modelBuilder.Entity<Brand>().ToTable("brand");
        modelBuilder.Entity<Appointment>().ToTable("appointment");
        modelBuilder.Entity<Purchase>().ToTable("purchase");
        modelBuilder.Entity<Sale>().ToTable("sale");
        modelBuilder.Entity<PayType>().ToTable("pay_type");
        modelBuilder.Entity<PurchaseProduct>().ToTable("purchase_product");
        modelBuilder.Entity<PurchaseProduct>()
            .HasOne(pp => pp.Purchase)
            .WithMany(p => p.PurchaseProducts)
            .HasForeignKey(pp => pp.PurchaseId);
        modelBuilder.Entity<PurchaseProduct>()
            .HasOne(pp => pp.Product)
            .WithMany(p => p.PurchaseProducts)
            .HasForeignKey(pp => pp.ProductId);
    }
}