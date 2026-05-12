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
    public void Attack_WithRiggedDice_ThrowsArgumentOutOfRangeException(int riggedRoll)
    {
        // Arrange
        var attacker = new Gladiator("Spartacus", 100, 10, 5);
        var opponent = new Gladiator("Crixus", 100, 10, 5);
        var fakeDice = new FakeDice(riggedRoll);

        // Act & Assert
        Assert.Throws<ArgumentOutOfRangeException>(() => attacker.Attack(opponent, fakeDice));
    }
}

