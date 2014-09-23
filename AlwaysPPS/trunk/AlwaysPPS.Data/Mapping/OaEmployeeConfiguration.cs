using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using AlwaysPPS.Entity;

namespace AlwaysPPS.Data.Mapping
{
    internal partial class OaEmployeeConfiguration : EntityTypeConfiguration<OaEmployee>
    {
        public OaEmployeeConfiguration(string schema = "dbo")
        {
            ToTable(schema + ".OAEmployee");
            HasKey(x => x.EmployeeId);

            Property(x => x.EmployeeId).HasColumnName("EmployeeId").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.EmployeeName).HasColumnName("EmployeeName").IsOptional().HasMaxLength(100);
            Property(x => x.UserId).HasColumnName("UserId").IsOptional();
            Property(x => x.DepartmentId).HasColumnName("DepartmentId").IsOptional();
            Property(x => x.JobTitle).HasColumnName("JobTitle").IsOptional().HasMaxLength(100);
            Property(x => x.JobGradeId).HasColumnName("JobGradeId").IsOptional();
            Property(x => x.ManagerEid).HasColumnName("ManagerEid").IsOptional();
            Property(x => x.ManagerUid).HasColumnName("ManagerUid").IsOptional();
            Property(x => x.EmploymentDate).HasColumnName("EmploymentDate").IsOptional();
            Property(x => x.TerminationDate).HasColumnName("TerminationDate").IsOptional();
            Property(x => x.Deleted).HasColumnName("Deleted").IsOptional();
            Property(x => x.Email).HasColumnName("Email").IsOptional().HasMaxLength(100);
            InitializePartial();
        }
        partial void InitializePartial();
    }
}