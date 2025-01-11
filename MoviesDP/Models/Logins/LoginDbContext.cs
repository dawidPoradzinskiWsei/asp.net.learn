using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

public class LoginDbContext : IdentityDbContext<IdentityUser>
{

    public LoginDbContext(DbContextOptions<LoginDbContext> options) : base(options)
    {
        
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.ConfigureWarnings(warnings => warnings.Ignore(RelationalEventId.PendingModelChangesWarning));
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
            
    }
}