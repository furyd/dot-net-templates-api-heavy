using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Template.Domain.Interfaces;
using Template.Domain.V1.Models.Request;

namespace Template.Domain.V1.Interfaces
{
    /// <summary>
    /// Removes a layer of abstraction by defining what TOutput actually is
    /// </summary>
    public interface ITypedExample : IExample<IActionResult>
    {
        /// <summary>
        /// Example GET
        /// </summary>
        /// <param name="model">Example model</param>
        /// <returns>Example result</returns>
        Task<IActionResult> Get(Example model);
    }
}