using System.Threading.Tasks;

namespace Intra.NET.Services
{
    public interface IFirstRunDisplayService
    {
        Task ShowIfAppropriateAsync();
    }
}
