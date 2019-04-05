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
