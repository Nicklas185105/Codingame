package main

/********************************************/
/*                                          */
/* CodinGame.com Solutions by Nicklas185105 */
/*                                          */
/* Puzzle: Temperatures                     */
/* Difficulty: Easy                         */
/* Date solved: 14.05.2021                  */
/*                                          */
/********************************************/

import (
	"bufio"
	"fmt"
	"math"
	"os"
	"strings"
)

func main() {
	scanner := bufio.NewScanner(os.Stdin)
	scanner.Buffer(make([]byte, 1000000), 1000000)

	// n: the number of temperatures to analyse
	var n int
	scanner.Scan()
	fmt.Sscan(scanner.Text(), &n)

	if n == 0 {
		fmt.Println(0)
		return
	}

	scanner.Scan()

	lines := strings.SplitAfter(scanner.Text(), " ")

	closest := math.MaxInt32
	closestAbs := math.MaxInt32

	for _, t := range lines {
		var temp int
		fmt.Sscanf(t, "%d", &temp)

		current := int(math.Abs(float64(temp)))
		if closestAbs > current || (closestAbs == current && temp > closest) {
			closest = temp
			closestAbs = current
		}
	}

	fmt.Println(closest)
}
