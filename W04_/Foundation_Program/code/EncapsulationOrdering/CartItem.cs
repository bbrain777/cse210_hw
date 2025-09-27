namespace W04.OnlineOrdering;
public class CartItem
{
    private readonly Product _product;
    private int _quantity;

    public CartItem(Product product, int qty)
    {
        _product = product;
        SetQuantity(qty);
    }

    public void SetQuantity(int qty)
    {
        if (qty <= 0) throw new ArgumentOutOfRangeException(nameof(qty));
        _quantity = qty;
    }

    public Product GetProduct() => _product;
    public int GetQuantity() => _quantity;
    public decimal GetLineSubtotal() => _product.GetPrice() * _quantity;
    public decimal GetLineTax() => GetLineSubtotal() * _product.GetTaxRate();
    public decimal GetLineTotal() => GetLineSubtotal() + GetLineTax();
}
