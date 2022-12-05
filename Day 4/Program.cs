int NumberOfFullyContaiedPairs(string filepath)
{
    int pairCounter = 0;

    foreach (var pair in File.ReadLines(filepath))
    {
        List<int[]> intervals = new List<int[]>();

        foreach (var interval in pair.Split(','))
            intervals.Add(Array.ConvertAll(interval.Split('-'), int.Parse));

        var intervalsArr = intervals.ToArray();
        Array.Sort(intervalsArr, (x1, x2) => x1[0] - x2[0]);

        if (intervalsArr[0][0] <= intervalsArr[1][0] && intervalsArr[0][1] >= intervalsArr[1][1])
            pairCounter++;
        else
        {
            Array.Sort(intervalsArr, (x1, x2) => x2[1] - x1[1]);
            if (intervalsArr[0][0] <= intervalsArr[1][0] && intervalsArr[0][1] >= intervalsArr[1][1])
                pairCounter++;
        }
    }

    return pairCounter;
}

int NumberOfOverlappedPairs(string filepath)
{
    int pairCounter = 0;

    foreach (var pair in File.ReadLines(filepath))
    {
        List<int[]> intervals = new List<int[]>();

        foreach (var interval in pair.Split(','))
            intervals.Add(Array.ConvertAll(interval.Split('-'), int.Parse));

        var intervalsArr = intervals.ToArray();
        Array.Sort(intervalsArr, (x1, x2) => x1[0] - x2[0]);

        if (intervalsArr[1][0] <= intervalsArr[0][1])
            pairCounter++;
    }

    return pairCounter;
}

Console.WriteLine($"Number of assignment pairs that one range fully contain the other is {NumberOfFullyContaiedPairs(args[0])}");
Console.WriteLine($"Number of assignment pairs that overlap is {NumberOfOverlappedPairs(args[0])}");
