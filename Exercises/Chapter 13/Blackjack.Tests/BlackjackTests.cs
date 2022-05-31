namespace Blackjack.Tests;
using BlackJack.Classes;

public class BlackjackTests
{
    [Fact]
    public void CanCreateInstance()
    {
        // Arrange
        Blackjack game = new();

        // Act
        var dealerCards = game.GetDealerCards();
        var playerCards = game.GetPlayerCards();
        var dealerScore = game.GetDealerScore();
        var playerScore = game.GetPlayerScore();

        // Assert
        Assert.NotNull(game);
        Assert.Empty(dealerCards);
        Assert.Empty(playerCards);
        Assert.Equal(0, dealerScore);
        Assert.Equal(0, playerScore);
        Assert.False(game.Stays);
        Assert.Equal("", game.Winner);
    }
    [Fact]
    public void CanStartNewGame()
    {
        // Arrange
        Blackjack game = new();

        // Act
        game.NewGame();
        var dealerCards = game.GetDealerCards();
        var playerCards = game.GetPlayerCards();
        var dealerScore = game.GetDealerScore();
        var playerScore = game.GetPlayerScore();

        // Assert
        Assert.NotNull(game);
        Assert.Equal(2, dealerCards.Length);
        Assert.Equal(2, playerCards.Length);
        Assert.NotEqual(0, dealerScore);
        Assert.NotEqual(0, playerScore);
        Assert.False(game.Stays);
        Assert.Equal("", game.Winner);
    }

    [Fact]
    public void CanDealPlayerCard()
    {
        // Arrange
        Blackjack game = new();

        // Act
        game.NewGame();
        var playerScore = game.GetPlayerScore();
        game.DealPlayerCard();
        var playerCards = game.GetPlayerCards();
        var newPlayerScore = game.GetPlayerScore();
        var card3Value = playerCards.Last().Value;

        // Assert
        Assert.NotNull(game);
        Assert.Equal(3, playerCards.Length);
        Assert.Equal(newPlayerScore, playerScore + card3Value);
        Assert.Equal("", game.Winner);
    }

    [Fact]
    public void PlayerCanStay()
    {
        // Arrange
        Blackjack game = new();

        // Act
        game.NewGame();
        game.Stay();

        // Assert
        Assert.NotNull(game);
        Assert.NotEqual("", game.Winner);
    }
}