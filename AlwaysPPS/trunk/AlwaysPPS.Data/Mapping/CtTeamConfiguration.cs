using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using AlwaysPPS.Entity;

namespace AlwaysPPS.Data.Mapping
{
    internal partial class CtTeamConfiguration : EntityTypeConfiguration<CtTeam>
    {
        public CtTeamConfiguration(string schema = "dbo")
        {
            ToTable(schema + ".ctTeam");
            HasKey(x => x.TeamId);

            Property(x => x.TeamId).HasColumnName("TeamId").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.TeamName).HasColumnName("TeamName").IsOptional().HasMaxLength(100);
            Property(x => x.ParentId).HasColumnName("ParentId").IsOptional();
            Property(x => x.Isdeleted).HasColumnName("Isdeleted").IsOptional();
            InitializePartial();
        }
        partial void InitializePartial();
    }
}