package main

import (
	"flag"
	"fmt"
	"os"

	eduid "github.com/shanghai-edu/eduid/golang"
)

const (
	VERSION = "0.1.0"
)

func main() {
	version := flag.Bool("v", false, "show version")
	str := flag.String("s", "", "string to generate eduid")

	flag.Parse()

	if *version {
		fmt.Println(VERSION)
		os.Exit(0)
	}

	if *str == "" {
		fmt.Println("use -s teststring to generate eduid")
		os.Exit(0)
	}

	fmt.Println(eduid.GenerateShanghaiEduID(*str))
}
