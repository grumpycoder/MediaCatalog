namespace MediaCatalog.Domain
{
    public class StaffMember
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public int PersonId { get; set; }
        public int StaffRoleId { get; set; }

        public virtual StaffRole StaffRole { get; set; }
        public virtual Person Person { get; set; }
    }
}
