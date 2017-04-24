using System.ComponentModel.DataAnnotations;
using AutoMapper;
using Heroic.AutoMapper;
using MediaCatalog.Domain;

namespace MediaCatalog.Models
{
    public class CreateEditPublisherModel : IMapFrom<Publisher>, IHaveCustomMappings
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string WebsiteUrl { get; set; }
        public string Email { get; set; }

        public string Street { get; set; }
        public string Street2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zipcode { get; set; }

        public string Phone { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<Publisher, CreateEditPublisherModel>()
                .ForMember(d => d.Name, opt => opt.MapFrom(s => s.Name))
                .ReverseMap();
        }
    }
}