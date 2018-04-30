using AspNetCore.CustomLogging.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;

namespace AspNetCore.CustomLogging.Logging
{
    public static class CustomLoggerExtensions
    {
        public static ILoggerFactory AddCustomLogger(this ILoggerFactory loggerFactory, IConfiguration configuration, Func<ILogsRepository> logRepositoryFactory)
        {
            var logLevel = GetLogLevel(configuration["LogLevel:Default"]);
            loggerFactory.AddProvider(new CustomLoggerProvider(logLevel, logRepositoryFactory));
            return loggerFactory;
        }

        public static ILoggerFactory AddCustomLogger(this ILoggerFactory loggerFactory, LogLevel logLevel, Func<ILogsRepository> logRepositoryFactory)
        {
            loggerFactory.AddProvider(new CustomLoggerProvider(logLevel, logRepositoryFactory));
            return loggerFactory;
        }

        private static LogLevel GetLogLevel(string logLevel)
        {
            return Enum.Parse<LogLevel>(logLevel);
        }
    }
}
