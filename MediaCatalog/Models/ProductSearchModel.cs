namespace MediaCatalog.Models
{
    public class ProductSearchModel : PagerModel<ProductModel>
    {
        public string Title { get; set; }
        public string ISBN { get; set; }
        public string Publisher { get; set; }
    }
}
