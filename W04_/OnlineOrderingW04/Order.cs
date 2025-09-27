using System.Text;
namespace OnlineOrderingW04;
public class Order
{
    private readonly List<Product> _products = new();
    private readonly Customer _customer;
    public Order(Customer customer) { _customer = customer; }
    public void AddProduct(Product p) => _products.Add(p);
    private decimal GetShippingCost() => _customer.IsInUSA() ? 5m : 35m;
    public decimal GetTotalPrice() => _products.Sum(p => p.GetTotalCost()) + GetShippingCost();
    public string GetPackingLabel()
    {
        var sb = new StringBuilder();
        sb.AppendLine("PACKING LABEL");
        sb.AppendLine(new string('-', 30));
        foreach (var p in _products) sb.AppendLine($"{p.Name} — ID: {p.ProductId}");
        return sb.ToString();
    }
    public string GetShippingLabel()
    {
        var sb = new StringBuilder();
        sb.AppendLine("SHIPPING LABEL");
        sb.AppendLine(new string('-', 30));
        sb.AppendLine(_customer.Name);
        sb.AppendLine(_customer.Address.GetFullAddress());
        return sb.ToString();
    }
}
