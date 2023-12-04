namespace Library.Domain;

public class CharacterFunctions
{
    public List<string> attackCommands= new List<string>(){"direct", "side", "counter"};
    public virtual void DisplayHealthBar(double currentHealth, double initialHealth)
    {
        var healthPercentage = (currentHealth * 100.0) / initialHealth;

        string healthBar = "";
        for (var i = 1; i < 11; i++)
        {
            if (i <= healthPercentage/10)
            {
                healthBar += "#";
            }
            if (i > healthPercentage/10)
            {
                healthBar += "-";
            }
            if (i == 5)
            {
                healthBar += $" {currentHealth} ";
            }
        }
        
        Console.WriteLine($"HEALTH:\n{healthBar}");
    }

    protected void DisplayExperiencePoints(int currentExp)
    {
        string expBar = "";
        for (var i = 1; i < 11; i++)
        {
            if (i <= currentExp/10)
            {
                expBar += "#";
            }
            if (i > currentExp/10)
            {
                expBar += "-";
            }
            if (i == 5)
            {
                expBar += $" {currentExp} ";
            }
        }

        Console.WriteLine($"EXP: {expBar}");
    }

    public void DisplayManaBar(int currentMana, int mana)
    {
        string manaBar = "";
        for (var i = 1; i < 11; i++)
        {
            if (i <= currentMana*10/mana)
            {
                manaBar += "#";
            }
            if (i > currentMana*10/mana)
            {
                manaBar += "-";
            }
            if (i == 5)
            {
                manaBar += $" {currentMana} ";
            }
        }

        Console.WriteLine($"Mana: {manaBar}");
    }
}