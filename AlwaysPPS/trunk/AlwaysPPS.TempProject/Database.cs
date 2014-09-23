

// This file was automatically generated.
// Do not make changes directly to this file - edit the template instead.
// 
// The following connection settings were used to generate this file
// 
//     Configuration file:     "AlwaysPPS.Web\Web.config"
//     Connection String Name: "AlwaysPPSDataEntryDbContext"
//     Connection String:      "server=10.139.137.188;UID=sa;PWD=1234;database=AlwaysPPS;app=AlwaysPPS_web"

// ReSharper disable RedundantUsingDirective
// ReSharper disable DoNotCallOverridableMethodsInConstructor
// ReSharper disable InconsistentNaming
// ReSharper disable PartialTypeWithSinglePart
// ReSharper disable PartialMethodWithSinglePart
// ReSharper disable RedundantNameQualifier

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using AlwaysPPS.Data;
//using DatabaseGeneratedOption = System.ComponentModel.DataAnnotations.DatabaseGeneratedOption;

namespace AlwaysPPS.TempProject
{
    // ************************************************************************
    // Database context
    public partial class AlwaysPPSDataEntryDbContext : DbContext, IAlwaysPPSDataEntryDbContext
    {
        public IDbSet<CtDocumentType> CtDocumentTypes { get; set; } // ctDocumentType
        public IDbSet<CtEmailTemplate> CtEmailTemplates { get; set; } // ctEmailTemplate
        public IDbSet<CtMilestone> CtMilestones { get; set; } // ctMilestone
        public IDbSet<CtMilestoneTemplate> CtMilestoneTemplates { get; set; } // ctMilestoneTemplate
        public IDbSet<CtProjectMileStoneTemplate> CtProjectMileStoneTemplates { get; set; } // ctProjectMileStoneTemplate
        public IDbSet<CtProjectType> CtProjectTypes { get; set; } // ctProjectType
        public IDbSet<CtRole> CtRoles { get; set; } // ctRole
        public IDbSet<CtTaskType> CtTaskTypes { get; set; } // ctTaskType
        public IDbSet<CtTeam> CtTeams { get; set; } // ctTeam
        public IDbSet<CtUserProjectTypeMapping> CtUserProjectTypeMappings { get; set; } // ctUserProjectTypeMapping
        public IDbSet<SUserAccessLog> SUserAccessLogs { get; set; } // sUserAccessLog
        public IDbSet<TProject> TProjects { get; set; } // tProject
        public IDbSet<TProjectDocument> TProjectDocuments { get; set; } // tProjectDocument
        public IDbSet<TProjectMilestone> TProjectMilestones { get; set; } // tProjectMilestone
        public IDbSet<TProjectTask> TProjectTasks { get; set; } // tProjectTask
        public IDbSet<TProjectWorkPlan> TProjectWorkPlans { get; set; } // tProjectWorkPlan
        public IDbSet<TResourceTeam> TResourceTeams { get; set; } // tResourceTeam
        public IDbSet<TTimesheet> TTimesheets { get; set; } // tTimesheet
        public IDbSet<VProject> VProjects { get; set; } // V_Project
        public IDbSet<VProjectWorkPlan> VProjectWorkPlans { get; set; } // V_ProjectWorkPlan
        public IDbSet<VTeamMember> VTeamMembers { get; set; } // V_TeamMember

        static AlwaysPPSDataEntryDbContext()
        {
            Database.SetInitializer<AlwaysPPSDataEntryDbContext>(null);
        }

        public AlwaysPPSDataEntryDbContext()
            : base("Name=AlwaysPPSDataEntryDbContext")
        {
        InitializePartial();
        }

        public AlwaysPPSDataEntryDbContext(string connectionString) : base(connectionString)
        {
        InitializePartial();
        }

