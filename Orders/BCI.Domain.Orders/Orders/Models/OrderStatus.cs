namespace BCI.Orders.Domain.Orders.Models
{
    public enum OrderStatus : byte
    {
        WaitForPaying = 0,
        WaitForShipping = 1,
        WaitForReceiving = 2,
        WaitForCommenting = 3,
        HaveCommented = 4
    }
}