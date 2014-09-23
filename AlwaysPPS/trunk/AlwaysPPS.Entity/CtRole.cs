using AlwaysFramework.DAL;

namespace AlwaysPPS.Entity
{
    public partial class CtRole : EntityBase
    {
        public int RoleId { get; set; } // RoleId (Primary key)
        public string RoleDesc { get; set; } // RoleDesc
    }
}