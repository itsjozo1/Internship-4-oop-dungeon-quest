namespace Library.Domain.Heroes;

public class Enchanter : Hero
{
    public string Name {get;}
    public override double Health { get; set; } = 50;
    public override int Damage { get; set; } = 30;
    private int mana = 50;
    public int currentMana = 50;
    private int relive = 1;

    public Enchanter(string name)
    {
        Name = name;
    }

    public override double CheckAbility(double currentHealth)
    {
        if (currentHealth <= 0)
        {
            if (relive == 1)
            {
                Console.WriteLine("HERO HAS RELIVED");
                currentHealth = Health;
                currentMana = mana;
                relive = 0;
                return currentHealth;
            }

            Console.WriteLine("YOU HAVE DIED: ");
            return currentHealth;
        }

        return currentHealth;
    }

    public override string Description()
    {
        string desc =  $"\nHello {Name} before you start adventure in dark dungeon let me introduce you with Enchanter.\n" +
                       $"  ___ k\n   O  |\n ()Y==o\n  /_\\ |\n  _W_ |" +
                       $"\nEnchanter have {Health} health points and {Damage} damage rate.Enchanter also have 50 mana.\n" +
                       $"Mana is magical strength that enchanter uses to attack. If mana is 0 you cant attack\n" +
                       $"that round,you will need to wait until it recharges next roundEnchanter have ability to \n" +
                       $"relive once in game, after he dies automatically relives back. " +
                       $"\n\nFight with each of ten enemies with attack commands 'direct', 'side' and 'counter'. Fight rules\n" +
                       $"are simple:\nDirect beats side attack\nSide beats counter attack\nCounter " +
                       $"beats direct attack\nIn case of draw nothing happens.\n";
        return desc;
    }
    public override void DisplayHero(double currentHealth)
    {
        Console.WriteLine("     ___ k\n      O  |\n    ()Y==o\n     /_\\ |\n     _W_ |");
        DisplayHealthBar(currentHealth, Health);
        Console.WriteLine($"Damage: {Damage}");
        DisplayManaBar(currentMana, mana);
        base.DisplayHero(currentHealth);
    }

    public override string HeroAttack(ref double currentHealth)
    {
        if (currentMana <= 0)
        {
            Console.WriteLine("Mana is 0, Enchanter can't attack this round.");
            Console.ReadLine();
            currentMana += 20;
            return "";
        }
        
        var enteredAttackCommand = Console.ReadLine();

        if (enteredAttackCommand.ToLower() == "regenerate")
        {
            if (currentMana >= 10 && currentHealth<=0.8*Health)
            {
                currentHealth *= 1.2;
                currentMana -= 10;
                Console.WriteLine("Enchanter has regained 20% health points.");
            }
            else
            {
                Console.WriteLine("Regenerate ability is not available.");
            }
        }
        while (!attackCommands.Contains(enteredAttackCommand.ToLower()))
        {
            Console.WriteLine("Enter one of the commands: "); 
            enteredAttackCommand = Console.ReadLine();
        }

        currentMana -= 10;
        return enteredAttackCommand;
    }
    public override void AddExp(int enemyExp)
    {
        ExpiriencePoints += enemyExp;
        if (ExpiriencePoints >= 100)
        {
            ExpiriencePoints -= 100;
            Damage += 5;
            Health += 10;
            mana += 10;
        }
    }
}