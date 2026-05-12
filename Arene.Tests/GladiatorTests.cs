using System;
using Xunit;
using Arene;

namespace Arene.Tests;

// 1. On crée un "Mock" (un faux objet) très simple pour nos tests
public class FakeDice : IDice
{
    private readonly int forcedValue;

    public FakeDice(int forcedValue)
    {
        this.forcedValue = forcedValue;
    }

    public int Roll() => forcedValue;
}

// 2. Notre classe de tests
public class GladiatorTests
{
    [Theory]
    [InlineData(0)]
    [InlineData(7)]
[Fact]
    public void Attack_Standard_OpponentLosesHealth()
    {
        // Arrange
        // Attaquant : force 10. Adversaire : 100 PV, armure 5.
        var attacker = new Gladiator("Spartacus", 100, 10, 5);
        var opponent = new Gladiator("Crixus", 100, 10, 5);
        
        // Dé de 3. 
        // Calcul attendu : Dégâts = Dé(3) + Force(10) - Armure(5) = 8.
        // PV restants attendus : 100 - 8 = 92.
        var fakeDice = new FakeDice(3); 

        // Act
        attacker.Attack(opponent, fakeDice);

        // Assert
        Assert.Equal(92, opponent.Health);
    }
}

