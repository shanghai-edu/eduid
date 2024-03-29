### Shanghai-Edu-ID

### examples

#### golang example
```Go
package main

import (
	"fmt"

	eduid "github.com/shanghai-edu/eduid/golang"
)

func main() {
	fmt.Println(eduid.GenerateShanghaiEduID("110101200101016874"))
    // 4788e071-bdc7-54a8-a187-0c6d6da9a237
}
```

#### python example
get eduid.py from https://github.com/shanghai-edu/eduid
```Python
# -*- coding: utf-8 -*-
import eduid

print(eduid.GenerateShanghaiEduID("110101200101016874"))
# 4788e071-bdc7-54a8-a187-0c6d6da9a237
```

#### php example
get eduid.php from https://github.com/shanghai-edu/eduid
```PHP
<?php
include 'eduid.php';

echo GenerateShanghaiEduID("110101200101016874")
# 4788e071-bdc7-54a8-a187-0c6d6da9a237
?>
```

#### C# example
get eduid.cs from https://github.com/shanghai-edu/eduid
```C#
string UUID = eduid.GenerateShanghaiEduID("110101200101016874");
Console.WriteLine(UUID);
```

#### Java example
get eduid.java from https://github.com/shanghai-edu/eduid
```Java
String result = eduid.GenerateShanghaiEduID("110101200101016874");
System.out.println(result);
```

#### MySQL example
import eduid.sql from https://github.com/shanghai-edu/eduid
```sql
select eduid('110101200101016874') as eduid
-- 4788e071-bdc7-54a8-a187-0c6d6da9a237
```

### tools
```bash
# tool -h
Usage of tool:
  -s string
        string to generate eduid
  -v    show version

# tool -s 110101200101016874
4788e071-bdc7-54a8-a187-0c6d6da9a237
```