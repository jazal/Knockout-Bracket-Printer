using KOBracketPrinter.Models;

namespace KOBracketPrinter;

public static class BracketTreeDemoData
{
    public static void PopulateDummyResults(BracketTree tree)
    {
        foreach (var level in tree.Levels)
        {
            foreach (var node in level)
            {
                if (node.Player1 is null || node.Player2 is null)
                    continue;

                if (node.Player1.IsBye || node.Player2.IsBye)
                    continue;

                if (node.Winner is not null)
                    continue;

                var player1Wins = node.PositionIndex % 2 == 1;

                node.Score1 = player1Wins ? 4 : 2;
                node.Score2 = player1Wins ? 1 : 4;
                node.Winner = player1Wins ? node.Player1 : node.Player2;

                var parent = node.Parent;
                if (parent is not null)
                {
                    if (parent.Left == node)
                        parent.Player1 = node.Winner;
                    else if (parent.Right == node)
                        parent.Player2 = node.Winner;
                }
            }
        }
    }
}