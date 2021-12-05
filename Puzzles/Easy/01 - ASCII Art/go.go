/********************************************/
/*                                          */
/* CodinGame.com Solutions by Nicklas185105 */
/*                                          */
/* Puzzle: ASCII Art                        */
/* Difficulty: Easy                         */
/* Date solved: 05.12.2021                  */
/*                                          */
/********************************************/

package main

import (
	"bufio"
	"fmt"
	"os"
	"strings"
)

/**
 * Auto-generated code below aims at helping you parse
 * the standard input according to the problem statement.
 **/

func main() {
	scanner := bufio.NewScanner(os.Stdin)
	scanner.Buffer(make([]byte, 1000000), 1000000)

	var L int
	scanner.Scan()
	fmt.Sscan(scanner.Text(), &L)

	var H int
	scanner.Scan()
	fmt.Sscan(scanner.Text(), &H)

	scanner.Scan()
	T := scanner.Text()
	T = strings.ToUpper(T)
	for i := 0; i < H; i++ {
		scanner.Scan()
		ROW := scanner.Text()

		for j := 0; j < len(T); j++ {
			offset := checkCharacter(rune(T[j])) * L
			fmt.Print(ROW[offset : offset+L])
		}

		fmt.Println()
	}
}

func checkCharacter(char rune) int {
	if (char >= 'a' && char <= 'z') || (char >= 'A' && char <= 'Z') {
		return int(char - 'A')
	} else {
		return int('Z' - 'A' + 1)
	}
}
