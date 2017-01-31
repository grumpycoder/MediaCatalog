using System.Collections.Generic;

namespace MediaCatalog.Models
{
    public class MediaSummaryModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Summary { get; set; }
        public string ISBN { get; set; }
        public string CompanyName { get; set; }
        public string CompanyWebsiteUrl { get; set; }
        public string CompanyEmail { get; set; }
        public IEnumerable<StaffModel> Staff { get; set; }

        public MediaSummaryModel()
        {
            Staff = new List<StaffModel>();
        }
    }
}