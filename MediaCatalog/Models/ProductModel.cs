﻿using System;
using AutoMapper;
using Heroic.AutoMapper;
using MediaCatalog.Domain;

namespace MediaCatalog.Models
{
    public class ProductModel : IMapFrom<Product>, IHaveCustomMappings
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }
        public string LCCN { get; set; }
        public string Publisher { get; set; }
        public string Summary { get; set; }
        public string Category { get; set; }
        public bool PermanentStatus { get; set; }
        public string ReviewSeason { get; set; }
        public int? ReviewYear { get; set; }

        public DateTime? ReceiptDate { get; set; }
        public bool? Purchased { get; set; }
        public bool? Donated { get; set; }


        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<Product, ProductModel>()
                .ForMember(d => d.Publisher, opt => opt.MapFrom(s => s.Publisher.Name))
                ;

        }
    }
}
