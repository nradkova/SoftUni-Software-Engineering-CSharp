using System;
using System.Collections.Generic;
using System.Linq;

public class SetCover
{
    public static void Main(string[] args)
    {
        int[] universe = new[] { 1, 3, 5, 7, 9, 11, 20, 30, 40 };
        int[][] sets = new[]
        {
                new[] { 20 },
                new[] { 1, 5, 20, 30 },
                new[] { 3, 7, 20, 30, 40 },
                new[] { 9, 30 },
                new[] { 11, 20, 30, 40 },
                new[] { 3, 7, 40 }
            };

        List<int[]> selectedSets = ChooseSets(sets.ToList(), universe.ToList());
        Console.WriteLine($"Sets to take ({selectedSets.Count}):");

        foreach (int[] set in selectedSets)
        {
            Console.WriteLine($"{{ {string.Join(", ", set)} }}");
        }
    }

    public static List<int[]> ChooseSets(IList<int[]> sets, IList<int> universe)
    {
        var selectedSets = new List<int[]>();
        while (universe.Count>0)
        {
            var set = sets.OrderByDescending(x => x.Count(universe.Contains)).First();
            selectedSets.Add(set);
            sets.Remove(set);
            foreach (var item in set)
            {
                universe.Remove(item);
            }
        }
            return selectedSets;
    }
}
