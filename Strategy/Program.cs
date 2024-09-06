public interface IAttack
{
    int CalculateDamage(Pokemon attacker, Pokemon defender);
    void ApplyEffects(Pokemon defender);
}

public class QuickAttack : IAttack
{
    public int CalculateDamage(Pokemon attacker, Pokemon defender)
    {
        // Cálculo básico del daño basado en el nivel y el ataque del Pokémon
        return attacker.Level * 5;
    }

    public void ApplyEffects(Pokemon defender)
    {
        Console.WriteLine($"{defender.Name} recibió un golpe rápido.");
    }
}

public class FireBlast : IAttack
{
    public int CalculateDamage(Pokemon attacker, Pokemon defender)
    {
        // Cálculo del daño considerando tipo, efectividad y otros factores
        int damage = attacker.Level * 10;
        if (defender.Type == PokemonType.Grass)
        {
            damage *= 2; // Daño doble contra tipo hierba
        }
        return damage;
    }

    public void ApplyEffects(Pokemon defender)
    {
        Console.WriteLine($"{defender.Name} fue quemado!");
        defender.Burned = true;
    }
}

// ... otros ataques ...

public enum PokemonType
{
    Water,
    Fire,
    Grass,
    Electric,
    // ... otros tipos
}

public class Pokemon
{
    public string Name { get; set; }
    public int Level { get; set; }
    public PokemonType Type { get; set; }
    public bool Burned { get; set; }
    public IAttack Attack { get; set; }
    public int HP { get; set; }    

    public void UseAttack(Pokemon opponent)
    {
        int damage = Attack.CalculateDamage(this, opponent);
        opponent.HP -= damage;
        Attack.ApplyEffects(opponent);
        Console.WriteLine($"{Name} infligió {damage} puntos de daño a {opponent.Name}!");
    }
}
class Program
{
    static void Main(string[] args)
    {

        Pokemon charmander = new Pokemon { Name = "Charmander", Level = 10, Type = PokemonType.Fire, Attack = new FireBlast() };
        Pokemon bulbasaur = new Pokemon { Name = "Bulbasaur", Level = 10, Type = PokemonType.Grass, HP = 50 };

        charmander.UseAttack(bulbasaur);

    }
}