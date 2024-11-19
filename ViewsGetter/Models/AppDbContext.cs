using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

public class AppDbContext : IdentityDbContext<IdentityUser>
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

        base.OnModelCreating(modelBuilder);

        string ADMIN_ID = Guid.NewGuid().ToString();
        string ADMIN_ROLE_ID = Guid.NewGuid().ToString();
        string USER_ID = Guid.NewGuid().ToString();
        string USER_ROLE_ID = Guid.NewGuid().ToString();

        modelBuilder.Entity<IdentityRole>()
        .HasData(
            new IdentityRole()
            {
                Id = ADMIN_ROLE_ID,
                Name = "admin",
                NormalizedName = "ADMIN",
                ConcurrencyStamp = ADMIN_ROLE_ID
            },
            new IdentityRole()
            {
                Id = USER_ROLE_ID,
                Name = "user",
                NormalizedName = "USER",
                ConcurrencyStamp = USER_ROLE_ID
            }
        );

        var admin = new IdentityUser()
        {
            Id = ADMIN_ID,
            Email = "admin@wsei.edu.pl",
            NormalizedEmail = "admin@wsei.edu.pl".ToUpper(),
            UserName = "admin",
            NormalizedUserName = "admin".ToUpper(), 
            EmailConfirmed = true
        };

        var user = new IdentityUser()
        {
            Id = USER_ID,
            Email = "user0@wsei.edu.pl",
            NormalizedEmail = "user0@wsei.edu.pl".ToUpper(),
            UserName = "user0",
            NormalizedUserName = "user0".ToUpper(), 
            EmailConfirmed = true
        };

        PasswordHasher<IdentityUser> hasher = new PasswordHasher<IdentityUser>();
        admin.PasswordHash = hasher.HashPassword(admin, "1234!");
        user.PasswordHash = hasher.HashPassword(user, "1234!");


        modelBuilder.Entity<IdentityUser>()
        .HasData(
            admin,user
        );
        modelBuilder.Entity<IdentityUserRole<string>>()
        .HasData(
            new Microsoft.AspNetCore.Identity.IdentityUserRole<string>()
            {
                RoleId = USER_ROLE_ID,
                UserId = admin.Id,
            },
            new Microsoft.AspNetCore.Identity.IdentityUserRole<string>()
            {
                RoleId = ADMIN_ROLE_ID,
                UserId = admin.Id,
            },
            new Microsoft.AspNetCore.Identity.IdentityUserRole<string>()
            {
                RoleId = USER_ROLE_ID,
                UserId = user.Id,
            }
        );

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