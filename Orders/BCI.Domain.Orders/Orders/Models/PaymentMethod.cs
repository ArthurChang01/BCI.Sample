namespace BCI.Orders.Domain.Orders.Models
{
    public enum PaymentMethod : byte
    {
        AliPay = 0,
        WechatPay = 1,
        Cash = 2
    }
}