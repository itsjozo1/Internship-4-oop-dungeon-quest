using Library.Domain.Heroes;

namespace Library.Domain.Enemies;

public class Witch : Enemy
{
    public override double Health { get; set; } = 70;
    public override int Damage { get; set; }= 20;
    public override int ExperiencePoints { get; set; }= 50;
    public static int Chance = 20;
    private int dumbusChance = 10;

    
    public override void DisplayEnemy(double currentHealth)
    {
        Console.WriteLine("          0\n     _O_  |\n    _/#\\_/|\n     |#|  |\n     /##\\");
        DisplayHealthBar(currentHealth, Health);
        Console.WriteLine($"Damage: {Damage}");
        
    }

    public override void CheckAbilities(double currentHealth, List<Enemy> enemiesList)
    {
        if (currentHealth <= 0)
        {
            Console.WriteLine("Witch have spawned 2 enemies");
            Console.ReadLine();
            enemiesList.Add(new Goblin());  
            enemiesList.Add(new Goblin());  
        }
    }
    public override string EnemyAttack(Hero dumbusHero, List<Enemy> enemiesList)
    {
        Random random = new Random();
        if (random.Next(1, 100) < dumbusChance)
        {
            Console.Clear();
            Console.WriteLine("Đumbus has been activated, every health levels are changed!");
            Console.ReadLine();
            dumbusHero.Health = random.Next(1, (int)dumbusHero.Health);
            foreach (var enemy in enemiesList)
            {
                if (enemy.Health > 0)
                {
                    enemy.Health = random.Next(1, (int)enemy.Health);
                }
            }
        }
        return attackCommands[random.Next(1,4)-1];
    }
}