namespace W04.OnlineOrdering;
public class Inventory
{
    private readonly Dictionary<string,int> _stock = new();
    public void Seed(string productId, int qty) => _stock[productId] = qty;

    public bool IsAvailable(string productId, int qty)
        => _stock.TryGetValue(productId, out var have) && have >= qty;

    public void Reserve(string productId, int qty)
    {
        if (!IsAvailable(productId, qty)) throw new InvalidOperationException("Insufficient stock");
        _stock[productId] -= qty;
    }

    public void Release(string productId, int qty) => _stock[productId] = _stock.GetValueOrDefault(productId) + qty;
    public void Commit(string productId, int qty) { /* finalization no-op for demo */ }
}
