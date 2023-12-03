namespace Library.Domain.Enemies;

public class Brute : Enemy
{
    public override double Health { get; set; } = 80;
    public override int Damage { get; set; } = 15;
    public override int ExperiencePoints { get; set; }= 20;
    public static int Chance = 20;
    public double DamagePercent;
    
    public override void DisplayEnemy(double currentHealth)
    {
        Console.WriteLine("   ___(-)___\n    ( X X )( )   +++\n     \\(X)/  \\ \\_||   +\n     /##\\");
        DisplayHealthBar(currentHealth, Health);
        Console.WriteLine($"Damage: {Damage}");

    }
}