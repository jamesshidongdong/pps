using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using AlwaysPPS.Entity;

namespace AlwaysPPS.Data.Mapping
{
    internal partial class TTimesheetConfiguration : EntityTypeConfiguration<TTimesheet>
    {
        public TTimesheetConfiguration(string schema = "dbo")
        {
            ToTable(schema + ".tTimesheet");
            HasKey(x => x.Id);

            Property(x => x.Id).HasColumnName("Id").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.Day).HasColumnName("Day").IsRequired();
            Property(x => x.ResourceUid).HasColumnName("ResourceUid").IsRequired();
            Property(x => x.ProjectId).HasColumnName("ProjectId").IsRequired();
            Property(x => x.NumOfHours).HasColumnName("NumOfHours").IsOptional().HasPrecision(18, 2);
            Property(x => x.UpdatedByUid).HasColumnName("UpdatedByUid").IsOptional();
            Property(x => x.UpdatedDate).HasColumnName("UpdatedDate").IsOptional();
            InitializePartial();
        }
        partial void InitializePartial();
    }
}