const int LOWER_DIFFERENCE = 96;
const int UPPER_DIFFERENCE = 38;

const int GROUP_SIZE = 3;

int SumOfWrongItemsPriorities(string filepath)
{
    var sumOfPriorities = 0;

    foreach (var rucksack in File.ReadLines(filepath))
    {
        var firstCompartment = rucksack.Substring(0, rucksack.Length / 2);
        var secondCompartment = rucksack.Substring(rucksack.Length / 2);

        foreach (var item in firstCompartment.Intersect<char>(secondCompartment).ToArray<char>())
        {
            if (char.IsAsciiLetterLower(item))
                sumOfPriorities += Convert.ToInt32(item) - LOWER_DIFFERENCE;
            else
                sumOfPriorities += Convert.ToInt32(item) - UPPER_DIFFERENCE;
        }
    }

    return sumOfPriorities;
}

int SumBadgesPriorities(string filepath)
{
    var sumOfPriorities = 0;
    var itemIndex = 0;
    var group = new string[GROUP_SIZE];

    foreach (var rucksack in File.ReadLines(filepath))
    {
        group[itemIndex] = rucksack;

        if (itemIndex == GROUP_SIZE - 1)
        {
            var commonItemsFirstSecond = group[0].Intersect<char>(group[1]).ToArray<char>();

            foreach (var item in commonItemsFirstSecond.Intersect<char>(group[2]).ToArray<char>())
            {
                if (char.IsAsciiLetterLower(item))
                    sumOfPriorities += Convert.ToInt32(item) - LOWER_DIFFERENCE;
                else
                    sumOfPriorities += Convert.ToInt32(item) - UPPER_DIFFERENCE;
            }

            itemIndex = 0;
        }
        else
            itemIndex++;
    }

    return sumOfPriorities;
}

Console.WriteLine($"Sum of the priorities of items in both rucksack's compartments is {SumOfWrongItemsPriorities(args[0])}");
Console.WriteLine($"Sum of the priorities of badges is {SumBadgesPriorities(args[0])}");
