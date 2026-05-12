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
    public void Attack_Self_ThrowsArgumentException()
    {
        // Arrange
        var attacker = new Gladiator("Spartacus", 100, 10, 5);
        var fakeDice = new FakeDice(3); // Un dé valide cette fois

        // Act & Assert
        Assert.Throws<ArgumentException>(() => attacker.Attack(attacker, fakeDice));
    }
}

