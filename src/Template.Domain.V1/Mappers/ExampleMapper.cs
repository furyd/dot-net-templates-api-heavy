using AutoMapper;

namespace Template.Domain.V1.Mappers
{
    public class ExampleMapper : Profile
    {
        public ExampleMapper()
        {
            CreateMap<Models.Request.Example, Services.Abstractions.Models.Mutable.Example>();
            CreateMap<Services.Abstractions.Models.Immutable.Example, Models.Response.Example>();
        }
    }
}