        public AlwaysPPSDataEntryDbContext(string connectionString, System.Data.Entity.Infrastructure.DbCompiledModel model) : base(connectionString, model)
        {
        InitializePartial();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new CtDocumentTypeConfiguration());
            modelBuilder.Configurations.Add(new CtEmailTemplateConfiguration());
            modelBuilder.Configurations.Add(new CtMilestoneConfiguration());
            modelBuilder.Configurations.Add(new CtMilestoneTemplateConfiguration());
            modelBuilder.Configurations.Add(new CtProjectMileStoneTemplateConfiguration());
            modelBuilder.Configurations.Add(new CtProjectTypeConfiguration());
            modelBuilder.Configurations.Add(new CtRoleConfiguration());
            modelBuilder.Configurations.Add(new CtTaskTypeConfiguration());
            modelBuilder.Configurations.Add(new CtTeamConfiguration());
            modelBuilder.Configurations.Add(new CtUserProjectTypeMappingConfiguration());
            modelBuilder.Configurations.Add(new SUserAccessLogConfiguration());
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
        OnModelCreatingPartial(modelBuilder);
        }

        public static DbModelBuilder CreateModel(DbModelBuilder modelBuilder, string schema)
        {
            modelBuilder.Configurations.Add(new CtDocumentTypeConfiguration(schema));
            modelBuilder.Configurations.Add(new CtEmailTemplateConfiguration(schema));
            modelBuilder.Configurations.Add(new CtMilestoneConfiguration(schema));
            modelBuilder.Configurations.Add(new CtMilestoneTemplateConfiguration(schema));
            modelBuilder.Configurations.Add(new CtProjectMileStoneTemplateConfiguration(schema));
            modelBuilder.Configurations.Add(new CtProjectTypeConfiguration(schema));
            modelBuilder.Configurations.Add(new CtRoleConfiguration(schema));
            modelBuilder.Configurations.Add(new CtTaskTypeConfiguration(schema));
            modelBuilder.Configurations.Add(new CtTeamConfiguration(schema));
            modelBuilder.Configurations.Add(new CtUserProjectTypeMappingConfiguration(schema));
            modelBuilder.Configurations.Add(new SUserAccessLogConfiguration(schema));
            modelBuilder.Configurations.Add(new TProjectConfiguration(schema));
            modelBuilder.Configurations.Add(new TProjectDocumentConfiguration(schema));
            modelBuilder.Configurations.Add(new TProjectMilestoneConfiguration(schema));
            modelBuilder.Configurations.Add(new TProjectTaskConfiguration(schema));
            modelBuilder.Configurations.Add(new TProjectWorkPlanConfiguration(schema));
            modelBuilder.Configurations.Add(new TResourceTeamConfiguration(schema));
            modelBuilder.Configurations.Add(new TTimesheetConfiguration(schema));
            modelBuilder.Configurations.Add(new VProjectConfiguration(schema));
            modelBuilder.Configurations.Add(new VProjectWorkPlanConfiguration(schema));
            modelBuilder.Configurations.Add(new VTeamMemberConfiguration(schema));
            return modelBuilder;
        }

