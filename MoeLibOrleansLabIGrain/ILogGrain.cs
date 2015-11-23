using System.Threading.Tasks;
using Orleans;

namespace MoeLibOrleansLabIGrain
{
    /// <summary>
    ///     Interface ILogGrain
    /// </summary>
    public interface ILogGrain : IGrainWithGuidKey
    {
        Task<string> ExceptionAsync();

        Task<string> TraceAsync();
    }
}