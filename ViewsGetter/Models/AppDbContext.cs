using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public DbSet<ComputerEntity> Computers {get; set;}
    public DbSet<OrganzationEntity> Organizations {get;set;}
    private string DbPath {get;set;}

    public AppDbContext()
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = Path.Join(path, "contacts.db");
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

        optionsBuilder.UseSqlite($"Data source={DbPath}");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder) 
    {

        modelBuilder.Entity<ComputerEntity>()
        .HasOne<OrganzationEntity>(c => c.Organzation)
        .WithMany(c => c.Computer)
        .HasForeignKey(c => c.OrganzationId);

        modelBuilder.Entity<OrganzationEntity>()
        .ToTable("Organizations")
        .HasData(
            new OrganzationEntity()
            {
                Id = 101,
                Name = "XKOM",
                NIP = "2131212",
                REGON = "2984395734"
            },
            new OrganzationEntity()
            {
                Id = 102,
                Name = "MORELE",
                NIP = "4353443",
                REGON = "11123395734"
            }
        );

        modelBuilder.Entity<OrganzationEntity>()
        .OwnsOne(o => o.Address)
        .HasData(
            new { City = "Krakow", Street = "Kurczakow", OrganzationEntityId = 101},
            // OrganizationEntity + Id
            new { City = "Krakow", Street = "Centralna", OrganzationEntityId = 102}
        );

        modelBuilder.Entity<ComputerEntity>().HasData(
            new ComputerEntity()
            {
                Id = 1,
                Name = "SuperPc",
                Processor = "i5-12400",
                Gpu = "RTX4070Super",
                Producer="Asus",
                RamGB=16,
                YearOfProduction = DateTime.Now,
                Category = Category.games,
                Created = DateTime.Now,
                OrganzationId = 101
            },
            new ComputerEntity()
            {
                Id = 2,
                Name = "SuperPc",
                Processor = "i5-12400",
                Gpu = "RTX4070Super",
                Producer="Asus",
                RamGB=16,
                YearOfProduction = DateTime.Now,
                Category = Category.games,
                Created = DateTime.Now,
                OrganzationId = 102
            }
        );
    }
}