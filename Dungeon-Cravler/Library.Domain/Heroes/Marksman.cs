namespace Library.Domain.Heroes;

public class Marksman : Hero
{
    public string Name {get;}
    public override double Health { get; set; } = 75;
    public override int Damage { get; set; } = 20;
    public int criticalChance = 15;
    public int stunChance = 15;
    private int _initialDamage = 20;


    public Marksman(string name)
    {
        Name = name;
    }
    public override string Description()
    {
        string desc =  $"\nHello {Name} before you start adventure in dark dungeon let me introduce you with Marksman.\n" +
                       $"  _O_    (\n /(#) = /\n  /_\\\n  | |" +
                       $"\nMarksman have {Health} health points and {Damage} damage rate. Marksman have 2 special abilities: \n" +
                       $"1.Critical chance - every attack there is a chance to make double damage\n" +
                       $"2.Stun damage - every attack there is a chance to stun an enemy which it automatically loses round" +
                       $"\n\nFight with each of" +
                       $"ten enemies with attack commands 'direct', 'side' and 'counter'. Fight rules\n" +
                       $"are simple:\nDirect beats side attack\nSide beats counter attack\nCounter " +
                       $"beats direct attack\nIn case of draw nothing happens.\n";
        return desc;
    }   
    public override string HeroAttack(ref double currentHealth)
    {
        Random random = new Random();
        if (random.Next(1, 101) < criticalChance)
        {
            Damage *= 2;
            Console.WriteLine($"Critical chance enabled damage is {Damage}");
        }

        if (random.Next(1, 101) > (100-stunChance) )
        {
            Console.WriteLine("Enemy is stunned tou won this round\nTo continue press any key");
            Console.ReadLine();
            return "stun";
        }
        Console.WriteLine("Enter command to attack: ");
        var enteredAttackCommand = Console.ReadLine();
        while (!attackCommands.Contains(enteredAttackCommand.ToLower()))
        {
            Console.WriteLine("Enter one of the commands: "); 
            enteredAttackCommand = Console.ReadLine();
        }

        return enteredAttackCommand;
    }
    public override void DisplayHero(double currentHealth)
    {
        Damage = _initialDamage;
        Console.WriteLine("     _O_    (\n    /(#) = /\n     /_\\\n     | |");
        DisplayBar(currentHealth, Health, "Health");
        Console.WriteLine($"Damage: {Damage}");
        base.DisplayHero(currentHealth);
    }
    public override void AddExp(int enemyExp)
    {
        ExpiriencePoints += enemyExp;
        if (ExpiriencePoints >= 100)
        {
            ExpiriencePoints -= 100;
            Damage += 5;
            Health += 10;
            stunChance += 5;
            criticalChance += 5;
        }
    }
}