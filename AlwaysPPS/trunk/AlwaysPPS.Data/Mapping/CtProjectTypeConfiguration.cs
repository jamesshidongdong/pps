using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using AlwaysPPS.Entity;

namespace AlwaysPPS.Data.Mapping
{
    internal partial class CtProjectTypeConfiguration : EntityTypeConfiguration<CtProjectType>
    {
        public CtProjectTypeConfiguration(string schema = "dbo")
        {
            ToTable(schema + ".ctProjectType");
            HasKey(x => x.ProjectTypeId);

            Property(x => x.ProjectTypeId).HasColumnName("ProjectTypeId").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.ProjectTypeDesc).HasColumnName("ProjectTypeDesc").IsOptional().HasMaxLength(50);
            Property(x => x.DepartmentId).HasColumnName("DepartmentId").IsOptional();
            Property(x => x.TeamId).HasColumnName("TeamId").IsOptional();
            Property(x => x.Status).HasColumnName("Status").IsOptional().HasMaxLength(10);
            InitializePartial();
        }
        partial void InitializePartial();
    }
}