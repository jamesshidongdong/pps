using System.Data.Entity.ModelConfiguration;
using AlwaysPPS.Entity;

namespace AlwaysPPS.Data.Mapping
{
    internal partial class VProjectConfiguration : EntityTypeConfiguration<VProject>
    {
        public VProjectConfiguration(string schema = "dbo")
        {
            ToTable(schema + ".V_Project");
            HasKey(x => new { x.ProjectId, x.ProjectName, x.RequestorUid, x.RequestedDate, x.Status });

            Property(x => x.ProjectId).HasColumnName("ProjectId").IsRequired();
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
            Property(x => x.RequestorName).HasColumnName("RequestorName").IsOptional().HasMaxLength(100);
            Property(x => x.AssignedToName).HasColumnName("AssignedToName").IsOptional().HasMaxLength(100);
            Property(x => x.DeadlineF).HasColumnName("DeadlineF").IsOptional().HasMaxLength(10);
            Property(x => x.StatusF).HasColumnName("StatusF").IsRequired().HasMaxLength(7);
            InitializePartial();
        }
        partial void InitializePartial();
    }
}