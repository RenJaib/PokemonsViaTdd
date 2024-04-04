using PokemonsViaTdd;
using System.Reflection;

namespace PokemonsViaTddTests;

// TDD(Test Driven Development) dev - life cycle
// 1.Write a test - run it and see it fails
// 2. Fix your code, so the tests will PASS
// 3. Refactor code and unit tests
// 
// TODO:
// Pikachu cannot level down
// Pokemon gains experience points to level up
// Pokemon cannot change levels without expericence points
// Pikachu can learn a different move on level 3
// 
// done: Pokemon cannot change its level directly
// done: when pickachu is created it starts from level 1
// done: Pikachu attak is Thunderstrike
// done: attack on level 1 should equal to 10 
public class PikachuTests
{
    [SetUp]
    public void Setup()
    {
    }

    // We want our Pikachu to gain Experience after a battle
    [Test]
    public void PikachuGainsExpAfterBattleTest()
    {
        // Arrange
        var pokemon = new Pikachu();
        var player = new Player();
        var expectedExp = 1000;

        var battleService = new GameService();

        // Act
        battleService.BattleWonBy(pokemon, player);

        // Assert
        Assert.AreEqual(expectedExp, pokemon.ExperiencePoints);
    }

    // We want to see if Pikachu can level up after gaining enough experience
    [Test]
    public void PikachuCanLevelUpAfterGainingEnoughExpTest()
    {
        // Arrange
        var pokemon = new Pikachu();
        var player = new Player();
        var expectedLevel = 2;

        var battleService = new GameService();
        battleService.LevelUpEvent += (sender, args) => pokemon.LevelUp();

        // Act
        battleService.BattleWonBy(pokemon, player);

        // Assert
        Assert.AreEqual(expectedLevel, pokemon.Level);
    }

    [Test]
    public void PikachuAttakIsThunderstrikeAndOnLevel1ShouldEqualTo10()
    {
        var expectedAttakType = "Thunderstrike";
        var expectedAttakPower = 10;
        var sut = new Pikachu();

        var actualAttack = sut.Attack();

        Assert.AreEqual(expectedAttakType, actualAttack.Type);
        Assert.AreEqual(expectedAttakPower, actualAttack.Power);
    }

    [Test]
    public void WhenPickachuIsCreatedItStartsFromLevel_1_Test()
    {
        var expectedLevel = 1;
        var sut = new Pikachu();

        var actualLevel = sut.Level;

        Assert.AreEqual(expectedLevel, actualLevel);
    }

    [Test]
    public void FunctionalLevelUpTest()
    {
        //Arrange
        var expectedLevel = 2;
        var sut = new Pikachu();

        //Act
        sut.LevelUp();
        var pikachuLevel = sut.Level;

        //var pikachuLevel = sut.PureFunctionLevelUp(sut.Level);

        //Assert
        Assert.AreEqual(expectedLevel, pikachuLevel);
    }

    [Test]
    public void PikaccuDidNotEvolvedWhen_LeveledUpOnce()
    {
        //Arrange
        var expectedToEvolve = false;
        var sut = new Pikachu();

        //Act 
        sut.LevelUp();

        //Assert
        Assert.AreEqual(expectedToEvolve, sut.IsEvolved);
    }

    [Test]
    public void PikaccuEvolvedWhenReachedLevel_10()
    {
        //Arrange
        var expectedToEvolve = true;
        var sut = new Pikachu();

        //Act 
        var pikachuLevel = sut.Level;
        while (pikachuLevel < 10)
        {
            sut.LevelUp();
            pikachuLevel = sut.Level;
        }

        //Assert
        Assert.AreEqual(expectedToEvolve, sut.IsEvolved);
    }
}