namespace MediaCatalog.Models
{
    public class MediaSearchModel : PagerModel<MediaModel>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ISBN { get; set; }
        public string Company { get; set; }
    }
}
