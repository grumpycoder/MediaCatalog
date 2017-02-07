namespace MediaCatalog.Models
{
    public class CreateEditProductModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Summary { get; set; }
        public string ISBN { get; set; }
        public int PublisherId { get; set; }
    }
}
