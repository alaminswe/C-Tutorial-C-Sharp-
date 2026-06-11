public class Order
{
    public int Id { get; set; }
    public string ProductName { get; set; }
    public double Amount { get; set; }
    public string CustomerName { get; set; }

    // ToString() override 
    public override string ToString()
    {
        return $"Order #{Id} | Product: {ProductName} | Amount: {Amount} BDT | Customer: {CustomerName}";
    }
}