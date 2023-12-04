using Library.Domain.Heroes;

namespace Library.Domain.Enemies;

public class Enemy : CharacterFunctions
{
    public virtual double Health { get; set; }
    public virtual double Damage{ get; set; }
    public virtual int ExperiencePoints { get; set; }

    public virtual void DisplayEnemy(double currentHealth){}

    public virtual string EnemyAttack(Hero dumbusHero, List<Enemy> enemiesList)
    {
        Random random = new Random();
        return attackCommands[random.Next(1,4)-1];
    }

    public virtual void CheckAbilities(double currentHealth, List<Enemy> enemiesList)
    {
        
    }
}