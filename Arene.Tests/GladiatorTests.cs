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
[Fact]
    public void Attack_Consecutive_ReducesHealthTwice()
    {
        // 1. Deux attaques consécutives
        var attacker = new Gladiator("Spartacus", 100, 10, 5);
        var opponent = new Gladiator("Crixus", 100, 10, 5);
        var fakeDice = new FakeDice(3); // Dégâts = 8 par attaque

        attacker.Attack(opponent, fakeDice);
        attacker.Attack(opponent, fakeDice);

        // 100 - 8 - 8 = 84
        Assert.Equal(84, opponent.Health);
    }

    [Fact]
    public void Attack_StrongArmor_NoDamage()
    {
        // 2. Armure très forte
        var attacker = new Gladiator("Spartacus", 100, 10, 5);
        var opponent = new Gladiator("Tank", 100, 10, 50); // Armure 50 !
        var fakeDice = new FakeDice(3); // Base 13, Armure 50.

        attacker.Attack(opponent, fakeDice);

        // L'armure encaisse tout, les PV restent à 100 (pas de dégâts négatifs)
        Assert.Equal(100, opponent.Health);
    }

    [Fact]
    public void Attack_Lethal_HealthDoesNotGoBelowZero()
    {
        // 3. La mort (les PV ne doivent pas être négatifs)
        var attacker = new Gladiator("Dieu", 100, 200, 5); // Force 200 !
        var opponent = new Gladiator("Crixus", 100, 10, 5);
        var fakeDice = new FakeDice(3); 

        attacker.Attack(opponent, fakeDice);

        // 100 PV - 198 Dégâts = 0 PV (et non -98)
        Assert.Equal(0, opponent.Health); 
    }
}

