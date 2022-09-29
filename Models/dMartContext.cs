using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace DMART.Models
{
    public class DMARTContext : IdentityDbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<User> UserAccounts { get; set; }
        public DMARTContext()
        {
        }

        public DMARTContext(DbContextOptions<DMARTContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

       protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json")
                   .Build();
                var connectionString = configuration.GetConnectionString("DefaultConnection");
                optionsBuilder.UseSqlServer(connectionString);
            }
          }

        
        public override int SaveChanges()
        {
            var tracker = ChangeTracker;
            foreach (var entry in tracker.Entries()) //iterate through all the changed entities
            {
                if (entry.Entity is FullAuditModel) //if this entity is audit model
                {
                    
                    var referenceEntity = entry.Entity as FullAuditModel;
                    switch (entry.State)
                    {
                        case EntityState.Added:
                            referenceEntity.CreatedDate = DateTime.Now;
                            break;
                        case EntityState.Deleted:
                            referenceEntity.isDeleted = true;
                            break;
                        case EntityState.Modified:
                            referenceEntity.LastModifiedDate = DateTime.Now;
                            break;
                        default:
                            break;
                    }
                }
            }
            return base.SaveChanges();
        }


    }
}
