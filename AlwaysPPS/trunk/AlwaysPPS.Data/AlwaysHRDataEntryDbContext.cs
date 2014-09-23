using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlwaysFramework.DAL.Providers.EntityFramework;
using AlwaysPPS.Data.Mapping;

namespace AlwaysPPS.Data
{
    public class AlwaysHRDataEntryDbContext : DataContext
    {
        static AlwaysHRDataEntryDbContext()
        {
            Database.SetInitializer<AlwaysHRDataEntryDbContext>(null);
        }

        public AlwaysHRDataEntryDbContext()
            : base("Name=AlwaysHRDataEntryDbContext")
        {
           
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new OaDepartmentConfiguration());
            modelBuilder.Configurations.Add(new OaEmployeeConfiguration());
            modelBuilder.Configurations.Add(new OaJobGradeConfiguration());
            modelBuilder.Configurations.Add(new OaOrganisationChartConfiguration());
           
        }
    }
}
