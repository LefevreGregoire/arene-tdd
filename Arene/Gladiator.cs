using System;

namespace Arene;

public class Gladiator
{
    public string Name { get; }
    public int Health { get; private set; }
    public int Strength { get; }
    public int Armor { get; }

    public Gladiator(string name, int health, int strength, int armor)
    {
        Name = name;
        Health = health;
        Strength = strength;
        Armor = armor;
    }
    public void Attack(Gladiator opponent, IDice dice)
    {
        if (this == opponent)
        {
            throw new ArgumentException("Un gladiateur ne peut pas s'attaquer lui-même.", nameof(opponent));
        }
        var score = dice.Roll();
        if (score < 1 || score > 6)
        {
            throw new ArgumentOutOfRangeException(nameof(dice), "La valeur du dé doit être comprise entre 1 et 6.");
        }
        var baseDamage = score + this.Strength;
        if (score == 6)
        {
            baseDamage *= 2;
        }
        var finalDamage = Math.Max(baseDamage - opponent.Armor, 0);
        opponent.TakeDamage(finalDamage);
    }
    internal void TakeDamage(int damage)
    {
        if (damage > 0)
            Health = Math.Max(Health - damage, 0);
    }
}
