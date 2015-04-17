using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace SPA.KnockoutJs.Service.Models.Mapping
{
    public class EmployeeMap : EntityTypeConfiguration<Employee>
    {
        public EmployeeMap()
        {
            // Primary Key
            this.HasKey(t => t.EmployeeID);

            // Properties
            this.Property(t => t.EmployeeName)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(100);

            this.Property(t => t.DepartmentName)
                .HasMaxLength(100);

            this.Property(t => t.ProjectName)
                .HasMaxLength(100);

            this.Property(t => t.Description)
                .HasMaxLength(200);

            // Table & Column Mappings
            this.ToTable("Employee");
            this.Property(t => t.EmployeeID).HasColumnName("EmployeeID");
            this.Property(t => t.EmployeeName).HasColumnName("EmployeeName");
            this.Property(t => t.DepartmentName).HasColumnName("DepartmentName");
            this.Property(t => t.BasicSalary).HasColumnName("BasicSalary");
            this.Property(t => t.DateOfJoining).HasColumnName("DateOfJoining");
            this.Property(t => t.DateOfBirth).HasColumnName("DateOfBirth");
            this.Property(t => t.ProjectName).HasColumnName("ProjectName");
            this.Property(t => t.Description).HasColumnName("Description");
        }
    }
}
