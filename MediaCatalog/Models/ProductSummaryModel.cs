﻿using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Heroic.AutoMapper;
using MediaCatalog.Domain;

namespace MediaCatalog.Models
{
    public class ProductSummaryModel : IMapFrom<Product>, IHaveCustomMappings
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string LCCN { get; set; }
        public string Summary { get; set; }
        public string ISBN { get; set; }
        public string Publisher { get; set; }
        public string Website { get; set; }
        public string Email { get; set; }
        public DateTime? ReceiptDate { get; set; }
        public string ReviewSeason { get; set; }
        public int? ReviewYear { get; set; }
        public string Review { get; set; }
        public bool? Purchased { get; set; }
        public bool? Donated { get; set; }
        public int PublisherId { get; set; }

        public string Category { get; set; }
        public bool PermanentStatus { get; set; }


        public List<Staff> Staff { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<Product, ProductSummaryModel>()
                .ForMember(d => d.Publisher, opt => opt.MapFrom(s => s.Publisher.Name))
                .ForMember(d => d.Website, opt => opt.MapFrom(s => s.Publisher.WebsiteUrl))
                .ForMember(d => d.Email, opt => opt.MapFrom(s => s.Publisher.Email))
                .ForMember(d => d.Staff, opt => opt.MapFrom(s => s.Staff))
                .ForMember(d => d.PublisherId, opt => opt.MapFrom(s => s.PublisherId))
                .ForMember(d => d.Review, opt => opt.ResolveUsing(s => $"{s.ReviewSeason} {s.ReviewYear}"))
            ;

        }
    }

    public class StaffMemberModel : IMapFrom<StaffMember>, IHaveCustomMappings
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public int StaffId { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<StaffMember, StaffMemberModel>()
                .ForMember(d => d.Firstname, opt => opt.MapFrom(s => s.Staff.Firstname))
                .ForMember(d => d.Lastname, opt => opt.MapFrom(s => s.Staff.Lastname))
                .ForMember(d => d.Email, opt => opt.MapFrom(s => s.Staff.Email))
                .ForMember(d => d.Role, opt => opt.MapFrom(s => s.Staff.Role))
                .ForMember(d => d.StaffId, opt => opt.MapFrom(s => s.Staff.Id))
                ;
        }
    }
}
