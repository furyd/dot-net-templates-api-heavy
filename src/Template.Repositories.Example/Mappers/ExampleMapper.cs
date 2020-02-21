using AutoMapper;
using Template.Repositories.Example.DataTransferObjects;

namespace Template.Repositories.Example.Mappers
{
    public class ExampleMapper : Profile
    {
        public ExampleMapper()
        {
            CreateMap<Abstractions.Models.Mutable.Example, ExampleDTO>();
            CreateMap<ExampleDTO, Abstractions.Models.Immutable.Example>();
        }
    }
}