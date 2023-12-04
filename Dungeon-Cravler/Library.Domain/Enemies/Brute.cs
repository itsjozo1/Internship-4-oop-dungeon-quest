using Library.Domain.Heroes;

namespace Library.Domain.Enemies;

public class Brute : Enemy
{
    public override double Health { get; set; } = 80;
    public override double Damage { get; set; } = 15;
    public override int ExperiencePoints { get; set; }= 30;
    public static int Chance = 20;
    private int attackPercentChance = 25;
    private int initialDamage = 20;
    
    public override void DisplayEnemy(double currentHealth)
    {
        Damage = initialDamage;
        Console.WriteLine("   ___(-)___\n    ( X X )( )   +++\n     \\(X)/  \\ \\_||   +\n     /##\\");
        DisplayBar(currentHealth, Health, "Health");
        Console.WriteLine($"Damage: {Damage}");

    }
    public override string EnemyAttack(Hero dumbusHero, List<Enemy> enemiesList)
    {
        Random random = new Random();
        if (random.Next(1,101) < attackPercentChance)
        {
            Damage = dumbusHero.Health * .25;
        }
        return attackCommands[random.Next(1,4)-1];
    }
}