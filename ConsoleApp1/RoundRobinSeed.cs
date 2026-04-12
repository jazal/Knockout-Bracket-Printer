namespace TournamentGrouping;

public static class GroupDistributor
{
    /// <summary>
    /// Globally accepted group labels (skips I and O).
    /// </summary>
    public static readonly List<string> Groups = new()
    {
        "A","B","C","D","E","F","G","H","J","K",
        "L","M","N","P","Q","R","S","T","U","V",
        "W","X","Y","Z"
    };

    /// <summary>
    /// Distribute seeds into groups using:
    /// Round 1 = Ascending (A->Z), all later rounds = Descending (Z->A).
    /// </summary>
    public static Dictionary<string, List<int>> DistributeSeedsToGroups(
        int totalSeeds,
        int groupsCount)
    {
        var seeds = Enumerable.Range(1, totalSeeds);
        var groups = Groups.Take(groupsCount).ToList();

        // Sort by seed ascending (1 = strongest)
        var sorted = seeds.OrderBy(p => p).ToList();
        var result = groups.ToDictionary(g => g, _ => new List<int>());

        int groupCount = groups.Count;
        int index = 0;
        int round = 1;

        while (index < sorted.Count)
        {
            var currentRound = sorted.Skip(index).Take(groupCount).ToList();

            if (round == 1)
            {
                // Round 1: Ascending
                for (int i = 0; i < currentRound.Count; i++)
                    result[groups[i]].Add(currentRound[i]);
            }
            else
            {
                // Round 2 onwards: Descending
                for (int i = 0; i < currentRound.Count; i++)
                    result[groups[groupCount - 1 - i]].Add(currentRound[i]);
            }

            index += groupCount;
            round++;
        }

        return result;
    }

    /// <summary>
    /// Returns the group label for a given seed.
    /// </summary>
    public static (string Group, int Position, int GroupNo) GetGroupForSeed(int seed, int groupsCount, int totalSeeds, Dictionary<string, List<int>>? assigned)
    {
        if (assigned is null)
            assigned = DistributeSeedsToGroups(totalSeeds, groupsCount);

        foreach (var kvp in assigned)
        {
            if (kvp.Value.Contains(seed))
                return (kvp.Key, kvp.Value.IndexOf(seed) + 1, assigned.Keys.ToList().IndexOf(kvp.Key) + 1);
        }

        throw new ArgumentException($"Seed {seed} not found in distribution.");
    }
}

internal static class Program
{
    private static void Main()
    {
        int totalSeeds = 14;
        int groupNo = 4;

        // Limit to first 10 groups (A..K) for this demo
        var assigned = GroupDistributor.DistributeSeedsToGroups(totalSeeds, groupNo);

        // Print results
        foreach (var kvp in assigned)
        {
            Console.WriteLine($"{kvp.Key} => {string.Join(", ", kvp.Value.Select(p => p))}");
        }

        //Console.WriteLine();
        //Console.WriteLine("Lookups:");
        //Console.WriteLine($"Seed 1  is in Group {GroupDistributor.GetGroupForSeed(1, groupNo, totalSeeds, assigned)}");
        //Console.WriteLine($"Seed 20 is in Group {GroupDistributor.GetGroupForSeed(20, groupNo, totalSeeds, assigned)}");
        //Console.WriteLine($"Seed 33 is in Group {GroupDistributor.GetGroupForSeed(33, groupNo, totalSeeds, assigned)}");
    }
}
