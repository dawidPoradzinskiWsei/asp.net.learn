using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public DbSet<ComputerEntity> Computers {get; set;}
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
                Created = DateTime.Now
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
                Created = DateTime.Now
            }
        );
    }
}