using System;

namespace Arene;

public class Gladiator
{
    public string Name { get; }
    public int Health { get; private set; }
    public int Strength { get; private set; }
    public int Armor { get; private set; }

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

        // Base des dégâts
        var baseDamage = score + this.Strength;

        // Si le dé fait 6, coup critique : la base est multipliée par 2
        if (score == 6)
        {
            baseDamage *= 2;
        }

        // On soustrait l'armure de l'adversaire
        var finalDamage = baseDamage - opponent.Armor;

        opponent.TakeDamage(finalDamage);
    }

// Méthode interne pour réduire les points de vie
    internal void TakeDamage(int damage)
    {
        if (damage > 0)
        {
            Health -= damage;
        }
    }
}
