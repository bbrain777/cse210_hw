namespace W04.OnlineOrdering;
public class Product
{
    private readonly string _id;
    private readonly string _name;
    private readonly decimal _unitPrice;
    private readonly decimal _taxRate;

    public Product(string id, string name, decimal price, decimal taxRate)
        => (_id, _name, _unitPrice, _taxRate) = (id, name, price, taxRate);

    public string GetId() => _id;
    public string GetName() => _name;
    public decimal GetPrice() => _unitPrice;
    public decimal GetTaxRate() => _taxRate;
}
