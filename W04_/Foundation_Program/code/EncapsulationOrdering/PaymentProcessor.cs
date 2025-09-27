namespace W04.OnlineOrdering;
public class PaymentProcessor
{
    public string Authorize(decimal amount, string paymentToken) => "AUTH123";
    public void Capture(string authId) { /* capture simulated */ }
}
