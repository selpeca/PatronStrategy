public interface IAttack
{
    void Attack(Pokemon pokemon);
}

public class QuickAttack : IAttack
{
    public void Attack(Pokemon pokemon)
    {
        Console.WriteLine($"{pokemon.Name} usó Ataque Rápido!");
        // Lógica para calcular el daño, aplicar efectos, etc.
    }
}

public class FireBlast : IAttack
{
    public void Attack(Pokemon pokemon)
    {
        Console.WriteLine($"{pokemon.Name} usó Lanzallamas!");
        // Lógica para calcular el daño, aplicar efectos de quemadura, etc.
    }
}

public class WaterGun : IAttack
{
    public void Attack(Pokemon pokemon)
    {
        Console.WriteLine($"{pokemon.Name} usó Pistola de Agua!");
        // Lógica para calcular el daño, aplicar efectos de estado, etc.
    }
}

public class Pokemon
{
    public string Name { get; set; }
    public int Level { get; set; }
    public IAttack Attack { get; set; }

    public void UseAttack()
    {
        Attack.Attack(this);
    }
}
class Program
{
    static void Main(string[] args)
    {

        // Ejemplo de uso
        Pokemon pikachu = new Pokemon() { Name = "Pikachu", Level = 25, Attack = new QuickAttack() };
        pikachu.UseAttack(); // Salida: Pikachu usó Ataque Rápido!

        // Cambiamos el ataque
        pikachu.Attack = new FireBlast();
        pikachu.UseAttack(); // Salida: Pikachu usó Lanzallamas!

        //Ahora elijamos a Charmander
        Pokemon charmander = new Pokemon() { Name = "Charmander", Level = 10, Attack = new FireBlast() };
        charmander.UseAttack();

    }
}