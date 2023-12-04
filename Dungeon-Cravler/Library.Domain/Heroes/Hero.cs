namespace Library.Domain.Heroes;

public class Hero : CharacterFunctions
{
    public string Name { get; set; }
    public virtual double Health { get; set; } = 99;
    public virtual int Damage { get; set; } = 99;
    public int ExpiriencePoints { get; set; }



    public virtual string Description()
    {
        return "";
    }

    public virtual double CheckAbility(double currentHealth)
    {
        return currentHealth;
    }
    public virtual void DisplayHero(double currentHealth)
    {
        DisplayBar(ExpiriencePoints, 100, "EXP");
    }

    public virtual string HeroAttack(ref double currentHealth)
    {
        
        Console.WriteLine("Enter command to attack: ");
        var enteredAttackCommand = Console.ReadLine();
        while (!attackCommands.Contains(enteredAttackCommand.ToLower()))
        {
            Console.WriteLine("Enter one of the commands: "); 
            enteredAttackCommand = Console.ReadLine();
        }

        return enteredAttackCommand;
    }

    public virtual void AddExp(int enemyExp)
    {
        ExpiriencePoints += enemyExp;
        if (ExpiriencePoints >= 100)
        {
            ExpiriencePoints -= 100;
            Damage += 5;
            Health += 10; 
        }
    }
}