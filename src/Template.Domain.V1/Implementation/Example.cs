using System;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Template.Domain.V1.Interfaces;
using Template.Exceptions;
using Template.Services.Abstractions.Interfaces;

namespace Template.Domain.V1.Implementation
{
    public class Example : ITypedExample
    {
        private readonly IExampleService _exampleService;
        private readonly IMapper _mapper;

        public Example(IExampleService exampleService, IMapper mapper)
        {
            _exampleService = exampleService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Get(Models.Request.Example model)
        {
            var serviceModel = _mapper.Map<Services.Abstractions.Models.Mutable.Example>(model);
            var responseModel = await _exampleService.GetExample(serviceModel);

            if (responseModel.IsSuccessful)
            {
                return new OkObjectResult(_mapper.Map<Models.Response.Example>(responseModel.Item));
            }

            return MapException(responseModel.Exception);
        }

        private static IActionResult MapException(Exception baseException)
        {
            switch (baseException)
            {
                case ExampleException exception:
                    return new BadRequestObjectResult(new ProblemDetails{ Type = baseException.GetType().FullName, Detail = exception.ExampleProperty});
                default:
                    return new BadRequestObjectResult(new ProblemDetails { Type = baseException.GetType().FullName, Detail = baseException.Message });
            }
        }
    }
}