namespace Library.Domain.Heroes;

public class Enchanter : Hero
{
    public string Name {get;}
    public override double Health { get; set; } = 50;
    public override int Damage { get; set; } = 30;
    public int mana = 50;
    public int relive = 1;

    public Enchanter(string name)
    {
        this.Name = name;
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
        base.DisplayHero(currentHealth);
    }
}