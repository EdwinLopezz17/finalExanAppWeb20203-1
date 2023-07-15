using Microsoft.EntityFrameworkCore;
using si730ebu20201b051.Infraestructure.Models;

namespace si730ebu20201b051.Infraestructure.Context;

public class U20201b051DBContext: DbContext
{
    public U20201b051DBContext()
    {
        
    }
    public U20201b051DBContext(DbContextOptions<U20201b051DBContext> options) : base(options)
    {
    }
    
    public DbSet<Product> Products { get; set; }
    public DbSet<MaintenanceActivity> MaintenanceActivities{ get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            var serverVersion = new MySqlServerVersion(new Version(8, 0, 29));
            optionsBuilder.UseMySql("Server=127.0.0.1,3306;Uid=root;Pwd=UPC@intranet_17;Database=isa", serverVersion);
        }
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<Product>().ToTable("products");
        builder.Entity<Product>().HasKey(p => p.id);
        builder.Entity<Product>().Property(p => p.id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Product>().Property(p => p.serialNumber).IsRequired();
        builder.Entity<Product>().Property(p => p.brand).IsRequired();
        builder.Entity<Product>().Property(p => p.model).IsRequired();
        builder.Entity<Product>().Property(p => p.status).IsRequired();
        
        
        builder.Entity<MaintenanceActivity>().ToTable("maintenanceActivities");
        builder.Entity<MaintenanceActivity>().HasKey(s => s.id);
        builder.Entity<MaintenanceActivity>().Property(s => s.id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<MaintenanceActivity>().Property(s => s.productSerialNumber).IsRequired();
        builder.Entity<MaintenanceActivity>().Property(s => s.summary).IsRequired();
        builder.Entity<MaintenanceActivity>().Property(s => s.activityResult).IsRequired();
        
    }
}