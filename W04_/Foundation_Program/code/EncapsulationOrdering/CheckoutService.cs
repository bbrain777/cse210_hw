namespace W04.OnlineOrdering;
public class CheckoutService
{
    private readonly Inventory _inventory;
    private readonly PaymentProcessor _payments;

    public CheckoutService(Inventory inv, PaymentProcessor pay)
        => (_inventory, _payments) = (inv, pay);

    public Order PlaceOrder(ShoppingCart cart, string discountCode, string paymentToken)
    {
        // Reserve stock
        foreach (var item in cart.GetItems())
            _inventory.Reserve(item.GetProduct().GetId(), item.GetQuantity());

        var subtotal = cart.GetSubtotal();
        var discount = cart.GetDiscount(discountCode);
        var tax = cart.GetTaxTotal(discountCode);
        var total = subtotal - discount + tax;

        var auth = _payments.Authorize(total, paymentToken);
        _payments.Capture(auth);

        foreach (var item in cart.GetItems())
            _inventory.Commit(item.GetProduct().GetId(), item.GetQuantity());

        return new Order(Guid.NewGuid().ToString("N")[..8], cart.GetItems().ToList(), subtotal, discount, tax, total);
    }
}
