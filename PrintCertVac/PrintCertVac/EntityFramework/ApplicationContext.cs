using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using PrintCertVac.Model;

namespace PrintCertVac.EntityFramework
{
    public sealed class ApplicationContext : DbContext
    {
        public DbSet<Certificate> Certificates { get; set; }
        public DbSet<TemplateCert> TemplateCerts { get; set; }
        public DbSet<Record> Records { get; set; }
        public DbSet<Setting> Settings { get; set; }

        public ApplicationContext()
        {
            _ = Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlite(@"Data Source=base.db");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Certificate>().OwnsOne(u => u.User).OwnsOne(u => u.Margin);
            modelBuilder.Entity<Certificate>().OwnsOne(u => u.User).OwnsOne(u => u.FontSize);
            modelBuilder.Entity<Certificate>().OwnsOne(u => u.DateOfVaccination);
            modelBuilder.Entity<Certificate>().OwnsOne(u => u.Vaccine);
            modelBuilder.Entity<Certificate>().OwnsOne(u => u.Doctor);
            modelBuilder.Entity<Certificate>().OwnsOne(u => u.DateOfVaccination2);
            modelBuilder.Entity<Certificate>().OwnsOne(u => u.Vaccine2);
            modelBuilder.Entity<Certificate>().OwnsOne(u => u.Doctor2);
            modelBuilder.Entity<Certificate>().OwnsOne(u => u.FirstPage);

            modelBuilder.Entity<TemplateCert>().OwnsOne(u => u.UserMargin);
            modelBuilder.Entity<TemplateCert>().OwnsOne(u => u.UserFontSize);
            modelBuilder.Entity<TemplateCert>().OwnsOne(u => u.Vaccine);
            modelBuilder.Entity<TemplateCert>().OwnsOne(u => u.Doctor);
            modelBuilder.Entity<TemplateCert>().OwnsOne(u => u.Vaccine2);
            modelBuilder.Entity<TemplateCert>().OwnsOne(u => u.Doctor2);
            modelBuilder.Entity<TemplateCert>().OwnsOne(u => u.FirstPage);
        }
    }
}
