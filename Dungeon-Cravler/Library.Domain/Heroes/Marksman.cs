namespace Library.Domain.Heroes;

public class Marksman : Hero
{
    public string Name {get;}
    public override double Health { get; set; } = 75;
    public override int Damage { get; set; } = 25;
    public double criticalChance = 0.3;
    public double stunChance = 0.3;

    public Marksman(string name)
    {
        this.Name = name;
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
    public override void DisplayHero(double currentHealth)
    {
        Console.WriteLine("     _O_    (\n    /(#) = /\n     /_\\\n     | |");
        DisplayHealthBar(currentHealth, Health);
        Console.WriteLine($"Damage: {Damage}");
        base.DisplayHero(currentHealth);
    }
}