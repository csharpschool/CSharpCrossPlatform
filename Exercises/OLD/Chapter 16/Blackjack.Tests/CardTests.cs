namespace Blackjack.Tests;

public class CardTests
{
    [Fact]
    public void CanCreateVisibleCardInstance()
    {
        // Arrange
        Card card = new("🂡", 1);

        // Act

        // Assert
        Assert.NotNull(card);
        Assert.Equal("🂡", card.Symbol);
        Assert.Equal(1, card.Value);
    }

    [Fact]
    public void CanCreateHiddenCardInstance()
    {
        // Arrange
        Card card = new("🂡", 1, true);

        // Act

        // Assert
        Assert.NotNull(card);
        Assert.Equal("🂠", card.Symbol);
        Assert.Equal(0, card.Value);
    }
}