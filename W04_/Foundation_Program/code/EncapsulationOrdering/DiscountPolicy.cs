namespace W04.OnlineOrdering;
public class DiscountPolicy
{
    public bool Validate(string code) => string.IsNullOrWhiteSpace(code) || code is "W04SAVE10";
    public decimal ComputeDiscount(decimal subtotal, string code)
        => code == "W04SAVE10" ? subtotal * 0.10m : 0m;
}
