using AlwaysFramework.DAL;

namespace AlwaysPPS.Entity
{
    public partial class CtEmailTemplate : EntityBase
    {
        public int EmailTemplateId { get; set; } // EmailTemplateId (Primary key)
        public string EmailTemplateName { get; set; } // EmailTemplateName
        public string EmailSubject { get; set; } // EmailSubject
        public string EmailBody { get; set; } // EmailBody
        public bool? DefaultSender { get; set; } // DefaultSender
        public bool? DefaultSignatory { get; set; } // DefaultSignatory
    }
}