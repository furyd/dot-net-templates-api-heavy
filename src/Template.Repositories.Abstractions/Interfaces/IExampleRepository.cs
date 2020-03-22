using System.Threading.Tasks;
using ReservoirDevs.Common.Models;

namespace Template.Repositories.Abstractions.Interfaces
{
    /// <summary>
    /// Repositories are where data is extracted from data sources and transformed into useful models for further up the call chain
    /// </summary>
    public interface IExampleRepository
    {
        /// <summary>
        /// Example Retrieve call
        /// </summary>
        /// <param name="model">Read/write model</param>
        /// <returns>Read only model</returns>
        Task<Result<Models.Immutable.Example>> RetrieveExample(Models.Mutable.Example model);
    }
}