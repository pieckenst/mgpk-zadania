using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using TrainsMauiHybrid.Models;

namespace TrainsMauiHybrid.Data
{
    public partial class DiplomnyProektContext : DbContext
    {
        public DiplomnyProektContext()
        {
        }

        public DiplomnyProektContext(DbContextOptions<DiplomnyProektContext> options) : base(options)
        {
        }

        partial void OnModelBuilding(ModelBuilder builder);

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<TrainsMauiHybrid.Models.Bilety>()
              .HasOne(i => i.Marshuti)
              .WithMany(i => i.Bileties)
              .HasForeignKey(i => i.Nomer_MarshutaKey)
              .HasPrincipalKey(i => i.Nomer_Marshuta);

            builder.Entity<TrainsMauiHybrid.Models.Employee>()
              .HasOne(i => i.Job)
              .WithMany(i => i.Employees)
              .HasForeignKey(i => i.Job_Num)
              .HasPrincipalKey(i => i.Job_Num);

            builder.Entity<TrainsMauiHybrid.Models.Marshuti>()
              .HasOne(i => i.Employee)
              .WithMany(i => i.Marshutis)
              .HasForeignKey(i => i.Emp_Num)
              .HasPrincipalKey(i => i.Num);

            builder.Entity<TrainsMauiHybrid.Models.Marshuti>()
              .HasOne(i => i.Train)
              .WithMany(i => i.Marshutis)
              .HasForeignKey(i => i.ModelTrainKey)
              .HasPrincipalKey(i => i.NumVagona);

            builder.Entity<TrainsMauiHybrid.Models.Obsluzhivanie>()
              .HasOne(i => i.Train)
              .WithMany(i => i.Obsluzhivanies)
              .HasForeignKey(i => i.Model_TrainKey)
              .HasPrincipalKey(i => i.NumVagona);

            builder.Entity<TrainsMauiHybrid.Models.Prodazhi>()
              .HasOne(i => i.Bilety)
              .WithMany(i => i.Prodazhis)
              .HasForeignKey(i => i.Nomer_BiletaKey)
              .HasPrincipalKey(i => i.Nomer_Bileta);
            this.OnModelBuilding(builder);
        }

        public DbSet<TrainsMauiHybrid.Models.Bilety> Bileties { get; set; }

        public DbSet<TrainsMauiHybrid.Models.Employee> Employees { get; set; }

        public DbSet<TrainsMauiHybrid.Models.Job> Jobs { get; set; }

        public DbSet<TrainsMauiHybrid.Models.Marshuti> Marshutis { get; set; }

        public DbSet<TrainsMauiHybrid.Models.Obsluzhivanie> Obsluzhivanies { get; set; }

        public DbSet<TrainsMauiHybrid.Models.Prodazhi> Prodazhis { get; set; }

        public DbSet<TrainsMauiHybrid.Models.Train> Trains { get; set; }

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.Conventions.Add(_ => new BlankTriggerAddingConvention());
        }
    
    }
}