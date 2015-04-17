using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using SPA.KnockoutJs.Service.Models;
using SPA.KnockoutJs.Service.Models.Mapping;

namespace SPA.KnockoutJs.Service.DAL
{
    public partial class SampleDatabaseContext : DbContext
    {
        static SampleDatabaseContext()
        {
            Database.SetInitializer<SampleDatabaseContext>(null);
        }

        public SampleDatabaseContext()
            : base("Name=SampleDatabaseContext")
        {
        }

        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new DepartmentMap());
            modelBuilder.Configurations.Add(new EmployeeMap());
            modelBuilder.Configurations.Add(new StudentMap());
        }
    }
}
