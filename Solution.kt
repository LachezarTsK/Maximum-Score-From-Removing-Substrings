
import kotlin.math.min
import kotlin.math.max

class Solution {

    private companion object {
        val PAIR: CharArray = charArrayOf('a', 'b')
    }

    fun maximumGain(input: String, abPoints: Int, baPoints: Int): Int {
        val maxPoints = max(abPoints, baPoints)
        val minPoints = min(abPoints, baPoints)

        val pairMaxPoints: CharArray = if (abPoints > baPoints) charArrayOf(PAIR[0], PAIR[1]) else charArrayOf(PAIR[1], PAIR[0])

        var maximumGain = 0
        var countFirstLetter = 0
        var countSecondLetter = 0

        for (i in input.indices) {
            val current = input[i]

            if (current != pairMaxPoints[0] && current != pairMaxPoints[1]) {
                maximumGain += min(countFirstLetter, countSecondLetter) * minPoints
                countFirstLetter = 0
                countSecondLetter = 0
                continue
            }

            countFirstLetter += if (current == pairMaxPoints[0]) 1 else 0
            countSecondLetter += if (current == pairMaxPoints[1]) 1 else 0

            if (current == pairMaxPoints[1] && countFirstLetter > 0 && countSecondLetter > 0) {
                maximumGain += maxPoints
                --countFirstLetter
                --countSecondLetter
            }
        }

        maximumGain += min(countFirstLetter, countSecondLetter) * minPoints

        return maximumGain
    }
}
