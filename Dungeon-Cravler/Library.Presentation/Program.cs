using Library.Domain.Enemies;
using Library.Domain.Heroes;

List<Enemy> enemiesList = new List<Enemy>();

Dictionary<string, Action> heroesCreationList = new Dictionary<string, Action>()
{
    {"gladiator", () => StartGame(new Gladiator(CheckName()))},
    {"enchanter", () => StartGame(new Enchanter(CheckName()))},
    {"marksman", () => StartGame(new Marksman(CheckName()))},
};


while (true)
{
   enemiesList.Clear();
    CreateNewEnemiesList(enemiesList);
    Console.Clear();
    PrintTitle();
    Continue();
    Console.WriteLine("Welcome to Dungeon-Crawler\nChoose your hero:");
    PrintSelection();
    var selectedHero = SelectHero(Console.ReadLine().ToLower().Trim());
    foreach (var item in heroesCreationList)
    {
        if (item.Key == selectedHero)
        {
            item.Value.Invoke();
        } 
    }

    Console.WriteLine("Do you want to play again? (Y/N)");
    if (!Confirm())
    {
        return;
    }
}

string SelectHero(string selectHero)
{

    while (!heroesCreationList.Keys.Contains(selectHero))
    {
        Console.Clear();
        Console.WriteLine("Choose existing heroes!");
        PrintSelection();
        selectHero = Console.ReadLine().ToLower().Trim();
    }
    return selectHero;
}

void PrintSelection()
{
    Console.WriteLine("\t\t\t  ___ k\t\t        \n" +
                      "    _O_  D \t\t   O  |\t\t\t  _O_    (\n" +
                      "   / V \\_|\t\t ()Y==o\t\t\t /(#) = /\n" +
                      "    /_\\ \t\t  /_\\ |\t\t\t  /_\\\n" +
                      "    |#|\t\t\t  _W_ |\t\t\t  | |\n");
    Console.WriteLine("  GLADIATOR\t\tENCHANTER\t\tMARKSMAN\n  100hp\t\t\t50hp\t\t\t75hp\n  20dmg\t\t\t30dmg\t\t\t25dmg\n");
}  

void PrintTitle()
{
    Console.WriteLine("\n\n\n________                                           _________                      .__            " +
                      "    \n\\______ \\  __ __  ____    ____   ____  ____   ____ \\_   ___ \\____________ __  _  _|  | " +
                      "  ___________ \n |    |  \\|  |  \\/    \\  / ___\\_/ __ \\/  _ \\ /    \\/    \\  \\/\\_  __ \\_" +
                      "_  \\\\ \\/ \\/ /  | _/ __ \\_  __ \\\n |    `   \\  |  /   |  \\/ /_/  >  ___(  <_> )   |  \\   " +
                      "  \\____|  | \\// __ \\\\     /|  |_\\  ___/|  | \\/\n/_______  /____/|___|  /\\___  / \\___  >__" +
                      "__/|___|  /\\______  /|__|  (____  /\\/\\_/ |____/\\___  >__|   \n        \\/           \\//_____" +
                      "/      \\/           \\/        \\/            \\/                 \\/       \n                  " +
                      "                                                                                 ");
}

string CheckName()
{
    Console.WriteLine("Enter hero name: ");
    string enterName = Console.ReadLine();
    while (enterName.Equals(""))                                   
    {       
        Console.Clear();                                                   
        Console.WriteLine("To continue you must enter hero name: ");
        enterName = Console.ReadLine();
    }

    return enterName;
}

int GenerateRandomEnemy()
{
    Random random = new Random();
    int randomNumber = random.Next(1, 101);

    if (randomNumber <= Goblin.Chance)
    {
        return 1; 
    }
    if (randomNumber <= Goblin.Chance + Brute.Chance)
    {
        return 2; 
    }
    if (randomNumber <= Goblin.Chance + Brute.Chance + Witch.Chance)
    {
        return 3;
    }
    return 0;
}

