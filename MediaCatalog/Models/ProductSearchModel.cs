namespace MediaCatalog.Models
{
    public class ProductSearchModel : PagerModel<ProductModel>
    {
        public string Title { get; set; }
        public string ISBN { get; set; }
        public string Publisher { get; set; }
        public string Author { get; set; }
        public string LCCN { get; set; }
        public string Category { get; set; }
        public bool? PermanentStatus { get; set; } = null;
    }
}
