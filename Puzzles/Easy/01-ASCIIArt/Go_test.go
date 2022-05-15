package main_test

import (
	"bufio"
	"bytes"
	"fmt"
	"io"
	"strings"
	"testing"

	"github.com/stretchr/testify/assert"
)

func testMain(t *testing.T) {
	var stdin bytes.Buffer

	stdin.Write([]byte("4"))
	stdin.Write([]byte("5"))

	var ascii []string

	ascii = append(ascii, " #  ##   ## ##  ### ###  ## # # ###  ## # # #   # # ###  #  ##   #  ##   ## ### # # # # # # # # # # ### ### ")
	ascii = append(ascii, "# # # # #   # # #   #   #   # #  #    # # # #   ### # # # # # # # # # # #    #  # # # # # # # # # #   #   # ")
	ascii = append(ascii, "### ##  #   # # ##  ##  # # ###  #    # ##  #   ### # # # # ##  # # ##   #   #  # # # # ###  #   #   #   ## ")
	ascii = append(ascii, "# # # # #   # # #   #   # # # #  #  # # # # #   # # # # # # #    ## # #   #  #  # # # # ### # #  #  #       ")
	ascii = append(ascii, "# # ##   ## ##  ### #    ## # # ###  #  # # ### # # # #  #  #     # # # ##   #  ###  #  # # # #  #  ###  #  ")

	for i := 0; i < 5; i++ {
		stdin.Write([]byte(ascii[i]))
	}

	correctResult := `# #  #  ### # #  #  ### ###  #  ###
### # # # # # # # #  #   #  # # # #
### ### # # ### ###  #   #  ### # #
# # # # # # # # # #  #   #  # # # #
# # # # # # # # # #  #   #  # # # # `

	result := program(&stdin)
	assert.NoError(t, nil)
	assert.Equal(t, correctResult, result)
}

func program(stdin io.Reader) []string {
	var result []string

	scanner := bufio.NewScanner(stdin)
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
			result = append(result, ROW[offset:offset+L])
		}
	}

	return result
}

func checkCharacter(char rune) int {
	if (char >= 'a' && char <= 'z') || (char >= 'A' && char <= 'Z') {
		return int(char - 'A')
	} else {
		return int('Z' - 'A' + 1)
	}
}
