# -*- coding: utf-8 -*-
import uuid

def GenerateShanghaiEduID(IdNumber):
    ShanghaiEduDomain = "sh.edu.cn"
    eduidNameSpace = uuid.uuid5(uuid.NAMESPACE_DNS, ShanghaiEduDomain)
    return uuid.uuid5(eduidNameSpace, IdNumber)
    
if __name__ == '__main__':
    print(GenerateShanghaiEduID("110101200101016874"))