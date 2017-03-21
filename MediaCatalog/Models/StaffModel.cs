using AutoMapper;
using Heroic.AutoMapper;
using MediaCatalog.Domain;

namespace MediaCatalog.Models
{
    public class StaffModel : IMapFrom<Staff>, IHaveCustomMappings
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public int StaffMemberId { get; set; }
        public int CompanyId { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<Staff, StaffModel>()
                .ForMember(d => d.Firstname, opt => opt.MapFrom(s => s.Firstname))
                .ForMember(d => d.Lastname, opt => opt.MapFrom(s => s.Lastname))
                .ForMember(d => d.Email, opt => opt.MapFrom(s => s.Email))
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(d => d.StaffMemberId, opt => opt.MapFrom(s => s.Id))
                .ReverseMap();


            //configuration.CreateMap<StaffMember, StaffModel>()
            //    .ForMember(d => d.Firstname, opt => opt.MapFrom(s => s.Staff.Firstname))
            //    .ForMember(d => d.Lastname, opt => opt.MapFrom(s => s.Staff.Lastname))
            //    .ForMember(d => d.Email, opt => opt.MapFrom(s => s.Staff.Email))
            //    .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Staff.Id))
            //    .ForMember(d => d.StaffMemberId, opt => opt.MapFrom(s => s.Id))
            //    .ForMember(d => d.CompanyId, opt => opt.MapFrom(s => s.CompanyId))
            //    .ReverseMap();

        }
    }
}