using PlayerDecision = PlayerMove;

const int WIN_SCORE = 6;
const int DRAW_SCORE = 3;

var results = new Dictionary<ElfMove, Dictionary<PlayerDecision, int>>()
{
    {ElfMove.A, new Dictionary<PlayerDecision, int>() { {PlayerDecision.X, 3}, {PlayerDecision.Y, 4}, {PlayerDecision.Z, 8}}},
    {ElfMove.B, new Dictionary<PlayerDecision, int>() { {PlayerDecision.X, 1}, {PlayerDecision.Y, 5}, {PlayerDecision.Z, 9}}},
    {ElfMove.C, new Dictionary<PlayerDecision, int>() { {PlayerDecision.X, 2}, {PlayerDecision.Y, 6}, {PlayerDecision.Z, 7}}}
};

int CalculateTotalScoreWithBadStrategy(string filepath)
{
    var totalScore = 0;

    foreach (var game in File.ReadLines(filepath))
    {
        var gameMoves = game.Split(' ');

        Enum.TryParse<ElfMove>(gameMoves[0], false, out ElfMove elfMove);
        Enum.TryParse<PlayerMove>(gameMoves[1], false, out PlayerMove playerMove);

        totalScore += (int)playerMove;

        if ((int)elfMove == (int)playerMove)
            totalScore += DRAW_SCORE;
        else
        {
            switch (playerMove)
            {
                case PlayerMove.X:
                    if (elfMove == ElfMove.C)
                        totalScore += WIN_SCORE;
                    break;
                case PlayerMove.Y:
                    if (elfMove == ElfMove.A)
                        totalScore += WIN_SCORE;
                    break;
                case PlayerMove.Z:
                    if (elfMove == ElfMove.B)
                        totalScore += WIN_SCORE;
                    break;
            }
        }
    }

    return totalScore;
}

int CalculateTotalScore(string filepath, Dictionary<ElfMove, Dictionary<PlayerDecision, int>> resultsDictionary)
{
    var totalScore = 0;

    foreach (var game in File.ReadLines(filepath))
    {
        var gameMoves = game.Split(' ');

        Enum.TryParse<ElfMove>(gameMoves[0], false, out ElfMove elfMove);
        Enum.TryParse<PlayerDecision>(gameMoves[1], false, out PlayerDecision playerDecision);

        totalScore += resultsDictionary[elfMove][playerDecision];
    }

    return totalScore;
}

Console.WriteLine($"Total tournament score calculated with bad strategy is: {CalculateTotalScoreWithBadStrategy(args[0])}");
Console.WriteLine($"Total tournament score calculated with good strategy is: {CalculateTotalScore(args[0], results)}");

enum ElfMove
{
    A = 1, B = 2, C = 3
}

enum PlayerMove
{
    X = 1, Y = 2, Z = 3
}