        partial void InitializePartial();
        partial void OnModelCreatingPartial(DbModelBuilder modelBuilder);
    }

    // ************************************************************************
    // POCO classes

    // ctDocumentType
    public partial class CtDocumentType
    {
        public string DocumentType { get; set; } // DocumentType (Primary key)
        public string DocumentTypeDesc { get; set; } // DocumentTypeDesc
    }

    // ctEmailTemplate
    public partial class CtEmailTemplate
    {
        public int EmailTemplateId { get; set; } // EmailTemplateId (Primary key)
        public string EmailTemplateName { get; set; } // EmailTemplateName
        public string EmailSubject { get; set; } // EmailSubject
        public string EmailBody { get; set; } // EmailBody
        public bool? DefaultSender { get; set; } // DefaultSender
        public bool? DefaultSignatory { get; set; } // DefaultSignatory
    }

    // ctMilestone
    public partial class CtMilestone
    {
        public int MilestoneId { get; set; } // MilestoneId (Primary key)
        public int? MilestoneTemplateId { get; set; } // MilestoneTemplateId
        public string Milestone { get; set; } // Milestone
        public int? OrderId { get; set; } // OrderId
    }

    // ctMilestoneTemplate
    public partial class CtMilestoneTemplate
    {
        public int MilestoneTemplateId { get; set; } // MilestoneTemplateId (Primary key)
        public string MilestoneTemplateName { get; set; } // MilestoneTemplateName
        public bool? DefaultTemplate { get; set; } // DefaultTemplate
        public bool? HidePlanStartDate { get; set; } // HidePlanStartDate
        public bool? HidePlanEndDate { get; set; } // HidePlanEndDate
        public bool? HideReviseStartDate { get; set; } // HideReviseStartDate
        public bool? HideReviseEndDate { get; set; } // HideReviseEndDate
        public bool? HideActualStartDate { get; set; } // HideActualStartDate
        public bool? HideActualEndDate { get; set; } // HideActualEndDate
    }

    // ctProjectMileStoneTemplate
    public partial class CtProjectMileStoneTemplate
    {
        public int Id { get; set; } // Id (Primary key)
        public int? ProjectType { get; set; } // ProjectType
        public string MileStoneName { get; set; } // MileStoneName
    }

    // ctProjectType
    public partial class CtProjectType
    {
        public int ProjectTypeId { get; set; } // ProjectTypeId (Primary key)
        public string ProjectTypeDesc { get; set; } // ProjectTypeDesc
        public int? DepartmentId { get; set; } // DepartmentId
        public int? TeamId { get; set; } // TeamId
        public string Status { get; set; } // Status
    }

    // ctRole
    public partial class CtRole
    {
        public int RoleId { get; set; } // RoleId (Primary key)
        public string RoleDesc { get; set; } // RoleDesc
    }

    // ctTaskType
    public partial class CtTaskType
    {
        public string TaskTypeCode { get; set; } // TaskTypeCode (Primary key)
        public string TaskTypeDescription { get; set; } // TaskTypeDescription
    }

    // ctTeam
    public partial class CtTeam
    {
        public int TeamId { get; set; } // TeamId (Primary key)
        public string TeamName { get; set; } // TeamName
        public int? ParentId { get; set; } // ParentId
        public bool? Isdeleted { get; set; } // Isdeleted

        public CtTeam()
        {
            Isdeleted = false;
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // ctUserProjectTypeMapping
    public partial class CtUserProjectTypeMapping
    {
        public int UserId { get; set; } // UserId (Primary key)
        public int ProjectTypeId { get; set; } // ProjectTypeId (Primary key)
    }

    // sUserAccessLog
    public partial class SUserAccessLog
    {
        public int Id { get; set; } // Id (Primary key)
        public int? UserId { get; set; } // UserId
        public string SessionId { get; set; } // SessionId
        public string Page { get; set; } // Page
        public string Action { get; set; } // Action
        public DateTime? AccessDate { get; set; } // AccessDate
    }

    // tProject
    public partial class TProject
    {
        public int ProjectId { get; set; } // ProjectId (Primary key)
        public string ProjectCode { get; set; } // ProjectCode
        public string ProjectName { get; set; } // ProjectName
        public string ProjectDescription { get; set; } // ProjectDescription
        public string ClientName { get; set; } // ClientName
        public int? SystemId { get; set; } // SystemId
        public int? ProjectTypeId { get; set; } // ProjectTypeId
        public int RequestorUid { get; set; } // RequestorUid
        public int? DepartmentId { get; set; } // DepartmentId
        public DateTime? Deadline { get; set; } // Deadline
        public DateTime RequestedDate { get; set; } // RequestedDate
        public int? AssignedToUid { get; set; } // AssignedToUid
        public string Status { get; set; } // Status
        public string State { get; set; } // State
        public int? UpdatedByUid { get; set; } // UpdatedByUid
        public DateTime? UpdatedDate { get; set; } // UpdatedDate
        public DateTime? DateClosed { get; set; } // DateClosed
        public string Reson { get; set; } // Reson
    }

    // tProjectDocument
    public partial class TProjectDocument
    {
        public int DocumentId { get; set; } // DocumentId (Primary key)
        public int ProjectId { get; set; } // ProjectId
        public string DocumentType { get; set; } // DocumentType
        public string DocumentName { get; set; } // DocumentName
        public string DocumentFileName { get; set; } // DocumentFileName
        public DateTime? UploadedDate { get; set; } // UploadedDate
        public int? UploadedByUid { get; set; } // UploadedByUid
        public bool? Deleted { get; set; } // Deleted
    }

    // tProjectMilestone
    public partial class TProjectMilestone
    {
        public int ProjectMilestoneId { get; set; } // ProjectMilestoneId (Primary key)
        public int ProjectId { get; set; } // ProjectId
        public string MilestoneName { get; set; } // MilestoneName
        public DateTime? PlanStartDate { get; set; } // PlanStartDate
        public DateTime? PlanEndDate { get; set; } // PlanEndDate
        public DateTime? ReviseStartDate { get; set; } // ReviseStartDate
        public DateTime? ReviseEndDate { get; set; } // ReviseEndDate
        public DateTime? ActualStartDate { get; set; } // ActualStartDate
        public DateTime? ActualEndDate { get; set; } // ActualEndDate
        public string Remarks { get; set; } // Remarks
        public bool? Deleted { get; set; } // Deleted
    }

    // tProjectTask
    public partial class TProjectTask
    {
        public int TaskId { get; set; } // TaskId (Primary key)
        public int? ProjectId { get; set; } // ProjectId
        public int? AssigneeUid { get; set; } // AssigneeUid
        public string TaskTypeCode { get; set; } // TaskTypeCode
        public string Status { get; set; } // Status
        public string Decision { get; set; } // Decision
        public DateTime? CreatedDate { get; set; } // CreatedDate
        public int? CreatedByUid { get; set; } // CreatedByUid
        public DateTime? UpdatedDate { get; set; } // UpdatedDate
        public int? UpdatedByUid { get; set; } // UpdatedByUid
    }

    // tProjectWorkPlan
    public partial class TProjectWorkPlan
    {
        public int ProjectWorkPlanId { get; set; } // ProjectWorkPlanId (Primary key)
        public int ProjectId { get; set; } // ProjectId
        public int ResourceUid { get; set; } // ResourceUid
        public string Task { get; set; } // Task
        public DateTime? PlanStartDate { get; set; } // PlanStartDate
        public DateTime? PlanEndDate { get; set; } // PlanEndDate
        public DateTime? ActualStartDate { get; set; } // ActualStartDate
        public DateTime? ActualEndDate { get; set; } // ActualEndDate
        public decimal? PlanEffort { get; set; } // PlanEffort
        public decimal? ActualEffort { get; set; } // ActualEffort
        public string Remarks { get; set; } // Remarks
        public bool? Deleted { get; set; } // Deleted

        public TProjectWorkPlan()
        {
            ActualEffort = 0.00m;
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // tResourceTeam
    public partial class TResourceTeam
    {
        public int ResourceId { get; set; } // ResourceId (Primary key)
        public int ResourceUid { get; set; } // ResourceUid
        public int TeamId { get; set; } // TeamId
        public int? SubTeamId { get; set; } // SubTeamId
        public int RoleId { get; set; } // RoleId
        public int? ManagerUid { get; set; } // ManagerUid
        public bool? Isdeleted { get; set; } // Isdeleted

        public TResourceTeam()
        {
            Isdeleted = false;
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // tTimesheet
    public partial class TTimesheet
    {
        public int Id { get; set; } // Id (Primary key)
        public DateTime Day { get; set; } // Day
        public int ResourceUid { get; set; } // ResourceUid
        public int ProjectId { get; set; } // ProjectId
        public decimal? NumOfHours { get; set; } // NumOfHours
        public int? UpdatedByUid { get; set; } // UpdatedByUid
        public DateTime? UpdatedDate { get; set; } // UpdatedDate
    }

    // V_Project
    public partial class VProject
    {
        public int ProjectId { get; set; } // ProjectId
        public string ProjectCode { get; set; } // ProjectCode
        public string ProjectName { get; set; } // ProjectName
        public string ProjectDescription { get; set; } // ProjectDescription
        public string ClientName { get; set; } // ClientName
        public int? SystemId { get; set; } // SystemId
        public int? ProjectTypeId { get; set; } // ProjectTypeId
        public int RequestorUid { get; set; } // RequestorUid
        public int? DepartmentId { get; set; } // DepartmentId
        public DateTime? Deadline { get; set; } // Deadline
        public DateTime RequestedDate { get; set; } // RequestedDate
        public int? AssignedToUid { get; set; } // AssignedToUid
        public string Status { get; set; } // Status
        public string State { get; set; } // State
        public int? UpdatedByUid { get; set; } // UpdatedByUid
        public DateTime? UpdatedDate { get; set; } // UpdatedDate
        public DateTime? DateClosed { get; set; } // DateClosed
        public string Reson { get; set; } // Reson
        public string RequestorName { get; set; } // RequestorName
        public string DepartmentNames { get; set; } // DepartmentNames
        public string AssignedToName { get; set; } // AssignedToName
        public string DeadlineF { get; set; } // DeadlineF
        public string RequestedDateF { get; set; } // RequestedDateF
        public string StatusF { get; set; } // StatusF
    }

    // V_ProjectWorkPlan
    public partial class VProjectWorkPlan
    {
        public int ProjectWorkPlanId { get; set; } // ProjectWorkPlanId
        public int ProjectId { get; set; } // ProjectId
        public int ResourceUid { get; set; } // ResourceUid
        public string Task { get; set; } // Task
        public DateTime? PlanStartDate { get; set; } // PlanStartDate
        public DateTime? PlanEndDate { get; set; } // PlanEndDate
        public DateTime? ActualStartDate { get; set; } // ActualStartDate
        public DateTime? ActualEndDate { get; set; } // ActualEndDate
        public decimal? PlanEffort { get; set; } // PlanEffort
        public decimal? ActualEffort { get; set; } // ActualEffort
        public string Remarks { get; set; } // Remarks
        public bool? Deleted { get; set; } // Deleted
        public string EmployeeName { get; set; } // EmployeeName
        public string ProjectName { get; set; } // ProjectName
    }

    // V_TeamMember
    public partial class VTeamMember
    {
        public int ResourceId { get; set; } // ResourceId
        public int ResourceUid { get; set; } // ResourceUid
        public int TeamId { get; set; } // TeamId
        public int? SubTeamId { get; set; } // SubTeamId
        public int RoleId { get; set; } // RoleId
        public int? ManagerUid { get; set; } // ManagerUid
        public bool? Isdeleted { get; set; } // Isdeleted
        public string EmployeeName { get; set; } // EmployeeName
    }


    // ************************************************************************
    // POCO Configuration

    // ctDocumentType
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

    // ctEmailTemplate
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

    // ctMilestone
    internal partial class CtMilestoneConfiguration : EntityTypeConfiguration<CtMilestone>
    {
        public CtMilestoneConfiguration(string schema = "dbo")
        {
            ToTable(schema + ".ctMilestone");
            HasKey(x => x.MilestoneId);

            Property(x => x.MilestoneId).HasColumnName("MilestoneId").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.MilestoneTemplateId).HasColumnName("MilestoneTemplateId").IsOptional();
            Property(x => x.Milestone).HasColumnName("Milestone").IsOptional().HasMaxLength(100);
            Property(x => x.OrderId).HasColumnName("OrderId").IsOptional();
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // ctMilestoneTemplate
    internal partial class CtMilestoneTemplateConfiguration : EntityTypeConfiguration<CtMilestoneTemplate>
    {
        public CtMilestoneTemplateConfiguration(string schema = "dbo")
        {
            ToTable(schema + ".ctMilestoneTemplate");
            HasKey(x => x.MilestoneTemplateId);

            Property(x => x.MilestoneTemplateId).HasColumnName("MilestoneTemplateId").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.MilestoneTemplateName).HasColumnName("MilestoneTemplateName").IsOptional().HasMaxLength(100);
            Property(x => x.DefaultTemplate).HasColumnName("DefaultTemplate").IsOptional();
            Property(x => x.HidePlanStartDate).HasColumnName("HidePlanStartDate").IsOptional();
            Property(x => x.HidePlanEndDate).HasColumnName("HidePlanEndDate").IsOptional();
            Property(x => x.HideReviseStartDate).HasColumnName("HideReviseStartDate").IsOptional();
            Property(x => x.HideReviseEndDate).HasColumnName("HideReviseEndDate").IsOptional();
            Property(x => x.HideActualStartDate).HasColumnName("HideActualStartDate").IsOptional();
            Property(x => x.HideActualEndDate).HasColumnName("HideActualEndDate").IsOptional();
            InitializePartial();
        }
        partial void InitializePartial();
    }

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

    // ctProjectType
    internal partial class CtProjectTypeConfiguration : EntityTypeConfiguration<CtProjectType>
    {
        public CtProjectTypeConfiguration(string schema = "dbo")
        {
            ToTable(schema + ".ctProjectType");
            HasKey(x => x.ProjectTypeId);

            Property(x => x.ProjectTypeId).HasColumnName("ProjectTypeId").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.ProjectTypeDesc).HasColumnName("ProjectTypeDesc").IsOptional().HasMaxLength(50);
            Property(x => x.DepartmentId).HasColumnName("DepartmentId").IsOptional();
            Property(x => x.TeamId).HasColumnName("TeamId").IsOptional();
            Property(x => x.Status).HasColumnName("Status").IsOptional().HasMaxLength(10);
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // ctRole
    internal partial class CtRoleConfiguration : EntityTypeConfiguration<CtRole>
    {
        public CtRoleConfiguration(string schema = "dbo")
        {
            ToTable(schema + ".ctRole");
            HasKey(x => x.RoleId);

            Property(x => x.RoleId).HasColumnName("RoleId").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.RoleDesc).HasColumnName("RoleDesc").IsOptional().HasMaxLength(50);
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // ctTaskType
    internal partial class CtTaskTypeConfiguration : EntityTypeConfiguration<CtTaskType>
    {
        public CtTaskTypeConfiguration(string schema = "dbo")
        {
            ToTable(schema + ".ctTaskType");
            HasKey(x => x.TaskTypeCode);

            Property(x => x.TaskTypeCode).HasColumnName("TaskTypeCode").IsRequired().HasMaxLength(50).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.TaskTypeDescription).HasColumnName("TaskTypeDescription").IsOptional().HasMaxLength(100);
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // ctTeam
    internal partial class CtTeamConfiguration : EntityTypeConfiguration<CtTeam>
    {
        public CtTeamConfiguration(string schema = "dbo")
        {
            ToTable(schema + ".ctTeam");
            HasKey(x => x.TeamId);

            Property(x => x.TeamId).HasColumnName("TeamId").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.TeamName).HasColumnName("TeamName").IsOptional().HasMaxLength(100);
            Property(x => x.ParentId).HasColumnName("ParentId").IsOptional();
            Property(x => x.Isdeleted).HasColumnName("Isdeleted").IsOptional();
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // ctUserProjectTypeMapping
    internal partial class CtUserProjectTypeMappingConfiguration : EntityTypeConfiguration<CtUserProjectTypeMapping>
    {
        public CtUserProjectTypeMappingConfiguration(string schema = "dbo")
        {
            ToTable(schema + ".ctUserProjectTypeMapping");
            HasKey(x => new { x.UserId, x.ProjectTypeId });

            Property(x => x.UserId).HasColumnName("UserId").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.ProjectTypeId).HasColumnName("ProjectTypeId").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // sUserAccessLog
    internal partial class SUserAccessLogConfiguration : EntityTypeConfiguration<SUserAccessLog>
    {
        public SUserAccessLogConfiguration(string schema = "dbo")
        {
            ToTable(schema + ".sUserAccessLog");
            HasKey(x => x.Id);

            Property(x => x.Id).HasColumnName("Id").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.UserId).HasColumnName("UserId").IsOptional();
            Property(x => x.SessionId).HasColumnName("SessionId").IsOptional().HasMaxLength(50);
            Property(x => x.Page).HasColumnName("Page").IsOptional().HasMaxLength(50);
            Property(x => x.Action).HasColumnName("Action").IsOptional().HasMaxLength(50);
            Property(x => x.AccessDate).HasColumnName("AccessDate").IsOptional();
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // tProject
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
            Property(x => x.Reson).HasColumnName("Reson").IsOptional().HasMaxLength(255);
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // tProjectDocument
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

    // tProjectMilestone
    internal partial class TProjectMilestoneConfiguration : EntityTypeConfiguration<TProjectMilestone>
    {
        public TProjectMilestoneConfiguration(string schema = "dbo")
        {
            ToTable(schema + ".tProjectMilestone");
            HasKey(x => x.ProjectMilestoneId);

            Property(x => x.ProjectMilestoneId).HasColumnName("ProjectMilestoneId").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.ProjectId).HasColumnName("ProjectId").IsRequired();
            Property(x => x.MilestoneName).HasColumnName("MilestoneName").IsOptional().HasMaxLength(100);
            Property(x => x.PlanStartDate).HasColumnName("PlanStartDate").IsOptional();
            Property(x => x.PlanEndDate).HasColumnName("PlanEndDate").IsOptional();
            Property(x => x.ReviseStartDate).HasColumnName("ReviseStartDate").IsOptional();
            Property(x => x.ReviseEndDate).HasColumnName("ReviseEndDate").IsOptional();
            Property(x => x.ActualStartDate).HasColumnName("ActualStartDate").IsOptional();
            Property(x => x.ActualEndDate).HasColumnName("ActualEndDate").IsOptional();
            Property(x => x.Remarks).HasColumnName("Remarks").IsOptional();
            Property(x => x.Deleted).HasColumnName("Deleted").IsOptional();
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // tProjectTask
    internal partial class TProjectTaskConfiguration : EntityTypeConfiguration<TProjectTask>
    {
        public TProjectTaskConfiguration(string schema = "dbo")
        {
            ToTable(schema + ".tProjectTask");
            HasKey(x => x.TaskId);

            Property(x => x.TaskId).HasColumnName("TaskId").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.ProjectId).HasColumnName("ProjectId").IsOptional();
            Property(x => x.AssigneeUid).HasColumnName("AssigneeUid").IsOptional();
            Property(x => x.TaskTypeCode).HasColumnName("TaskTypeCode").IsOptional().HasMaxLength(50);
            Property(x => x.Status).HasColumnName("Status").IsOptional().HasMaxLength(20);
            Property(x => x.Decision).HasColumnName("Decision").IsOptional().HasMaxLength(50);
            Property(x => x.CreatedDate).HasColumnName("CreatedDate").IsOptional();
            Property(x => x.CreatedByUid).HasColumnName("CreatedByUid").IsOptional();
            Property(x => x.UpdatedDate).HasColumnName("UpdatedDate").IsOptional();
            Property(x => x.UpdatedByUid).HasColumnName("UpdatedByUid").IsOptional();
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // tProjectWorkPlan
    internal partial class TProjectWorkPlanConfiguration : EntityTypeConfiguration<TProjectWorkPlan>
    {
        public TProjectWorkPlanConfiguration(string schema = "dbo")
        {
            ToTable(schema + ".tProjectWorkPlan");
            HasKey(x => x.ProjectWorkPlanId);

            Property(x => x.ProjectWorkPlanId).HasColumnName("ProjectWorkPlanId").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.ProjectId).HasColumnName("ProjectId").IsRequired();
            Property(x => x.ResourceUid).HasColumnName("ResourceUid").IsRequired();
            Property(x => x.Task).HasColumnName("Task").IsOptional().HasMaxLength(1000);
            Property(x => x.PlanStartDate).HasColumnName("PlanStartDate").IsOptional();
            Property(x => x.PlanEndDate).HasColumnName("PlanEndDate").IsOptional();
            Property(x => x.ActualStartDate).HasColumnName("ActualStartDate").IsOptional();
            Property(x => x.ActualEndDate).HasColumnName("ActualEndDate").IsOptional();
            Property(x => x.PlanEffort).HasColumnName("PlanEffort").IsOptional().HasPrecision(18,2);
            Property(x => x.ActualEffort).HasColumnName("ActualEffort").IsOptional().HasPrecision(18,2);
            Property(x => x.Remarks).HasColumnName("Remarks").IsOptional();
            Property(x => x.Deleted).HasColumnName("Deleted").IsOptional();
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // tResourceTeam
    internal partial class TResourceTeamConfiguration : EntityTypeConfiguration<TResourceTeam>
    {
        public TResourceTeamConfiguration(string schema = "dbo")
        {
            ToTable(schema + ".tResourceTeam");
            HasKey(x => x.ResourceId);

            Property(x => x.ResourceId).HasColumnName("ResourceId").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.ResourceUid).HasColumnName("ResourceUid").IsRequired();
            Property(x => x.TeamId).HasColumnName("TeamId").IsRequired();
            Property(x => x.SubTeamId).HasColumnName("SubTeamId").IsOptional();
            Property(x => x.RoleId).HasColumnName("RoleId").IsRequired();
            Property(x => x.ManagerUid).HasColumnName("ManagerUid").IsOptional();
            Property(x => x.Isdeleted).HasColumnName("Isdeleted").IsOptional();
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // tTimesheet
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
            Property(x => x.NumOfHours).HasColumnName("NumOfHours").IsOptional().HasPrecision(18,2);
            Property(x => x.UpdatedByUid).HasColumnName("UpdatedByUid").IsOptional();
            Property(x => x.UpdatedDate).HasColumnName("UpdatedDate").IsOptional();
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // V_Project
    internal partial class VProjectConfiguration : EntityTypeConfiguration<VProject>
    {
        public VProjectConfiguration(string schema = "dbo")
        {
            ToTable(schema + ".V_Project");
            HasKey(x => new { x.ProjectId, x.ProjectName, x.RequestorUid, x.RequestedDate, x.Status, x.StatusF });

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
            Property(x => x.Reson).HasColumnName("Reson").IsOptional().HasMaxLength(255);
            Property(x => x.RequestorName).HasColumnName("RequestorName").IsOptional().HasMaxLength(100);
            Property(x => x.DepartmentNames).HasColumnName("DepartmentNames").IsOptional().HasMaxLength(100);
            Property(x => x.AssignedToName).HasColumnName("AssignedToName").IsOptional().HasMaxLength(100);
            Property(x => x.DeadlineF).HasColumnName("DeadlineF").IsOptional().HasMaxLength(10);
            Property(x => x.RequestedDateF).HasColumnName("RequestedDateF").IsOptional().HasMaxLength(10);
            Property(x => x.StatusF).HasColumnName("StatusF").IsRequired().HasMaxLength(7);
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // V_ProjectWorkPlan
    internal partial class VProjectWorkPlanConfiguration : EntityTypeConfiguration<VProjectWorkPlan>
    {
        public VProjectWorkPlanConfiguration(string schema = "dbo")
        {
            ToTable(schema + ".V_ProjectWorkPlan");
            HasKey(x => new { x.ProjectWorkPlanId, x.ProjectId, x.ResourceUid });

            Property(x => x.ProjectWorkPlanId).HasColumnName("ProjectWorkPlanId").IsRequired();
            Property(x => x.ProjectId).HasColumnName("ProjectId").IsRequired();
            Property(x => x.ResourceUid).HasColumnName("ResourceUid").IsRequired();
            Property(x => x.Task).HasColumnName("Task").IsOptional().HasMaxLength(1000);
            Property(x => x.PlanStartDate).HasColumnName("PlanStartDate").IsOptional();
            Property(x => x.PlanEndDate).HasColumnName("PlanEndDate").IsOptional();
            Property(x => x.ActualStartDate).HasColumnName("ActualStartDate").IsOptional();
            Property(x => x.ActualEndDate).HasColumnName("ActualEndDate").IsOptional();
            Property(x => x.PlanEffort).HasColumnName("PlanEffort").IsOptional().HasPrecision(18,2);
            Property(x => x.ActualEffort).HasColumnName("ActualEffort").IsOptional().HasPrecision(18,2);
            Property(x => x.Remarks).HasColumnName("Remarks").IsOptional();
            Property(x => x.Deleted).HasColumnName("Deleted").IsOptional();
            Property(x => x.EmployeeName).HasColumnName("EmployeeName").IsOptional().HasMaxLength(100);
            Property(x => x.ProjectName).HasColumnName("ProjectName").IsOptional().HasMaxLength(100);
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // V_TeamMember
    internal partial class VTeamMemberConfiguration : EntityTypeConfiguration<VTeamMember>
    {
        public VTeamMemberConfiguration(string schema = "dbo")
        {
            ToTable(schema + ".V_TeamMember");
            HasKey(x => new { x.ResourceId, x.ResourceUid, x.TeamId, x.RoleId });

            Property(x => x.ResourceId).HasColumnName("ResourceId").IsRequired();
            Property(x => x.ResourceUid).HasColumnName("ResourceUid").IsRequired();
            Property(x => x.TeamId).HasColumnName("TeamId").IsRequired();
            Property(x => x.SubTeamId).HasColumnName("SubTeamId").IsOptional();
            Property(x => x.RoleId).HasColumnName("RoleId").IsRequired();
            Property(x => x.ManagerUid).HasColumnName("ManagerUid").IsOptional();
            Property(x => x.Isdeleted).HasColumnName("Isdeleted").IsOptional();
            Property(x => x.EmployeeName).HasColumnName("EmployeeName").IsOptional().HasMaxLength(100);
            InitializePartial();
        }
        partial void InitializePartial();
    }

}

