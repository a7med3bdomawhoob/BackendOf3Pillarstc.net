using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
namespace DAL.Context
{
    public  class context: DbContext
    {
        public context(DbContextOptions<context> options) : base(options)
        {

        }
        public DbSet<Department> departmens { get; set; }
        public DbSet<Job> jobs { get; set; }
        public DbSet<Book> books { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

                base.OnModelCreating(modelBuilder);
/*
                // Configure Job - Book relationship
                modelBuilder.Entity<Book>()
                    .HasOne(b => b.Job)
                    .WithMany(j => j.Books)
                    .HasForeignKey(b => b.JobId);

                // Configure Department - Book relationship
                modelBuilder.Entity<Book>()
                    .HasOne(b => b.Department)
                    .WithMany(d => d.Books)
                    .HasForeignKey(b => b.DepartmentId);*/
        }
    }
}
