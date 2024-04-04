using PokemonsViaTdd;

namespace PokemonsViaTddTests;

[TestFixture]
public class GameServiceTests
{
    [SetUp]
    public void SetUp()
    {
    }

    private GameService CreateService()
    {
        return new GameService();
    }

    [Test] 
    public void PlayerGetsNotifiedAskingPlayerIfHeWantsToEvolveHisPokemonTest()
    {
        // Arrange
        var sut = CreateService();
        var player = new Player();
        var pikachu = new Pikachu();

        // Act
        sut.BattleWonBy(pikachu, player);

        // Assert
        Assert.IsTrue(player.AskedToEvolve);
    }
}