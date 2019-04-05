package eduid

import (
	"github.com/shanghai-edu/go.uuid"
)

const (
	ShanghaiEduDomain = "sh.edu.cn"
)

func GenerateShanghaiEduID(IdNumber string) (uuidString string) {
	ns := uuid.NewV5(uuid.NamespaceDNS, ShanghaiEduDomain)
	u5 := uuid.NewV5(ns, IdNumber)
	uuidString = u5.String()
	return
}
