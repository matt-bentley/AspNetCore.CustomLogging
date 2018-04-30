using AspNetCore.CustomLogging.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;

namespace AspNetCore.CustomLogging.Logging
{
    public class CustomLoggerProvider : ILoggerProvider
    {
        private readonly LogLevel _logLevel;
        private readonly Func<ILogsRepository> _logRepositoryFactory;

        public CustomLoggerProvider(LogLevel logLevel, Func<ILogsRepository> logRepositoryFactory)
        {
            _logLevel = logLevel;
            _logRepositoryFactory = logRepositoryFactory;
        }

        public ILogger CreateLogger(string categoryName)
        {
            return new CustomLogger(_logRepositoryFactory, categoryName, _logLevel);
        }

        public void Dispose()
        {
            
        }
    }
}
