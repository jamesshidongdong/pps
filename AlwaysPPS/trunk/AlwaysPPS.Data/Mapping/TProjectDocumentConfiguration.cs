using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using AlwaysPPS.Entity;

namespace AlwaysPPS.Data.Mapping
{
    internal partial class TProjectDocumentConfiguration : EntityTypeConfiguration<TProjectDocument>
    {
        public TProjectDocumentConfiguration(string schema = "dbo")
        {
            ToTable(schema + ".tProjectDocument");
            HasKey(x => x.DocumentId);

            Property(x => x.DocumentId).HasColumnName("DocumentId").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.ProjectId).HasColumnName("ProjectId").IsRequired();
            Property(x => x.DocumentType).HasColumnName("DocumentType").IsOptional().HasMaxLength(100);
            Property(x => x.DocumentName).HasColumnName("DocumentName").IsOptional().HasMaxLength(100);
            Property(x => x.DocumentFileName).HasColumnName("DocumentFileName").IsOptional().HasMaxLength(100);
            Property(x => x.UploadedDate).HasColumnName("UploadedDate").IsOptional();
            Property(x => x.UploadedByUid).HasColumnName("UploadedByUid").IsOptional();
            Property(x => x.Deleted).HasColumnName("Deleted").IsOptional();
            InitializePartial();
        }
        partial void InitializePartial();
    }
}