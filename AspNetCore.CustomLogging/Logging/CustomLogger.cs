using AspNetCore.CustomLogging.Repositories;
using Microsoft.Extensions.Logging;
using System;

namespace AspNetCore.CustomLogging.Logging
{
    public class CustomLogger : ILogger
    {
        private readonly string _categoryName;
        private readonly LogLevel _logLevel;
        private readonly Func<ILogsRepository> _logsRepositoryFactory;

        public CustomLogger(Func<ILogsRepository> logsRepositoryFactory, string categoryName, LogLevel logLevel)
        {
            _categoryName = categoryName;
            _logLevel = logLevel;
            _logsRepositoryFactory = logsRepositoryFactory; ;
        }

        public IDisposable BeginScope<TState>(TState state)
        {
            return null;
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return logLevel >= _logLevel;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            if (IsEnabled(logLevel))
            {
                var logsRepository = _logsRepositoryFactory.Invoke();
                logsRepository.Insert($"{logLevel.ToString()} - {eventId.Id} - {_categoryName} - {formatter(state, exception)}");
            }           
        }
    }
}
