using System.Threading.Tasks;
using ReservoirDevs.Common.Models;

namespace Template.Services.Abstractions.Interfaces
{
    /// <summary>
    /// Services are where the business logic takes place, combining and transforming results from one or more repositories of data
    /// </summary>
    public interface IExampleService
    {
        /// <summary>
        /// Example Get call
        /// </summary>
        /// <param name="model">Read/write model</param>
        /// <returns>Read only model</returns>
        Task<Result<Models.Immutable.Example>> GetExample(Models.Mutable.Example model);
    }
}