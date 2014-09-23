using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using AlwaysPPS.Entity;

namespace AlwaysPPS.Data.Mapping
{
    internal partial class TProjectTaskConfiguration : EntityTypeConfiguration<TProjectTask>
    {
        public TProjectTaskConfiguration(string schema = "dbo")
        {
            ToTable(schema + ".tProjectTask");
            HasKey(x => x.TaskId);

            Property(x => x.TaskId).HasColumnName("TaskId").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.ProjectId).HasColumnName("ProjectId").IsOptional();
            Property(x => x.AssigneeUid).HasColumnName("AssigneeUid").IsOptional();
            Property(x => x.TaskTypeCode).HasColumnName("TaskTypeCode").IsOptional().HasMaxLength(50);
            Property(x => x.Status).HasColumnName("Status").IsOptional().HasMaxLength(20);
            Property(x => x.Decision).HasColumnName("Decision").IsOptional().HasMaxLength(50);
            Property(x => x.CreatedDate).HasColumnName("CreatedDate").IsOptional();
            Property(x => x.CreatedByUid).HasColumnName("CreatedByUid").IsOptional();
            Property(x => x.UpdatedDate).HasColumnName("UpdatedDate").IsOptional();
            Property(x => x.UpdatedByUid).HasColumnName("UpdatedByUid").IsOptional();
            InitializePartial();
        }
        partial void InitializePartial();
    }
}