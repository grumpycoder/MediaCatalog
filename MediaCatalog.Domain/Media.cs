namespace MediaCatalog.Domain
{
    public class Media
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ISBN { get; set; }
        public string Summary { get; set; }
        public int? CompanyId { get; set; }

        public virtual Company Company { get; set; }
    }
}
