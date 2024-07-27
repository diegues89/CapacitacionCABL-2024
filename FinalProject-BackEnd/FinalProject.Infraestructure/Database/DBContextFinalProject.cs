

using FinalProject.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FinalProject.Infraestructure.Database
{
    public class DBContextFinalProject: DbContext
    {
        public DBContextFinalProject(DbContextOptions<DBContextFinalProject> options) : base(options)
        {
            
        }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<rol> rol { get; set; }
        public virtual DbSet<products> products { get; set; }
        public virtual DbSet<Suppliers> Suppliers { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Users>(entity =>
            {

                entity.ToTable("Users", "dbo");

            });
            modelBuilder.Entity<rol>(entity =>
            {

                entity.ToTable("rol", "dbo");

            });
            modelBuilder.Entity<products>(entity =>
            {

                entity.ToTable("products", "dbo");

            });
            modelBuilder.Entity<Suppliers>(entity =>
            {

                entity.ToTable("Suppliers", "dbo");

            });
        }
    }
}