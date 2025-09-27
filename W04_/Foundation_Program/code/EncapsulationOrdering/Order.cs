namespace W04.OnlineOrdering;
public class Order
{
    private readonly string _orderId;
    private readonly List<CartItem> _lines;
    private readonly decimal _subtotal;
    private readonly decimal _discount;
    private readonly decimal _tax;
    private readonly decimal _total;

    public Order(string orderId, List<CartItem> lines, decimal subtotal, decimal discount, decimal tax, decimal total)
        => (_orderId, _lines, _subtotal, _discount, _tax, _total) = (orderId, lines, subtotal, discount, tax, total);

    public string GetSummary()
        => $"Order {_orderId}: Subtotal={_subtotal:C}, Discount={_discount:C}, Tax={_tax:C}, Total={_total:C}";
}
