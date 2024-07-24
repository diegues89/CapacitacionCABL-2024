using FinalProject_BackEnd.Models;
using Microsoft.EntityFrameworkCore;

namespace FinalProject_BackEnd.DataBase
{
    public class DBContextFinalProject: DbContext
    {
        public DBContextFinalProject(DbContextOptions<DBContextFinalProject> options) : base(options)
        {
            
        }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<rol> rol { get; set; }
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
        }
    }
}