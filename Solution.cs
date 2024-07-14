
using System;
using System.Collections.Generic;

public class Solution
{
    private static readonly char[] PAIR = { 'a', 'b' };

    public int MaximumGain(string input, int abPoints, int baPoints)
    {
        int maxPoints = Math.Max(abPoints, baPoints);
        int minPoints = Math.Min(abPoints, baPoints);

        char[] pairMaxPoints = (abPoints > baPoints) ? new char[] { PAIR[0], PAIR[1] } : new char[] { PAIR[1], PAIR[0] };

        int maximumGain = 0;
        int countFirstLetter = 0;
        int countSecondLetter = 0;

        for (int i = 0; i < input.Length; ++i)
        {
            char current = input[i];

            if (current != pairMaxPoints[0] && current != pairMaxPoints[1])
            {
                maximumGain += Math.Min(countFirstLetter, countSecondLetter) * minPoints;
                countFirstLetter = 0;
                countSecondLetter = 0;
                continue;
            }

            countFirstLetter += (current == pairMaxPoints[0]) ? 1 : 0;
            countSecondLetter += (current == pairMaxPoints[1]) ? 1 : 0;

            if (current == pairMaxPoints[1] && countFirstLetter > 0 && countSecondLetter > 0)
            {
                maximumGain += maxPoints;
                --countFirstLetter;
                --countSecondLetter;
            }
        }

        maximumGain += Math.Min(countFirstLetter, countSecondLetter) * minPoints;

        return maximumGain;
    }
}
