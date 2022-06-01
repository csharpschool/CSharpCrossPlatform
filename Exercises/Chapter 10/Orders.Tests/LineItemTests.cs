namespace Orders.Tests;

public class LineItemTests
{
    [Fact]
    public void CanCreateLineItemInstance()
    {
        LineItem item = new(1, 2, "Product 1", 3, 10, 50);

        Assert.NotNull(item);
        Assert.Equal(1, item.OrderId);
        Assert.Equal(2, item.Id);
        Assert.Equal("Product 1", item.Product);
        Assert.Equal(3, item.Quantity);
        Assert.Equal(10, item.Price);
        Assert.Equal(0.5, item.Vat);
        Assert.Equal(45, item.Total);
        Assert.Equal(15, item.VatCost);
    }

    [Fact]
    public void CreateLineItemExceptionWrongId()
    {
        Assert.Throws<ArgumentException>(() =>
        {
            var item = new LineItem(1, -1, "Product 1", 2, 10, 50);
        });
    }

    [Fact]
    public void CreateLineItemExceptionEmptyProductName()
    {
        Assert.Throws<ArgumentException>(() =>
        {
            var item = new LineItem(1, 1, "", 2, 10, 50);
        });
    }

    [Fact]
    public void CreateLineItemExceptionWrongQuantity()
    {
        Assert.Throws<ArgumentException>(() =>
        {
            var item = new LineItem(1, 1, "Product 1", 0, 10, 50);
        });
    }

    [Fact]
    public void CreateLineItemExceptionWrongPrice()
    {
        Assert.Throws<ArgumentException>(() =>
        {
            var item = new LineItem(1, 1, "Product 1", 2, 0, 50);
        });
    }

    [Fact]
    public void CreateLineItemExceptionWrongVat()
    {
        Assert.Throws<ArgumentException>(() =>
        {
            var item = new LineItem(1, 1, "Product 1", 0, 10, -1);
        });
    }
}