namespace Library.Domain.Enemies;

public class Enemy : CharacterFunctions
{
    public virtual double Health { get; set; } = 99;
    public virtual int Damage{ get; set; } = 99;
    public virtual int ExperiencePoints { get; set; } = 99;
    public static int Chance;

    public virtual void DisplayEnemy(double currentHealth)
    {
        DisplayHealthBar(currentHealth, Health);
    }

    public string EnemyAttack()
    {
        Random random = new Random();
        return attackCommands[random.Next(1,4)-1];
    }
}