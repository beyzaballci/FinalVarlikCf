using FinalVarlikCf.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
namespace FinalVarlikCf.Data;



public class MyDbContext : DbContext
{
    /*
    public MyDbContext(DbContextOptions options) : base(options)
    {

    }*/

    public DbSet<Asset> Assets { get; set; }
    public DbSet<AssetDoc> AssetDocs { get; set; }
    public DbSet<AssetGroup> AssetGroups { get; set; }
    public DbSet<AssetSlip> AssetSlips { get; set; }
    public DbSet<AssetLog> AssetLogs { get; set; }
    public DbSet<AssetTransaction> AssetTransaction { get; set; }
    public DbSet<Company> Companies { get; set; }
    public DbSet<CountPlan> CountPlans { get; set; }
    public DbSet<CountSlip> CountSlips { get; set; }
    public DbSet<CountTran> CountTrans { get; set; }
    public DbSet<Department> Departments { get; set; }
    public DbSet<Location> Locations { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //// Fluent API ayarlarını buraya yazarsın
        //base.OnModelCreating(modelBuilder);      // bu kısım ne işe yarıyor?

        //Cascade mantığı-> Silindiğinde bağlı kayıtlar da silinir ( parent -> child)
        //Restrick-> Silinemez, önce bağlı kayıt silinmeli 

        // Asset - Company 
        modelBuilder.Entity<Asset>()
            .HasOne(a => a.Company)
            .WithMany(c => c.Assets)
            .HasForeignKey(a => a.CompanyId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Asset>()
            .HasOne(a => a.Location)
            .WithMany(l => l.Assets)
            .HasForeignKey(a => a.LocationId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Asset>()
            .HasOne(a => a.Department)
            .WithMany(d => d.Assets) // Bir Department, birden çok Asset’e sahiptir
            .HasForeignKey(a => a.DepartmentId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Asset>()
            .HasOne(a => a.AssetGroup)
            .WithMany(ag => ag.Assets)
            .HasForeignKey(a => a.AssetGroupId)
            .OnDelete(DeleteBehavior.Restrict);

        // Asset - AssetDoc 
        modelBuilder.Entity<AssetDoc>()
            .HasOne(ad => ad.Asset)
            .WithMany(a => a.AssetDocs)
            .HasForeignKey(ad => ad.AssetId)
            .OnDelete(DeleteBehavior.Cascade);
      

        modelBuilder.Entity<AssetLog>()
            .HasOne(al => al.Asset)
            .WithMany(a => a.AssetLogs)
            .HasForeignKey(al => al.AssetId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<AssetTransaction>()
            .HasOne(at => at.Asset)
            .WithMany(a => a.AssetTransactions)
            .HasForeignKey(at => at.AssetId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<AssetTransaction>()
            .HasOne(at => at.AssetSlip)
            .WithMany(s => s.AssetTransactions)
            .HasForeignKey(at => at.SlipId)
            .OnDelete(DeleteBehavior.Restrict); // Multiple cascade'den kaçınmak için

        modelBuilder.Entity<AssetSlip>()
            .HasOne(s => s.Company)
            .WithMany(c => c.AssetSlips)
            .HasForeignKey(s => s.CompanyId)
            .OnDelete(DeleteBehavior.Restrict);

        // COUNT ilişkileri
        modelBuilder.Entity<CountPlan>()
            .HasOne(cp => cp.Location)
            .WithMany(l => l.CountPlans)
            .HasForeignKey(cp => cp.LocationId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<CountSlip>()
            .HasOne(cs => cs.CountPlan)
            .WithMany(cp => cp.CountSlips)
            .HasForeignKey(cs => cs.CountPlanId)
            .OnDelete(DeleteBehavior.Restrict); // üstten cascade verme

        modelBuilder.Entity<CountSlip>()
            .HasOne(cs => cs.Location)
            .WithMany(l => l.CountSlips)
            .HasForeignKey(cs => cs.LocationId)// önceki halinde Location yazmıştım
            .OnDelete(DeleteBehavior.Restrict); // çünkü Location birçok yere bağlı
        ////  CountSlip - Location (Restrict) → Multiple Cascade Path önler
        ////[Location]        →  CountSlip      →  CountTran bunların hepsinin cascade olmasını ms desteklemiyormuş


        modelBuilder.Entity<CountTran>()
            .HasOne(ct => ct.CountSlip)
            .WithMany(cs => cs.CountTrans)
            .HasForeignKey(ct => ct.CountSlipId)
            .OnDelete(DeleteBehavior.Cascade); // sadece burası cascade

        modelBuilder.Entity<CountTran>()
            .HasOne(ct => ct.Asset)
            .WithMany(a => a.CountTrans)
            .HasForeignKey(ct => ct.AssetId)
            .OnDelete(DeleteBehavior.Restrict);

        base.OnModelCreating(modelBuilder);

    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=NA05920;Database=FinalVarlikCfDb;Trusted_Connection=True;TrustServerCertificate=True;");
    }



    //protected MyDbContext()
    //{
    //}
}
