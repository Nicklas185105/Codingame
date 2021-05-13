package main_test

import (
	"bufio"
	"bytes"
	"fmt"
	"io"
	"math"
	"strings"
	"testing"

	"github.com/stretchr/testify/assert"
)

func testMain(t *testing.T) {
	var stdin bytes.Buffer

	stdin.Write([]byte("5"))
	stdin.Write([]byte("1 -2 -8 4 5"))

	result := program(&stdin)
	assert.NoError(t, nil)
	assert.Equal(t, "1", result)
}

func program(stdin io.Reader) int {
	scanner := bufio.NewScanner(stdin)
	scanner.Buffer(make([]byte, 1000000), 1000000)

	// n: the number of temperatures to analyse
	var n int
	scanner.Scan()
	fmt.Sscan(scanner.Text(), &n)

	if n == 0 {
		return 0
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

	return closest
}
