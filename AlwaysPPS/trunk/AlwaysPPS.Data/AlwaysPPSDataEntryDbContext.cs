﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlwaysFramework.DAL.Providers.EntityFramework;
using AlwaysPPS.Data.Mapping;

namespace AlwaysPPS.Data
{
    public class AlwaysPPSDataEntryDbContext:DataContext
    {
        static AlwaysPPSDataEntryDbContext()
        {
            Database.SetInitializer<AlwaysPPSDataEntryDbContext>(null);
        }
        public AlwaysPPSDataEntryDbContext()
            : base("Name=AlwaysPPSDataEntryDbContext")
        {
           
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new CtDocumentTypeConfiguration());
            modelBuilder.Configurations.Add(new CtEmailTemplateConfiguration());
            modelBuilder.Configurations.Add(new CtMilestoneConfiguration());
            modelBuilder.Configurations.Add(new CtMilestoneTemplateConfiguration());
            modelBuilder.Configurations.Add(new CtProjectTypeConfiguration());
            modelBuilder.Configurations.Add(new CtRoleConfiguration());
            modelBuilder.Configurations.Add(new CtTaskTypeConfiguration());
            modelBuilder.Configurations.Add(new CtTeamConfiguration());
            modelBuilder.Configurations.Add(new SUserAccessLogConfiguration());
            modelBuilder.Configurations.Add(new SysdiagramConfiguration());
            modelBuilder.Configurations.Add(new TProjectConfiguration());
            modelBuilder.Configurations.Add(new TProjectDocumentConfiguration());
            modelBuilder.Configurations.Add(new TProjectMilestoneConfiguration());
            modelBuilder.Configurations.Add(new TProjectTaskConfiguration());
            modelBuilder.Configurations.Add(new TProjectWorkPlanConfiguration());
            modelBuilder.Configurations.Add(new TResourceTeamConfiguration());
            modelBuilder.Configurations.Add(new TTimesheetConfiguration());
            modelBuilder.Configurations.Add(new VProjectConfiguration());
            modelBuilder.Configurations.Add(new VProjectWorkPlanConfiguration()); 
            modelBuilder.Configurations.Add(new VTeamMemberConfiguration());
            modelBuilder.Configurations.Add(new CtProjectMileStoneTemplateConfiguration());
        }
    }
}
