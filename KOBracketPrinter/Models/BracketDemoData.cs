namespace KOBracketPrinter.Models;

public static class BracketDemoData
{
    public static void PopulateDummyScores(Bracket bracket)
    {
        foreach (var round in bracket.Rounds)
        {
            foreach (var match in round.Matches)
            {
                if (match.Player1 is null)
                {
                    match.Player1 = new Player(
                        Id: 100000 + round.RoundNumber * 100 + match.PositionIndex * 2,
                        Name: $"TBD A {round.RoundNumber}-{match.PositionIndex}",
                        Seed: 0);
                }

                if (match.Player2 is null)
                {
                    match.Player2 = new Player(
                        Id: 100001 + round.RoundNumber * 100 + match.PositionIndex * 2,
                        Name: $"TBD B {round.RoundNumber}-{match.PositionIndex}",
                        Seed: 0);
                }

                match.Score1 = round.RoundNumber % 2 == 0 ? 3 : 4;
                match.Score2 = round.RoundNumber % 2 == 0 ? 4 : 2;
                match.Winner = match.Score1 > match.Score2 ? match.Player1 : match.Player2;
            }
        }
    }
}
