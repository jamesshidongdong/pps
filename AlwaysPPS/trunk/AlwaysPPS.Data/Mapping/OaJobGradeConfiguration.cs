using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using AlwaysPPS.Entity;

namespace AlwaysPPS.Data.Mapping
{
    internal partial class OaJobGradeConfiguration : EntityTypeConfiguration<OaJobGrade>
    {
        public OaJobGradeConfiguration(string schema = "dbo")
        {
            ToTable(schema + ".OAJobGrade");
            HasKey(x => x.JobGradeId);

            Property(x => x.JobGradeId).HasColumnName("JobGradeId").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.JobGrade).HasColumnName("JobGrade").IsRequired().HasMaxLength(50);
            Property(x => x.Rank).HasColumnName("Rank").IsOptional();
            InitializePartial();
        }
        partial void InitializePartial();
    }
}