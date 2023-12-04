namespace Library.Domain;

public class CharacterFunctions
{
    public List<string> attackCommands= new List<string>(){"direct", "side", "counter"};


    protected void DisplayBar(double currenValue, double initialValue, string barName)
    {
        string bar = "";
        for (var i = 1; i < 11; i++)
        {
            if (i <= currenValue*10/initialValue)
            {
                bar += "#";
            }
            if (i > currenValue*10/initialValue)
            {
                bar += "-";
            }
            if (i == 5)
            {
                bar += $" {currenValue} ";
            }
        }
        Console.WriteLine($"{barName}: {bar}");
    }
}
