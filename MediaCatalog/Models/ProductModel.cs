using AutoMapper;
using Heroic.AutoMapper;
using MediaCatalog.Domain;

namespace MediaCatalog.Models
{
    public class ProductModel : IMapFrom<Product>, IHaveCustomMappings
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ISBN { get; set; }
        public string Company { get; set; }
        public string Summary { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<Product, ProductModel>()
                .ForMember(d => d.Company, opt => opt.MapFrom(s => s.Publisher.Name))
                ;

        }
    }
}
