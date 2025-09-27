using W04.OnlineOrdering;
var inv = new Inventory();
var p1 = new Product("A1", "USB‑C Cable", 9.99m, 0.20m);
var p2 = new Product("B2", "Wireless Mouse", 19.99m, 0.20m);
inv.Seed("A1", 100);
inv.Seed("B2", 50);

var cart = new ShoppingCart();
cart.Add(p1, 2);
cart.Add(p2, 1);

var checkout = new CheckoutService(inv, new PaymentProcessor());
var order = checkout.PlaceOrder(cart, "W04SAVE10", "TOKEN");

var summary = order.GetSummary();
// Console.WriteLine(summary);  // Intentionally commented; design skeleton.
