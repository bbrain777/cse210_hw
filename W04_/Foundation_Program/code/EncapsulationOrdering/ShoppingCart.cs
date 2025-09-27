namespace W04.OnlineOrdering;
public class ShoppingCart
{
    private readonly Dictionary<string, CartItem> _items = new();
    private readonly DiscountPolicy _discountPolicy = new();

    public void Add(Product p, int qty = 1)
    {
        if (_items.TryGetValue(p.GetId(), out var existing))
            existing.SetQuantity(existing.GetQuantity() + qty);
        else
            _items[p.GetId()] = new CartItem(p, qty);
    }

    public void Update(string productId, int qty)
    {
        if (!_items.ContainsKey(productId)) return;
        if (qty <= 0) _items.Remove(productId);
        else _items[productId].SetQuantity(qty);
    }

    public void Remove(string productId) => _items.Remove(productId);
    public void Clear() => _items.Clear();

    public IReadOnlyCollection<CartItem> GetItems() => _items.Values.ToList().AsReadOnly();
    public decimal GetSubtotal() => _items.Values.Sum(i => i.GetLineSubtotal());
    public decimal GetDiscount(string code) => _discountPolicy.ComputeDiscount(GetSubtotal(), code);
    public decimal GetTaxTotal(string code)
    {
        // Tax is computed per-line in CartItem; here we recompute for simplicity
        return _items.Values.Sum(i => i.GetLineTax());
    }
    public decimal GetGrandTotal(string code) => GetSubtotal() - GetDiscount(code) + GetTaxTotal(code);
}
