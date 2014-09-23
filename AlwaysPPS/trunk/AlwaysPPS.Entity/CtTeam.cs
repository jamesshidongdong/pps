﻿using AlwaysFramework.DAL;

namespace AlwaysPPS.Entity
{
    public partial class CtTeam : EntityBase
    {
        public int TeamId { get; set; } // TeamId (Primary key)
        public string TeamName { get; set; } // TeamName
        public int? ParentId { get; set; } // ParentId
        public bool? Isdeleted { get; set; } // Isdeleted
    }
}