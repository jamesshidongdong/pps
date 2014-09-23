using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using AlwaysPPS.Entity;

namespace AlwaysPPS.Data.Mapping
{
    internal partial class SUserAccessLogConfiguration : EntityTypeConfiguration<SUserAccessLog>
    {
        public SUserAccessLogConfiguration(string schema = "dbo")
        {
            ToTable(schema + ".sUserAccessLog");
            HasKey(x => x.Id);

            Property(x => x.Id).HasColumnName("Id").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.UserId).HasColumnName("UserId").IsOptional();
            Property(x => x.SessionId).HasColumnName("SessionId").IsOptional().HasMaxLength(50);
            Property(x => x.Page).HasColumnName("Page").IsOptional().HasMaxLength(50);
            Property(x => x.Action).HasColumnName("Action").IsOptional().HasMaxLength(50);
            Property(x => x.AccessDate).HasColumnName("AccessDate").IsOptional();
            InitializePartial();
        }
        partial void InitializePartial();
    }
}