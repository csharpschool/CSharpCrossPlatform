namespace Orders.Tests;

public class OrderFactoryTests
{
    [Fact]
    public void CanCreateOrderFactoryInstance()
    {
        OrderFactory orderFactory = new();
        var orders = orderFactory.Get();
        var lastOrder = orderFactory.Latest();

        Assert.NotNull(orderFactory);
        Assert.Empty(orders);
        Assert.Equal(default, lastOrder);
    }

    [Fact]
    public void AddMethodInOrderFactoryThrowsExceptionForWrongCustomerName()
    {
        Assert.Throws<ArgumentException>(() =>
        {
            var orderFactory = new OrderFactory();
            orderFactory.Add("", "Address 1");
        });
    }

    [Fact]
    public void AddMethodInOrderFactoryThrowsExceptionForWrongAddress()
    {
        Assert.Throws<ArgumentException>(() =>
        {
            var orderFactory = new OrderFactory();
            orderFactory.Add("Customer 1", "");
        });
    }
}