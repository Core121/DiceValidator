using DiceValidator;

Console.WriteLine("Hello and welcome to the dice validator!\n\n");

Dice dice = new();
dice.Sides= GetDieSides();
int numberOfRolls = RollCountEntry();

Console.WriteLine("\n\nPlease roll your die and enter the value shown on the dice.\nRepeat until all rolls have been completed or click enter to stop.");
for (int i = 1; i <= numberOfRolls; i++)
{
    int roll = RollEntry();
    if(roll == -1)
    {
        break;
    }
    dice.Rolls.Add(roll);

    if (i % 10 == 0 && i != numberOfRolls)
    {
        Console.WriteLine((numberOfRolls - i) + " rolls left.");
    }
}

Console.WriteLine("Rolls completed. Ouputting Stats");

Console.WriteLine("Mean: " + dice.getAvgRolls().ToString("N3"));
Console.WriteLine("Median: " + dice.GetMedian());
Console.WriteLine("Mode: " + dice.getMode());

Console.WriteLine("\n\nStandard Probability of rolling any one value on this die: " + dice.getProbabilityStandard());
Console.WriteLine("Probability of rolling (from sample): ");
for(int i = 1; i <= dice.Sides; i++)
{
    Console.WriteLine(i + ":\t" + dice.getProbability(i).ToString("N4"));
}
Console.WriteLine("Press enter twice to exit");
Console.ReadLine();
Console.ReadLine();

int GetDieSides()
{
    int sides;
    bool sidesValidated = false;
    do
    {
        Console.WriteLine("Please enter the number of sides of your die.");
        var unSanitizedSides = Console.ReadLine();
        sidesValidated = int.TryParse(unSanitizedSides, out sides) && sides > 0;
    } while (!sidesValidated);
    return sides;
}

int RollCountEntry()
{
    int rolls = 100;
    bool rollsValidated = false;
    do
    {
        Console.WriteLine("Please enter the number of rolls you will be performing or click enter for 100.");
        var unSanitizedRolls = Console.ReadLine();
        if (unSanitizedRolls != String.Empty)
        {
            rollsValidated = int.TryParse(unSanitizedRolls, out rolls) && rolls > 0;
        }
        else
        {
            rollsValidated = true;
        }
    } while (!rollsValidated);
    return rolls;
}

int RollEntry()
{
    int roll;
    bool rollValidated = false;
    do
    {
        var unSanitizedRoll = Console.ReadLine();
        if (unSanitizedRoll != String.Empty)
        {
            rollValidated = int.TryParse(unSanitizedRoll, out roll) && roll <= dice.Sides && roll > 0;
        }
        else
        {
            roll = -1;
            rollValidated = true;
        }
        if (!rollValidated)
        {
            Console.WriteLine("Invalid entry. Please try again.");
        }
    } while (!rollValidated);
    return roll;
}


