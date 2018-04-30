using System;

namespace AspNetCore.CustomLogging.Repositories
{
    public class LogsRepository : ILogsRepository
    {
        private readonly Guid _guid;

        public LogsRepository()
        {
            _guid = Guid.NewGuid();
        }

        public void Insert(string log)
        {
            Console.WriteLine($"{_guid} - {log}");
        }
    }
}
