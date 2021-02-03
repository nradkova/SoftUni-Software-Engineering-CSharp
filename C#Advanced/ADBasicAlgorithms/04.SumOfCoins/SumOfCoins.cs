using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Linq.Expressions;

public class SumOfCoins
{
    public static void Main(string[] args)
    {

        var availableCoins = new[] { 1, 2, 5, 10, 20, 50 };
        var targetSum = 923;
        //var availableCoins = new[] { 3, 7 };
        //var targetSum = 11;
        try
        {
        var selectedCoins = ChooseCoins(availableCoins, targetSum);
        Console.WriteLine($"Number of coins to take: {selectedCoins.Values.Sum()}");
        foreach (var selectedCoin in selectedCoins)
        {
            Console.WriteLine($"{selectedCoin.Value} coin(s) with value {selectedCoin.Key}");
        }
        }
        catch (Exception)
        {

            Console.WriteLine("Error");
        }
    }

    public static Dictionary<int, int> ChooseCoins(IList<int> coins, int targetSum)
    {
        var sortedCoins = coins.OrderByDescending(x => x).ToList();
        Dictionary<int, int> selectedCoins = new Dictionary<int, int>();
        int index = 0;
        while (targetSum > 0 && index < sortedCoins.Count)
        {
            if (targetSum >= sortedCoins[index])
            {
                int numberOfCoins = targetSum / sortedCoins[index];
                targetSum -= sortedCoins[index] * numberOfCoins;
                selectedCoins.Add(sortedCoins[index], numberOfCoins);
            }
            else
            {
                index++;
            }
        }
        if (targetSum==0)
        {
            return selectedCoins;
        }
        else
        {
            throw new InvalidOperationException();
        }
    }
}