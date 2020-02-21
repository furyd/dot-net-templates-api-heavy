using AutoMapper;
using System.Threading.Tasks;
using Template.Models;
using Template.Repositories.Abstractions.Interfaces;
using Template.Services.Abstractions.Interfaces;

namespace Template.Services.Example.Implementation
{
    public class ExampleService : IExampleService
    {
        private readonly IExampleRepository _exampleRepository;
        private readonly IMapper _mapper;

        public ExampleService(IExampleRepository exampleRepository, IMapper mapper)
        {
            _exampleRepository = exampleRepository;
            _mapper = mapper;
        }
        public async Task<Result<Abstractions.Models.Immutable.Example>> GetExample(Abstractions.Models.Mutable.Example model)
        {
            var repositoryModel = _mapper.Map<Repositories.Abstractions.Models.Mutable.Example>(model);

            var responseModel = await _exampleRepository.RetrieveExample(repositoryModel);

            if (responseModel.IsSuccessful)
            {
                return new Result<Abstractions.Models.Immutable.Example>(_mapper.Map<Abstractions.Models.Immutable.Example>(responseModel.Item));
            }

            return new Result<Abstractions.Models.Immutable.Example>(responseModel.Exception);
        }
    }
}