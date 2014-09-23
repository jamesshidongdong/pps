using System.Data.Entity.ModelConfiguration;
using AlwaysPPS.Entity;

namespace AlwaysPPS.Data.Mapping
{
    internal partial class VTeamMemberConfiguration : EntityTypeConfiguration<VTeamMember>
    {
        public VTeamMemberConfiguration(string schema = "dbo")
        {
            ToTable(schema + ".V_TeamMember");
            HasKey(x => new { x.ResourceId, x.ResourceUid, x.TeamId, x.RoleId });

            Property(x => x.ResourceId).HasColumnName("ResourceId").IsRequired();
            Property(x => x.ResourceUid).HasColumnName("ResourceUid").IsRequired();
            Property(x => x.TeamId).HasColumnName("TeamId").IsRequired();
            Property(x => x.SubTeamId).HasColumnName("SubTeamId").IsOptional();
            Property(x => x.RoleId).HasColumnName("RoleId").IsRequired();
            Property(x => x.ManagerUid).HasColumnName("ManagerUid").IsOptional();
            Property(x => x.EmployeeName).HasColumnName("EmployeeName").IsOptional().HasMaxLength(100);
            InitializePartial();
        }
        partial void InitializePartial();
    }
}