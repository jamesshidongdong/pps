using AlwaysFramework.DAL;

namespace AlwaysPPS.Entity
{
    public partial class CtDocumentType : EntityBase
    {
        public string DocumentType { get; set; } // DocumentType (Primary key)
        public string DocumentTypeDesc { get; set; } // DocumentTypeDesc
    }
}