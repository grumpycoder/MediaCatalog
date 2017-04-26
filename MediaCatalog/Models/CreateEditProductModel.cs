using System;
using AutoMapper;
using Heroic.AutoMapper;
using MediaCatalog.Domain;

namespace MediaCatalog.Models
{
    public class CreateEditProductModel : IMapFrom<Product>, IHaveCustomMappings
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Summary { get; set; }
        public string ISBN { get; set; }
        public int PublisherId { get; set; }
        public string LCCN { get; set; }
        public DateTime? ReceiptDate { get; set; }
        public bool Reviewed { get; set; }
        public bool Purchased { get; set; }
        public bool Donated { get; set; }
        public string Category { get; set; }
        public bool PermanentStatus { get; set; }
        public string ReviewSeason { get; set; }
        public int? ReviewYear { get; set; }


        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<Product, CreateEditProductModel>()
                .ForMember(d => d.PublisherId, opt => opt.MapFrom(s => s.PublisherId))
                .ReverseMap();
        }
    }
}
