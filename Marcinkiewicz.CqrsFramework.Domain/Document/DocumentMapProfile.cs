using AutoMapper;

namespace Marcinkiewicz.CqrsFramework.Domain.Document
{
    internal class DocumentMapProfile : Profile
    {
        /// <summary>
        /// Define mapping rules for document
        /// </summary>
        public DocumentMapProfile()
        {
            CreateMap<Data.Models.Accountant, Models.DocumentDto>()
                .ForMember(m => m.Id, opt => opt.MapFrom(src => src.Id));
        }
    }
}
