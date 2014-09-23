using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using AlwaysPPS.Entity;

namespace AlwaysPPS.Data.Mapping
{
    internal partial class OaOrganisationChartConfiguration : EntityTypeConfiguration<OaOrganisationChart>
    {
        public OaOrganisationChartConfiguration(string schema = "dbo")
        {
            ToTable(schema + ".OAOrganisationChart");
            HasKey(x => new { x.DepartmentId, x.OrgRole, x.UserId });

            Property(x => x.DepartmentId).HasColumnName("DepartmentId").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.OrgRole).HasColumnName("OrgRole").IsRequired().HasMaxLength(100).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.UserId).HasColumnName("UserId").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            InitializePartial();
        }
        partial void InitializePartial();
    }
}