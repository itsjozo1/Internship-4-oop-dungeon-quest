namespace Library.Domain.Heroes;

public class Gladiator : Hero
{
    private string Name {get;}
    public override double Health { get; set; } = 100;
    public override int Damage { get; set; } = 20;
    private bool _rage = false;
    private int _initialDamage = 20;
    public Gladiator(string name)
    {
        Name = name;
    }

    private string Rage(ref double currentHealth)
    {
        if (_rage == false)
        {
            Damage *= 2;
            Console.WriteLine($"**RAGE MODE ACTIVATED**\nDamage - {Damage}");
            currentHealth *= 0.85;
            DisplayHealthBar(currentHealth, Health);
            return HeroAttack(ref currentHealth);

        }

        Console.WriteLine("**RAGE MODE ALREADY ACTIVATED**");
        return HeroAttack(ref currentHealth);
    }
    public override string HeroAttack(ref double currentHealth)
    {
        Console.WriteLine("Enter command to attack: ");
        var enteredAttackCommand = Console.ReadLine();
        while (!attackCommands.Contains(enteredAttackCommand.ToLower()) && !enteredAttackCommand.Equals("rage"))
        {
            Console.WriteLine("Enter one of the commands: "); 
            enteredAttackCommand = Console.ReadLine();
        }

        if (enteredAttackCommand.Equals("rage"))
        {
            return Rage(ref currentHealth);
        }
        return enteredAttackCommand;
    }
    public override string Description()
    {
        string desc =  $"\nHello {Name} before you start adventure in dark dungeon let me introduce you with gladiator.\n" +
                       $"  _O_  D\n / V \\_|\n  /_\\ \n  |#|" +
                       $"\nGladiator have {Health} health points and {Damage} damage rate. Gladiator have special\n" +
                       $"ability 'rage' which attacks with double damage but you lose 15% of health.\n" +
                       $"To activate rage ability type 'rage' before attack phase.\n\nFight with each of" +
                       $"ten enemies with attack commands 'direct', 'side' and 'counter'. Fight rules\n" +
                       $"are simple:\nDirect beats side attack\nSide beats counter attack\nCounter " +
                       $"beats direct attack\nIn case of draw nothing happens.\n";
        return desc;
    }
    
    public override void DisplayHero(double currentHealth)
    {
        Damage = _initialDamage;
        Console.WriteLine("    _O_  D\n   / V \\_|\n    /_\\ \n    |#|");
        DisplayHealthBar(currentHealth, Health);
        Console.WriteLine($"Damage: {Damage}");
        base.DisplayHero(currentHealth);
    }
    
}