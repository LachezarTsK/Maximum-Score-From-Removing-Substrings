
/**
 * @param {string} input
 * @param {number} abPoints
 * @param {number} baPoints
 * @return {number}
 */
var maximumGain = function (input, abPoints, baPoints) {
    const PAIR = ['a', 'b'];
    const maxPoints = Math.max(abPoints, baPoints);
    const minPoints = Math.min(abPoints, baPoints);

    const pairMaxPoints = (abPoints > baPoints) ? [PAIR[0], PAIR[1]] : [PAIR[1], PAIR[0]];

    let maximumGain = 0;
    let countFirstLetter = 0;
    let countSecondLetter = 0;

    for (let i = 0; i < input.length; ++i) {
        const current = input.charAt(i);

        if (current !== pairMaxPoints[0] && current !== pairMaxPoints[1]) {
            maximumGain += Math.min(countFirstLetter, countSecondLetter) * minPoints;
            countFirstLetter = 0;
            countSecondLetter = 0;
            continue;
        }

        countFirstLetter += (current === pairMaxPoints[0]) ? 1 : 0;
        countSecondLetter += (current === pairMaxPoints[1]) ? 1 : 0;

        if (current === pairMaxPoints[1] && countFirstLetter > 0 && countSecondLetter > 0) {
            maximumGain += maxPoints;
            --countFirstLetter;
            --countSecondLetter;
        }
    }

    maximumGain += Math.min(countFirstLetter, countSecondLetter) * minPoints;

    return maximumGain;
};
