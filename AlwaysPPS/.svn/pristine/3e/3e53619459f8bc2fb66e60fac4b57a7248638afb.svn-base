using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using AlwaysPPS.Entity;

namespace AlwaysPPS.Data.Mapping
{
    internal partial class CtRoleConfiguration : EntityTypeConfiguration<CtRole>
    {
        public CtRoleConfiguration(string schema = "dbo")
        {
            ToTable(schema + ".ctRole");
            HasKey(x => x.RoleId);

            Property(x => x.RoleId).HasColumnName("RoleId").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.RoleDesc).HasColumnName("RoleDesc").IsOptional().HasMaxLength(50);
            InitializePartial();
        }
        partial void InitializePartial();
    }
}