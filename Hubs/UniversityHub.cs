using Microsoft.AspNetCore.SignalR;
using System.Threading;
using System.Threading.Tasks;

namespace Magnifinance.Hubs
{
    public class UniversityHub : Hub
    {
        private readonly IOrderChecker _orderChecker;

        public UniversityHub(IOrderChecker orderChecker)
        {
            _orderChecker = orderChecker;
        }

        public async Task GetUpdateForOrder()
        {
            int orderId = 1;
            CheckResult result;
            do
            {
                result = _orderChecker.GetUpdate(orderId);
                Thread.Sleep(1000);
                if (result.New)
                    await Clients.Caller.SendAsync("ReceiveOrderUpdate",
                        result.Update);
            } while (!result.Finished);
            await Clients.Caller.SendAsync("Finished");
        }

        //public async Task GetUpdateForOrder(int orderId)
        //{
        //    CheckResult result;
        //    do
        //    {
        //        result = _orderChecker.GetUpdate(orderId);
        //        Thread.Sleep(1000);
        //        if (result.New)
        //            await Clients.Caller.SendAsync("ReceiveOrderUpdate",
        //                result.Update);
        //    } while (!result.Finished);
        //    await Clients.Caller.SendAsync("Finished");
        //}
    }
}
