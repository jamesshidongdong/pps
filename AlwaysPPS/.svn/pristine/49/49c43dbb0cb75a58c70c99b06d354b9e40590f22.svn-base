using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using AlwaysPPS.Entity;

namespace AlwaysPPS.Data.Mapping
{
    internal partial class TProjectConfiguration : EntityTypeConfiguration<TProject>
    {
        public TProjectConfiguration(string schema = "dbo")
        {
            ToTable(schema + ".tProject");
            HasKey(x => x.ProjectId);

            Property(x => x.ProjectId).HasColumnName("ProjectId").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.ProjectCode).HasColumnName("ProjectCode").IsOptional().HasMaxLength(50);
            Property(x => x.ProjectName).HasColumnName("ProjectName").IsRequired().HasMaxLength(100);
            Property(x => x.ProjectDescription).HasColumnName("ProjectDescription").IsOptional();
            Property(x => x.ClientName).HasColumnName("ClientName").IsOptional().HasMaxLength(200);
            Property(x => x.SystemId).HasColumnName("SystemId").IsOptional();
            Property(x => x.ProjectTypeId).HasColumnName("ProjectTypeId").IsOptional();
            Property(x => x.RequestorUid).HasColumnName("RequestorUid").IsRequired();
            Property(x => x.DepartmentId).HasColumnName("DepartmentId").IsOptional();
            Property(x => x.Deadline).HasColumnName("Deadline").IsOptional();
            Property(x => x.RequestedDate).HasColumnName("RequestedDate").IsRequired();
            Property(x => x.AssignedToUid).HasColumnName("AssignedToUid").IsOptional();
            Property(x => x.Status).HasColumnName("Status").IsRequired().HasMaxLength(50);
            Property(x => x.State).HasColumnName("State").IsOptional().HasMaxLength(50);
            Property(x => x.UpdatedByUid).HasColumnName("UpdatedByUid").IsOptional();
            Property(x => x.UpdatedDate).HasColumnName("UpdatedDate").IsOptional();
            Property(x => x.DateClosed).HasColumnName("DateClosed").IsOptional();
            InitializePartial();
        }
        partial void InitializePartial();
    }
}