using MediaCatalog.DataAccess.Conventions;
using MediaCatalog.Domain;
using System;
using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace MediaCatalog.DataAccess
{
    public class LibraryContext : IdentityDbContext<ApplicationUser>
    {

        public LibraryContext() : base("name=LibraryContext")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }

        public static LibraryContext Create()
        {
            return new LibraryContext();
        }

        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Staff> Staff { get; set; }
        public DbSet<UserTokenCache> UserTokenCacheList { get; set; }

        protected override void OnModelCreating(DbModelBuilder builder)
        {
            builder.Conventions.Add(new ForeignKeyNamingConvention());

            builder.Properties<string>().Configure(c => c.HasColumnType("varchar"));
            builder.Properties<DateTime>().Configure(c => c.HasColumnType("smalldatetime"));

            builder.Entity<Staff>().Property(x => x.Firstname).HasMaxLength(75);
            builder.Entity<Staff>().Property(x => x.Lastname).HasMaxLength(125);
            builder.Entity<Staff>().Property(x => x.Email).HasMaxLength(125);
            builder.Entity<Staff>().Property(x => x.Role).HasMaxLength(50);
            builder.Entity<Staff>().Property(x => x.Street).HasMaxLength(75);
            builder.Entity<Staff>().Property(x => x.Street2).HasMaxLength(75);
            builder.Entity<Staff>().Property(x => x.State).HasMaxLength(2);
            builder.Entity<Staff>().Property(x => x.City).HasMaxLength(50);
            builder.Entity<Staff>().Property(x => x.Zipcode).HasMaxLength(12);
            builder.Entity<Staff>().Property(x => x.Phone).HasMaxLength(12);

            builder.Entity<Staff>().HasMany(e => e.Products).WithMany(e => e.Staff);

            base.OnModelCreating(builder);
        }
    }
}
