using KOBracketPrinter.Models;

namespace KOBracketPrinter;

public static class BracketTreeBuilder
{
    public static BracketTree Build(IReadOnlyList<Player> originalPlayers, string title)
    {
        if (originalPlayers.Count == 0)
            throw new InvalidOperationException("At least one player is required.");

        var bracketSize = GetNextPowerOfTwo(originalPlayers.Count);
        var roundCount = (int)Math.Log2(bracketSize);

        var players = originalPlayers
            .OrderBy(p => p.Seed)
            .ToList();

        while (players.Count < bracketSize)
        {
            players.Add(new Player(
                Id: -players.Count - 1,
                Name: "BYE",
                Seed: players.Count + 1,
                IsBye: true));
        }

        var seededOrder = GenerateSeedOrder(bracketSize)
            .Select(seed => players.First(p => p.Seed == seed))
            .ToList();

        var levels = new List<List<BracketTreeNode>>();
        int globalMatchNo = 1;

        for (int roundNo = 1; roundNo <= roundCount; roundNo++)
        {
            int matchesInRound = bracketSize / (int)Math.Pow(2, roundNo);
            var level = new List<BracketTreeNode>();

            for (int i = 0; i < matchesInRound; i++)
            {
                level.Add(new BracketTreeNode
                {
                    MatchNumber = globalMatchNo++,
                    RoundNumber = roundNo,
                    PositionIndex = i + 1
                });
            }

            levels.Add(level);
        }

        var firstLevel = levels[0];
        for (int i = 0; i < firstLevel.Count; i++)
        {
            firstLevel[i].Player1 = seededOrder[i * 2];
            firstLevel[i].Player2 = seededOrder[i * 2 + 1];
        }

        for (int roundIndex = 0; roundIndex < levels.Count - 1; roundIndex++)
        {
            var current = levels[roundIndex];
            var parentLevel = levels[roundIndex + 1];

            for (int i = 0; i < current.Count; i += 2)
            {
                var left = current[i];
                var right = current[i + 1];
                var parent = parentLevel[i / 2];

                parent.Left = left;
                parent.Right = right;

                left.Parent = parent;
                right.Parent = parent;
            }
        }

        AutoAdvanceByes(levels);

        return new BracketTree
        {
            Title = title,
            RequestedPlayerCount = originalPlayers.Count,
            BracketSize = bracketSize,
            Root = levels[^1].Single(),
            Levels = levels
        };
    }

    public static void SetResult(BracketTree tree, int roundNumber, int positionIndex, int score1, int score2)
    {
        var node = tree.Levels
            .SelectMany(x => x)
            .Single(x => x.RoundNumber == roundNumber && x.PositionIndex == positionIndex);

        if (node.Player1 is null || node.Player2 is null)
            throw new InvalidOperationException("Both players must exist.");

        if (score1 == score2)
            throw new InvalidOperationException("Tie is not allowed.");

        node.Score1 = score1;
        node.Score2 = score2;
        node.Winner = score1 > score2 ? node.Player1 : node.Player2;

        PropagateWinner(node);
    }

    private static void AutoAdvanceByes(List<List<BracketTreeNode>> levels)
    {
        foreach (var level in levels)
        {
            foreach (var node in level)
            {
                if (node.Player1?.IsBye == true && node.Player2 is not null && !node.Player2.IsBye)
                {
                    node.Winner = node.Player2;
                    PropagateWinner(node);
                }
                else if (node.Player2?.IsBye == true && node.Player1 is not null && !node.Player1.IsBye)
                {
                    node.Winner = node.Player1;
                    PropagateWinner(node);
                }
            }
        }
    }

    private static void PropagateWinner(BracketTreeNode node)
    {
        if (node.Parent is null || node.Winner is null)
            return;

        if (node.Parent.Left == node)
            node.Parent.Player1 = node.Winner;
        else if (node.Parent.Right == node)
            node.Parent.Player2 = node.Winner;
    }

    private static int GetNextPowerOfTwo(int value)
    {
        int power = 1;
        while (power < value)
            power *= 2;
        return power;
    }

    private static List<int> GenerateSeedOrder(int size)
    {
        var positions = new List<int> { 1, 2 };

        while (positions.Count < size)
        {
            int nextSize = positions.Count * 2 + 1;
            var next = new List<int>();

            foreach (var seed in positions)
            {
                next.Add(seed);
                next.Add(nextSize - seed);
            }

            positions = next;
        }

        return positions;
    }
}