using AutoMapper;

namespace Template.Services.Example.Mappers
{
    public class ExampleMapper : Profile
    {
        public ExampleMapper()
        {
            CreateMap<Abstractions.Models.Mutable.Example, Repositories.Abstractions.Models.Mutable.Example>();
            CreateMap<Repositories.Abstractions.Models.Immutable.Example, Abstractions.Models.Immutable.Example>();
        }
    }
}