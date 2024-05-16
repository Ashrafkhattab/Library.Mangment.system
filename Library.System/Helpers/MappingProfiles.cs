using AutoMapper;
using Library.DAL.Model;
using Library.System.DTOs;

namespace Library.System.Helpers
{
    public class MappingProfiles  :Profile
    {
        public MappingProfiles()
        {
            CreateMap<BookDTO,Book>().ForMember(b=> b.NormalizTitle, o=> o.MapFrom(b=>b.Title.ToUpper())).ReverseMap();
            CreateMap<BookUpdateDTO,Book>().ForMember(b=> b.NormalizTitle, o=> o.MapFrom(b=>b.Title.ToUpper())).ReverseMap();
            CreateMap<BookUpdateDTO, BookDTO>().ReverseMap();
            CreateMap<PatronDTO,Patron>().ForMember(b => b.NormalizeName, o => o.MapFrom(b => b.Name.ToUpper())).ReverseMap(); 
            CreateMap<PatronDTO, PatronUpdateDTO>().ReverseMap();
            CreateMap<PatronUpdateDTO,Patron>().ForMember(b => b.NormalizeName, o => o.MapFrom(b => b.Name.ToUpper())).ReverseMap();
            CreateMap<BorrowingDTO,BorrowingRecord>().ReverseMap();
            CreateMap<BorrowingDTO, BorrowingUpdateDTO>().ReverseMap();
            CreateMap<BorrowingUpdateDTO,BorrowingRecord>().ReverseMap();
        }
    }
}
