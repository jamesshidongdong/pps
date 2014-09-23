using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using AlwaysPPS.Entity;

namespace AlwaysPPS.Data.Mapping
{
    internal partial class CtTaskTypeConfiguration : EntityTypeConfiguration<CtTaskType>
    {
        public CtTaskTypeConfiguration(string schema = "dbo")
        {
            ToTable(schema + ".ctTaskType");
            HasKey(x => x.TaskTypeCode);

            Property(x => x.TaskTypeCode).HasColumnName("TaskTypeCode").IsRequired().HasMaxLength(50).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.TaskTypeDescription).HasColumnName("TaskTypeDescription").IsOptional().HasMaxLength(100);
            InitializePartial();
        }
        partial void InitializePartial();
    }
}