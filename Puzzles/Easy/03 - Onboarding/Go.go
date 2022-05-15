package main

/********************************************/
/*                                          */
/* CodinGame.com Solutions by Nicklas185105 */
/*                                          */
/* Puzzle: ASCII Art                        */
/* Difficulty: Easy                         */
/* Date solved: 15.05.2022                  */
/*                                          */
/********************************************/

import "fmt"

func main() {
	for {
		// enemy1: name of enemy 1
		var enemy1 string
		fmt.Scan(&enemy1)

		// dist1: distance to enemy 1
		var dist1 int
		fmt.Scan(&dist1)

		// enemy2: name of enemy 2
		var enemy2 string
		fmt.Scan(&enemy2)

		// dist2: distance to enemy 2
		var dist2 int
		fmt.Scan(&dist2)

		// Enter the code here

		if dist1 < dist2 {
			fmt.Println(enemy1)
		} else {
			fmt.Println(enemy2)
		}
	}
}
