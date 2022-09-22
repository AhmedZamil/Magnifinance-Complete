using System.Threading.Tasks;

namespace Magnifinance.Hubs
{
    public interface IHubClient
    {
        Task BroadcastMessage();
    }
}
