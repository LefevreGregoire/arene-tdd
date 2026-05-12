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
        var score = dice.Roll();
        
        // On vérifie que le dé n'est pas truqué
        if (score < 1 || score > 6)
        {
            throw new ArgumentOutOfRangeException(nameof(dice), "La valeur du dé doit être comprise entre 1 et 6.");
        }

        throw new NotImplementedException("To be done");
    }
}

