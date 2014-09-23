using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using AlwaysPPS.Entity;

namespace AlwaysPPS.Data.Mapping
{
    internal partial class OaDepartmentConfiguration : EntityTypeConfiguration<OaDepartment>
    {
        public OaDepartmentConfiguration(string schema = "dbo")
        {
            ToTable(schema + ".OADepartment");
            HasKey(x => x.DepartmentId);

            Property(x => x.DepartmentId).HasColumnName("DepartmentId").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.DepartmentName).HasColumnName("DepartmentName").IsOptional().HasMaxLength(100);
            Property(x => x.DepartmentHeadUid).HasColumnName("DepartmentHeadUid").IsOptional();
            InitializePartial();
        }
        partial void InitializePartial();
    }
}