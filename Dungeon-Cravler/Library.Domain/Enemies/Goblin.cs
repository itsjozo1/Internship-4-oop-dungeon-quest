namespace Library.Domain.Enemies;

public class Goblin : Enemy
{
    public override double Health { get; set; } = 40;
    public override double Damage { get; set; }= 10;
    public override int ExperiencePoints { get; set; }= 10;
    public static int Chance = 50;
    
    
    public override void DisplayEnemy(double currentHealth)
    {
        Console.WriteLine("     O  p\n    (X)-|\n    / \\");
        DisplayBar(currentHealth, Health, "Health: ");
        Console.WriteLine($"Damage: {Damage}");

    }
}