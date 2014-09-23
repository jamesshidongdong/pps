using AlwaysFramework.DAL;

namespace AlwaysPPS.Entity
{
    public partial class TResourceTeam : EntityBase
    {
        public int ResourceId { get; set; } // ResourceId (Primary key)
        public int ResourceUid { get; set; } // ResourceUid
        public int TeamId { get; set; } // TeamId
        public int? SubTeamId { get; set; } // SubTeamId
        public int RoleId { get; set; } // RoleId
        public int? ManagerUid { get; set; } // ManagerUid
        public bool? Isdeleted { get; set; } // Isdeleted
    }
}