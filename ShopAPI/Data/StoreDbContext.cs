using System;
using System.Collections.Generic;
using System.Data.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;


namespace ShopAPI.Data;

public partial class StoreDbContext : IdentityDbContext<APIUser>
{
    public StoreDbContext()
    {
    }

    public StoreDbContext(DbContextOptions<StoreDbContext> options)
        : base(options)
    {
        
    }

    public virtual Microsoft.EntityFrameworkCore.DbSet<Authors> Authors { get; set; } = null!;
    public virtual Microsoft.EntityFrameworkCore.DbSet<Books> Books { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Authors>(entity =>
        {
            entity.Property(e => e.Bio).HasMaxLength(250);

            entity.Property(e => e.FirstName).HasMaxLength(50);

            entity.Property(e => e.LastName).HasMaxLength(50);
        });

        modelBuilder.Entity<Books>(entity =>
        {
            entity.HasIndex(e => e.Isbn, "UQ__Books__447D36EA09FAB742")
                .IsUnique();

            entity.Property(e => e.Image).HasMaxLength(50);

            entity.Property(e => e.Isbn)
                .HasMaxLength(50)
                .HasColumnName("ISBN");

            entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");

            entity.Property(e => e.Summary).HasMaxLength(250);

            entity.Property(e => e.Title).HasMaxLength(50);

            entity.HasOne(d => d.Author)
                .WithMany(p => p.Books)
                .HasForeignKey(d => d.AuthorId)
                .HasConstraintName("FK_Books_ToTable");
        });

        modelBuilder.Entity<IdentityRole>().HasData(
            new IdentityRole
            {
                Name ="user",
                NormalizedName ="USER",
                Id = "ae42a2b3-5943-4f71-88b2-0f41575f266c"
            },
            new IdentityRole
            {
                Name = "Administrator",
                NormalizedName = "ADMINISTRATOR",
                Id = "9fc6668e-0dbe-41f8-b30c-9faa3825bfcb"
            }
            );

        var hasher = new PasswordHasher<APIUser>();

        modelBuilder.Entity<APIUser>().HasData(
    new APIUser
    {

        Id = "ae42a2b3-5943-4f71-88b2-0f41575f266c",
        Email = "admin@admin.com",
        NormalizedEmail = "ADMIN@ADMIN.COM",
        UserName = "admin@admin.com",
        NormalizedUserName = "ADMIN@ADMIN.COM",
        FirstName = "System",
        LastName = "Admin",
        PasswordHash = hasher.HashPassword(null, "Password")
    },
    new APIUser
    {
        Id = "008614fd-3840-4c98-b99e-03d69e677483",
        Email = "user@user.com",
        NormalizedEmail = "USER@USER.COM",
        UserName = "user@user.com",
        NormalizedUserName = "USER@USER.COM",
        FirstName = "System",
        LastName = "User",
        PasswordHash = hasher.HashPassword(null, "Password")
    }
    );

        modelBuilder.Entity < IdentityUserRole<string>>().HasData(
            new IdentityUserRole<string>
            {
                RoleId = "ae42a2b3-5943-4f71-88b2-0f41575f266c",
                UserId = "008614fd-3840-4c98-b99e-03d69e677483"
            },

            new IdentityUserRole<string>
            {
                RoleId= "9fc6668e-0dbe-41f8-b30c-9faa3825bfcb",
                UserId= "ae42a2b3-5943-4f71-88b2-0f41575f266c"
            }

            );

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}