namespace Library.Domain.Heroes;

public class Gladiator : Hero
{
    public string Name {get;}
    public override double Health { get; set; } = 100;
    public override int Damage { get; set; } = 20;
    private bool rage = false;
    
    public Gladiator(string name)
    {
        Name = name;
    }

    public string Rage()
    {
        string attackCommand;
        if (rage == false)
        {
            rage = true;
            Health *= 0.85;
            Damage *= 2;
            Console.WriteLine("**RAGE MODE ACTIVATED**");
            attackCommand = HeroAttack();
            Damage /= 2;
            rage = false;
            return attackCommand;
        }

        return HeroAttack();
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
        Console.WriteLine("    _O_  D\n   / V \\_|\n    /_\\ \n    |#|");
        DisplayHealthBar(currentHealth, Health);
        Console.WriteLine($"Damage: {Damage}");
        base.DisplayHero(currentHealth);
    }
    
}