namespace Magnifinance.Hubs
{
    public interface IOrderChecker
    {
        CheckResult GetUpdate(int orderNo);
    }
}
