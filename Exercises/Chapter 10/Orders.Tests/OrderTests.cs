namespace Orders.Tests;

public class OrderTests
{
    [Fact]
    public void CanCreateOrderInstance()
    {
        Order order = new(1, "John Doe", "Address 1");

        Assert.NotNull(order);
        Assert.Equal(1, order.Id);
        Assert.Equal("John Doe", order.Customer);
        Assert.Equal("Address 1", order.Address);
        Assert.Empty(order.Items);
    }

    [Fact]
    public void CreateOrderExceptionWrongId()
    {
        Assert.Throws<ArgumentException>(() =>
        {
            var order = new Order(-1, "Customer 1", "Address 1");
        });
    }

    [Fact]
    public void CreateOrderExceptionEmptyCustomerName()
    {
        Assert.Throws<ArgumentException>(() =>
        {
            var order = new Order(1, "", "Address 1");
        });
    }

    [Fact]
    public void CreateOrderExceptionEmptyAddress()
    {
        Assert.Throws<ArgumentException>(() =>
        {
            var order = new Order(1, "Customer", "");
        });
    }
}