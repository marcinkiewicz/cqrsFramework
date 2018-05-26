using AutoMapper;

namespace Marcinkiewicz.CqrsFramework.Domain.Accountant
{
    internal class AccountantMapProfile : Profile
    {
        /// <summary>
        /// Define mapping rules for accountant
        /// </summary>
        public AccountantMapProfile()
        {
            CreateMap<Data.Models.Accountant, Models.AccountantDto>()
                .ForMember(m => m.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(m => m.FirstName, opt => opt.MapFrom(src => src.FirstName))
                .ForMember(m => m.LastName, opt => opt.MapFrom(src => src.LastName))
                .ForMember(m => m.DocumentsList, opt => opt.MapFrom(src => src.DocumentsList));
        }
    }
}
