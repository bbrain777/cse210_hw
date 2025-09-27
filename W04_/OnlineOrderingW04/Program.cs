using OnlineOrderingW04;
using System.Globalization;
Console.OutputEncoding = System.Text.Encoding.UTF8;
static void PrintOrder(string title, Order order)
{
    Console.WriteLine($"===== {title} =====");
    Console.WriteLine(order.GetPackingLabel());
    Console.WriteLine(order.GetShippingLabel());
    Console.WriteLine($"Total Price: {order.GetTotalPrice().ToString("C", CultureInfo.GetCultureInfo("en-US"))}");
    Console.WriteLine();
}
// Order 1: USA
var addr1 = new Address("123 Maple Street", "Provo", "UT", "USA");
var cust1 = new Customer("Allison Rose", addr1);
var order1 = new Order(cust1);
order1.AddProduct(new Product("USB-C Cable", "A1001", 9.99m, 3));
order1.AddProduct(new Product("Wireless Mouse", "B2044", 19.95m, 1));
// Order 2: Non-USA
var addr2 = new Address("45 Kingsway", "London", "Greater London", "United Kingdom");
var cust2 = new Customer("Olakunle Obademi", addr2);
var order2 = new Order(cust2);
order2.AddProduct(new Product("Mechanical Keyboard", "K3090", 59.50m, 1));
order2.AddProduct(new Product("HDMI Cable 2m", "H1800", 6.75m, 2));
order2.AddProduct(new Product("Webcam 1080p", "W5520", 29.00m, 1));
PrintOrder("ORDER 1", order1);
PrintOrder("ORDER 2", order2);
// Save output to file for screenshot
var output = new System.Text.StringBuilder();
Console.SetOut(new System.IO.StringWriter(output));
PrintOrder("ORDER 1", order1);
PrintOrder("ORDER 2", order2);
System.IO.File.WriteAllText("execution_output.txt", output.ToString());
Console.SetOut(new System.IO.StreamWriter(Console.OpenStandardOutput()){AutoFlush=true});
Console.WriteLine("Execution output saved to execution_output.txt.");
