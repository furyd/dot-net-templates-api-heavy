using AutoMapper;
using System;
using System.Threading.Tasks;
using ReservoirDevs.Common.Models;
using Template.Exceptions;
using Template.Repositories.Abstractions.Interfaces;
using Template.Repositories.Example.DataTransferObjects;

namespace Template.Repositories.Example.Implementation
{
    public class ExampleRepository : IExampleRepository
    {
        private readonly IMapper _mapper;

        public ExampleRepository(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<Result<Abstractions.Models.Immutable.Example>> RetrieveExample(Abstractions.Models.Mutable.Example model)
        {
            if (model.ExampleProperty.Equals("error1"))
            {
                return new Result<Abstractions.Models.Immutable.Example>(new Exception("errored"));
            }

            if (model.ExampleProperty.Equals("error2"))
            {
                return new Result<Abstractions.Models.Immutable.Example>(new ExampleException("errored"));
            }

            var dto = _mapper.Map<ExampleDTO>(model);

            var responseModel = _mapper.Map<Abstractions.Models.Immutable.Example>(dto);

            return await Task.FromResult(new Result<Abstractions.Models.Immutable.Example>(responseModel));
        }
    }
}