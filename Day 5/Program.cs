const int FIRST_CONTAINER_IDX = 1;
const int CONTAINERS_GAP = 4;

const int NUMBER_OF_CONTAINERS_IDX = 1;
const int START_STACK_IDX = 3;
const int END_STACK_IDX = 5;

Stack<char>[] stacks;

Tuple<string[], string[]> ReadInput(string filepath)
{
    var input = File.ReadAllText(filepath);
    var splittedInput = input.Split("\n\n");

    var containersInfo = splittedInput[0].Split('\n');
    var movesInfo = splittedInput[1].Split('\n', StringSplitOptions.RemoveEmptyEntries);

    return new Tuple<string[], string[]>(containersInfo, movesInfo);
}

void LoadStacks(string[] containersInfo)
{
    var stackLabels = containersInfo[containersInfo.Length - 1].Split("   ", StringSplitOptions.TrimEntries);
    var numberOfStacks = Convert.ToInt32(stackLabels[stackLabels.Length - 1]);
    stacks = new Stack<char>[numberOfStacks];

    for (int i = 0; i < numberOfStacks; i++)
        stacks[i] = new Stack<char>();

    for (int i = containersInfo.Length - 2; i >= 0; i--)
    {
        int stackIndex = 0;

        for (int j = FIRST_CONTAINER_IDX; j < containersInfo[i].Length; j += CONTAINERS_GAP)
        {
            if (containersInfo[i][j] != ' ')
                stacks[stackIndex].Push(containersInfo[i][j]);

            stackIndex++;
        }
    }
}

void MoveStacks(string[] movesInfo)
{
    foreach (var line in movesInfo)
    {
        var moveInfo = line.Split(' ');
        var numberOfContainers = Convert.ToInt32(moveInfo[NUMBER_OF_CONTAINERS_IDX]);
        var startingStack = Convert.ToInt32(moveInfo[START_STACK_IDX]) - 1;
        var endingStack = Convert.ToInt32(moveInfo[END_STACK_IDX]) - 1;

        for (var i = 0; i < numberOfContainers; i++)
        {
            var movedContainer = stacks[startingStack].Pop();
            stacks[endingStack].Push(movedContainer);
        }
    }
}

void MoveStacksWithNewCrane(string[] movesInfo)
{
    foreach (var line in movesInfo)
    {
        var moveInfo = line.Split(' ');
        var numberOfContainers = Convert.ToInt32(moveInfo[NUMBER_OF_CONTAINERS_IDX]);
        var startingStack = Convert.ToInt32(moveInfo[START_STACK_IDX]) - 1;
        var endingStack = Convert.ToInt32(moveInfo[END_STACK_IDX]) - 1;

        var auxiliaryStack = new Stack<char>();

        for (var i = 0; i < numberOfContainers; i++)
        {
            var movedContainer = stacks[startingStack].Pop();
            auxiliaryStack.Push(movedContainer);
        }

        var auxiliaryStackSize = auxiliaryStack.Count;

        for (var i = 0; i < auxiliaryStackSize; i++)
        {
            var movedContainer = auxiliaryStack.Pop();
            stacks[endingStack].Push(movedContainer);
        }
    }
}

string PrintTopCrates()
{
    string topCratesMessage = "";

    foreach (var stack in stacks)
        topCratesMessage += stack.Peek();

    return topCratesMessage;
}

var puzzleData = ReadInput(args[0]);

LoadStacks(puzzleData.Item1);
MoveStacks(puzzleData.Item2);
Console.WriteLine($"Crates at the top of stacks give {PrintTopCrates()} message");

LoadStacks(puzzleData.Item1);
MoveStacksWithNewCrane(puzzleData.Item2);
Console.WriteLine($"Crates moved by a new crane at the top of stacks give {PrintTopCrates()} message");
