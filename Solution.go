
package main

import "fmt"

var PAIR = []byte{'a', 'b'}

func maximumGain(input string, abPoints int, baPoints int) int {
    maxPoints := max(abPoints, baPoints)
    minPoints := min(abPoints, baPoints)

    pairMaxPoints := Ternary(abPoints > baPoints, []byte{PAIR[0], PAIR[1]}, []byte{PAIR[1], PAIR[0]})

    maximumGain := 0
    countFirstLetter := 0
    countSecondLetter := 0

    for i := range input {
        current := input[i]

        if current != pairMaxPoints[0] && current != pairMaxPoints[1] {
            maximumGain += min(countFirstLetter, countSecondLetter) * minPoints
            countFirstLetter = 0
            countSecondLetter = 0
            continue
        }

        countFirstLetter += Ternary(current == pairMaxPoints[0], 1, 0)
        countSecondLetter += Ternary(current == pairMaxPoints[1], 1, 0)

        if current == pairMaxPoints[1] && countFirstLetter > 0 && countSecondLetter > 0 {
            maximumGain += maxPoints
            countFirstLetter--
            countSecondLetter--
        }
    }

    maximumGain += min(countFirstLetter, countSecondLetter) * minPoints

    return maximumGain
}

func Ternary[T any](condition bool, first T, second T) T {
    if condition {
        return first
    }
    return second
}
