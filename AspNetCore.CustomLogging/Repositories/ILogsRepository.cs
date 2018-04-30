
namespace AspNetCore.CustomLogging.Repositories
{
    public interface ILogsRepository
    {
        void Insert(string log);
    }
}
