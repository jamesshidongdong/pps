namespace AlwaysPPS.Entity
{
    public partial class OaOrganisationChart
    {
        public int DepartmentId { get; set; } // DepartmentId (Primary key)
        public string OrgRole { get; set; } // OrgRole (Primary key)
        public int UserId { get; set; } // UserId (Primary key)
    }
}