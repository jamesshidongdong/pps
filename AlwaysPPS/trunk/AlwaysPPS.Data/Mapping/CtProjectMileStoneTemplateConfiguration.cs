using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlwaysPPS.Entity;

namespace AlwaysPPS.Data.Mapping
{
    // ctProjectMileStoneTemplate
    internal partial class CtProjectMileStoneTemplateConfiguration : EntityTypeConfiguration<CtProjectMileStoneTemplate>
    {
        public CtProjectMileStoneTemplateConfiguration(string schema = "dbo")
        {
            ToTable(schema + ".ctProjectMileStoneTemplate");
            HasKey(x => x.Id);

            Property(x => x.Id).HasColumnName("Id").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.ProjectType).HasColumnName("ProjectType").IsOptional();
            Property(x => x.MileStoneName).HasColumnName("MileStoneName").IsOptional().HasMaxLength(255);
            InitializePartial();
        }
        partial void InitializePartial();
    }
}
