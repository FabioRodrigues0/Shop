namespace Shop.Server.Data;

  public class DataContext : DbContext
  {
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<Category>()
          .HasKey(c => new { c.Id});
      modelBuilder.Entity<Brand>()
        .HasKey(b => new { b.Id });
      modelBuilder.Entity<Tax>()
        .HasKey(t => new { t.Id });
      modelBuilder.Entity<User>()
        .HasKey(c => new { c.Id });
      modelBuilder.Entity<Cart>()
        .HasKey(sp => new { sp.Id });
      modelBuilder.Entity<CartItens>()
        .HasKey(spi => new { spi.Id });
      modelBuilder.Entity<Invoice>()
        .HasKey(i => new { i.Id });
      modelBuilder.Entity<InvoiceProduct>()
        .HasKey(ip => new { ip.Id });
      modelBuilder.Entity<ProductsView>()
        .HasNoKey()
        .ToView(nameof(ProductsView));
    }

    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Brand> Brands { get; set; }
    public DbSet<Tax> Taxes { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Cart> Cart { get; set; }
    public DbSet<CartItens> CartItens { get; set; }
    public DbSet<Invoice> Invoices { get; set; }
    public DbSet<InvoiceProduct> InvoiceProducts { get; set; }
    public virtual DbSet<ProductsView> ProductsView { get; set; }
}