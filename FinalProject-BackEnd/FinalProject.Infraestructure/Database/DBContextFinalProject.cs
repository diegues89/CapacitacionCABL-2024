

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
        public virtual DbSet<productCategory> productCategory { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Users>(entity =>
            {

                entity.ToTable("Users", "dbo")
                .HasKey(x => x.id);
                

            });
            modelBuilder.Entity<rol>(entity =>
            {

                entity.ToTable("rol", "dbo")
                .HasKey(x => x.rolId);

            });
            modelBuilder.Entity<products>(entity =>
            {

                entity.ToTable("products", "dbo")

                .HasKey(x => x.idProduct);

                entity.HasOne(c => c.category)
                .WithMany()
                .HasForeignKey(c => c.idCategory);

                entity.HasOne(s => s.suppliers)
                .WithMany()
                .HasForeignKey(s => s.idSupplier);


            });
            modelBuilder.Entity<Suppliers>(entity =>
            {

                entity.ToTable("Suppliers", "dbo")
                .HasKey(x => x.idSupplier);


            });
            modelBuilder.Entity<productCategory>(entity =>
            {

                entity.ToTable("productCategory", "dbo")
                .HasKey(x => x.idCategory);
                


            });
        }
    }
}