void StartGame(Hero newHero)
{
    Console.Clear();
    Console.WriteLine(newHero.Description());
    Continue();
    int i = 0;
    var heroCurrentHealth = newHero.Health;
    do
    {
        Console.Clear();
        Console.WriteLine($"Enemy {i+1}");
        heroCurrentHealth = FightIndividualEnemy(newHero, enemiesList[i], heroCurrentHealth);
        if (heroCurrentHealth <= 0)
        {
            return;
        }

        if (heroCurrentHealth < 0.75*newHero.Health)
        {
            heroCurrentHealth += Math.Floor(newHero.Health * .25);
        }
        
        Console.WriteLine($"You have killed enemy {i+1}, you got {enemiesList[i].ExperiencePoints}exp");
        newHero.AddExp(enemiesList[i].ExperiencePoints);
        Continue();
        
        i++;
    } while (i < 10);

    if (heroCurrentHealth <= 0)
    {
        Console.WriteLine("You lost!\n");
        return;
    }
    Console.WriteLine("Congratulations you have successfully slaughtered whole dungeon!!\n");
}
void CreateNewEnemiesList(List<Enemy> enemiesList)
{
    for (int i = 0; i < 10; i++)
    {
        var rand = GenerateRandomEnemy();
        switch (rand)
        {
            case 1:
                enemiesList.Add(new Goblin());
                break;
            case 2:
                enemiesList.Add(new Brute());
                break;
            case 3:
                enemiesList.Add(new Witch());
                break;
        }
    }
}

void Continue()
{
    Console.WriteLine("Press any key to continue: ");      
    Console.ReadLine();                                  
    Console.Clear();                                      
}

double FightIndividualEnemy(Hero hero, Enemy enemy, double heroCurrentHealth)
{
    var enemyCurrentHealth = enemy.Health;
    enemy.DisplayEnemy(enemyCurrentHealth);
    Console.WriteLine("\n\n\n");
    hero.DisplayHero(heroCurrentHealth);
    do
    {
        var enemyCommand = "";
        int roundResult = DetermineRoundWinner(hero.HeroAttack(ref heroCurrentHealth), enemyCommand = enemy.EnemyAttack(hero, enemiesList));
        switch (roundResult)
        {
            case 1:
                Console.Clear();
                Console.WriteLine($"Enemy choice {enemyCommand}");
                enemy.DisplayEnemy(enemyCurrentHealth);
                Console.WriteLine("\nIts a tie\n");
                hero.DisplayHero(heroCurrentHealth);
                break;
            case 0:
                Console.Clear();
                heroCurrentHealth = DealDamage(heroCurrentHealth, enemy.Damage);
                Console.WriteLine($"Enemy choice {enemyCommand}");
                enemy.DisplayEnemy(enemyCurrentHealth);
                Console.WriteLine($"\nEnemy wins, Hero loses {enemy.Damage} life\n");
                hero.DisplayHero(heroCurrentHealth);
                break;
            case 2:
                Console.Clear();
                enemyCurrentHealth = DealDamage(enemyCurrentHealth, hero.Damage);
                Console.WriteLine($"Enemy choice {enemyCommand}");
                enemy.DisplayEnemy(enemyCurrentHealth);
                Console.WriteLine($"\nHero wins, enemy loses {hero.Damage} life\n");
                hero.DisplayHero(heroCurrentHealth);
                break;
        }
        heroCurrentHealth= hero.CheckAbility(heroCurrentHealth);
        enemy.CheckAbilities(enemyCurrentHealth, enemiesList);
    } while (heroCurrentHealth > 0  && enemyCurrentHealth > 0);
    return heroCurrentHealth;
}

int DetermineRoundWinner(string heroCommand, string enemyCommand)
{
    if (heroCommand == enemyCommand)
    {
        return 1;
    }
    if ((heroCommand == "direct" && enemyCommand == "side") ||
             (heroCommand == "side" && enemyCommand == "counter") ||
             (heroCommand == "counter" && enemyCommand == "direct") || heroCommand == "stun") 
    {
        return 2;
    }
    return 0;
}

bool Confirm()
{
    var enterConfirm = Console.ReadLine().ToLower().Trim();
    while (!enterConfirm.ToLower().Equals("y") && !enterConfirm.ToLower().Equals("n"))
    {
        Console.WriteLine("Enter y/n");
        enterConfirm = Console.ReadLine().ToLower().Trim();
    }

    if (enterConfirm.Equals("y")) return true;

    return false;
}

double DealDamage(double currentHealth, double damage)
{
    if (damage > currentHealth)
    {
        currentHealth = 0;
        return currentHealth;
    }
    currentHealth -= damage;
    return currentHealth;
}