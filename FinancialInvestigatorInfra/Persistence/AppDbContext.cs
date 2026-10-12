using FinancialInvestigationCopilotData.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinancialInvestigatorInfra.Persistence
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        // Define your DbSets here
        public DbSet<Incident> Incidents { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Incident>(entity =>
            {
                entity.ToTable("Incidents");

                entity.HasKey(x => x.Id);

                entity.Property(x => x.Title)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(x => x.Description)
                    .HasMaxLength(2000);

                entity.Property(x => x.Status)
                    .HasConversion<string>()
                    .HasMaxLength(50);

                entity.Property(x => x.CreatedDate)
                    .IsRequired();
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
