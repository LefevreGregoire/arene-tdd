using System;
using Xunit;
using Arene;

namespace Arene.Tests;

public class FakeDice : IDice
{
    private readonly int forcedValue;

    public FakeDice(int forcedValue)
    {
        this.forcedValue = forcedValue;
    }

    public int Roll() => forcedValue;
}

public class GladiatorTests
{
    [Theory]
    [InlineData(0)]
    [InlineData(7)]
[Fact]
    public void Attack_Standard_OpponentLosesHealth()
    {
        var attacker = new Gladiator("Spartacus", 100, 10, 5);
        var opponent = new Gladiator("Crixus", 100, 10, 5);
        
        var fakeDice = new FakeDice(3); 

        attacker.Attack(opponent, fakeDice);

        Assert.Equal(92, opponent.Health);
    }
[Fact]
    public void Attack_Consecutive_ReducesHealthTwice()
    {
        var attacker = new Gladiator("Spartacus", 100, 10, 5);
        var opponent = new Gladiator("Crixus", 100, 10, 5);
        var fakeDice = new FakeDice(3); 
        
        attacker.Attack(opponent, fakeDice);
        attacker.Attack(opponent, fakeDice);

        Assert.Equal(84, opponent.Health);
    }

    [Fact]
    public void Attack_StrongArmor_NoDamage()
    {
        var attacker = new Gladiator("Spartacus", 100, 10, 5);
        var opponent = new Gladiator("Tank", 100, 10, 50); 
        var fakeDice = new FakeDice(3); 

        attacker.Attack(opponent, fakeDice);

        Assert.Equal(100, opponent.Health);
    }

    [Fact]
    public void Attack_Lethal_HealthDoesNotGoBelowZero()
    {
        var attacker = new Gladiator("Dieu", 100, 200, 5); 
        var opponent = new Gladiator("Crixus", 100, 10, 5);
        var fakeDice = new FakeDice(3); 

        attacker.Attack(opponent, fakeDice);

        Assert.Equal(0, opponent.Health); 
    }
}

