using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using AlwaysPPS.Entity;

namespace AlwaysPPS.Data.Mapping
{
    internal partial class CtEmailTemplateConfiguration : EntityTypeConfiguration<CtEmailTemplate>
    {
        public CtEmailTemplateConfiguration(string schema = "dbo")
        {
            ToTable(schema + ".ctEmailTemplate");
            HasKey(x => x.EmailTemplateId);

            Property(x => x.EmailTemplateId).HasColumnName("EmailTemplateId").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.EmailTemplateName).HasColumnName("EmailTemplateName").IsOptional().HasMaxLength(100);
            Property(x => x.EmailSubject).HasColumnName("EmailSubject").IsOptional().HasMaxLength(100);
            Property(x => x.EmailBody).HasColumnName("EmailBody").IsOptional().HasMaxLength(100);
            Property(x => x.DefaultSender).HasColumnName("DefaultSender").IsOptional();
            Property(x => x.DefaultSignatory).HasColumnName("DefaultSignatory").IsOptional();
            InitializePartial();
        }
        partial void InitializePartial();
    }
}