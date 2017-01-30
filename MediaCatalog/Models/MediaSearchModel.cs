namespace MediaCatalog.Models
{
    public class MediaSearchModel : PagerModel<MediaModel>
    {
        public string Title { get; set; }
        public string ISBN { get; set; }
        public string Company { get; set; }
    }
}
