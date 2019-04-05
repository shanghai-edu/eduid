package eduid

import (
	"testing"
)

func Test_GenerateShanghaiEduID(t *testing.T) {
	eduid := GenerateShanghaiEduID("110101200101016874")
	t.Log(eduid)
}
