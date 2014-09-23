using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using AlwaysPPS.Entity;

namespace AlwaysPPS.Data.Mapping
{
    internal partial class TResourceTeamConfiguration : EntityTypeConfiguration<TResourceTeam>
    {
        public TResourceTeamConfiguration(string schema = "dbo")
        {
            ToTable(schema + ".tResourceTeam");
            HasKey(x => x.ResourceId);

            Property(x => x.ResourceId).HasColumnName("ResourceId").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.ResourceUid).HasColumnName("ResourceUid").IsRequired();
            Property(x => x.TeamId).HasColumnName("TeamId").IsRequired();
            Property(x => x.SubTeamId).HasColumnName("SubTeamId").IsOptional();
            Property(x => x.RoleId).HasColumnName("RoleId").IsRequired();
            Property(x => x.ManagerUid).HasColumnName("ManagerUid").IsOptional();
            Property(x => x.Isdeleted).HasColumnName("Isdeleted").IsOptional();
            InitializePartial();
        }
        partial void InitializePartial();
    }
}