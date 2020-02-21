using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace Template.Extensions
{
    public static class LoggerExtensions
    {
        public static IDisposable BeginScope(this ILogger logger, string methodName, IDictionary<string, string> values)
        {
            values = values ?? new Dictionary<string, string>();

            values.Add("method", methodName);

            return logger.BeginScope(null);
        }

    }
}
