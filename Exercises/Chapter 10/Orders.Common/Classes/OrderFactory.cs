namespace Orders.Common;

public class OrderFactory
{
    List<Order> Orders { get; } = new List<Order>();

    public void Add(string customer, string address)
    {
        try
        {
            Orders.Add(new Order(Orders.Count + 1, customer, address));
        }
        catch
        {
            throw;
        }
    }
    public List<Order> Get() => Orders;
    public Order? Latest() => Orders.LastOrDefault();
}
