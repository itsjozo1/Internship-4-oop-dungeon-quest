using Library.Domain.Heroes;

namespace Library.Domain.Enemies;

public class Witch : Enemy
{
    public override double Health { get; set; } = 70;
    public override int Damage { get; set; }= 20;
    public override int ExperiencePoints { get; set; }= 50;
    public static int Chance = 10;

    
    public override void DisplayEnemy(double currentHealth)
    {
        Console.WriteLine("          0\n     _O_  |\n    _/#\\_/|\n     |#|  |\n     /##\\");
        DisplayHealthBar(currentHealth, Health);
        Console.WriteLine($"Damage: {Damage}");
        
    }

    public void SpawnEnemiesAfterDeath()
    {
        
    }
    public void Dumbus(Hero dumbusHero, List<Enemy> enemiesList)
    {
        Random random = new Random();
        dumbusHero.Health = random.Next(1, 101);
        foreach (var enemy in enemiesList)
        {
            if (enemy.Health > 0)
            {
                enemy.Health = random.Next(1, 101);
            }
        }
    }
}