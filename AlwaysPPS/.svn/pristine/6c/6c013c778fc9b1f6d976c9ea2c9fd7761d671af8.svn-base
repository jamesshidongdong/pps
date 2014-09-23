using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using AlwaysPPS.Entity;

namespace AlwaysPPS.Data.Mapping
{
    internal partial class CtDocumentTypeConfiguration : EntityTypeConfiguration<CtDocumentType>
    {
        public CtDocumentTypeConfiguration(string schema = "dbo")
        {
            ToTable(schema + ".ctDocumentType");
            HasKey(x => x.DocumentType);

            Property(x => x.DocumentType).HasColumnName("DocumentType").IsRequired().HasMaxLength(100).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.DocumentTypeDesc).HasColumnName("DocumentTypeDesc").IsOptional().HasMaxLength(200);
            InitializePartial();
        }
        partial void InitializePartial();
    }
}