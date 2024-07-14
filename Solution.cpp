
#include <array>
#include <string>
using namespace std;

class Solution {

    static constexpr array<int, 2> PAIR = { 'a', 'b' };

public:
    int maximumGain(const string& input, int abPoints, int baPoints) const {
        int maxPoints = max(abPoints, baPoints);
        int minPoints = min(abPoints, baPoints);

        array<int, 2> pairMaxPoints = (abPoints > baPoints) ? array<int, 2>{PAIR[0], PAIR[1]} : array<int, 2>{PAIR[1], PAIR[0]};

        int maximumGain = 0;
        int countFirstLetter = 0;
        int countSecondLetter = 0;

        for (size_t i = 0; i < input.length(); ++i) {
            char current = input[i];

            if (current != pairMaxPoints[0] && current != pairMaxPoints[1]) {
                maximumGain += min(countFirstLetter, countSecondLetter) * minPoints;
                countFirstLetter = 0;
                countSecondLetter = 0;
                continue;
            }

            countFirstLetter += (current == pairMaxPoints[0]) ? 1 : 0;
            countSecondLetter += (current == pairMaxPoints[1]) ? 1 : 0;

            if (current == pairMaxPoints[1] && countFirstLetter > 0 && countSecondLetter > 0) {
                maximumGain += maxPoints;
                --countFirstLetter;
                --countSecondLetter;
            }
        }

        maximumGain += min(countFirstLetter, countSecondLetter) * minPoints;

        return maximumGain;
    }
};
