## Overview

The solution includes command line application and test project.
The application accepts input parameters, check if they are in the correct date format and prints date range in console. The correct date format is dependent on current culture used by thread.  
The test project contains unit tests that check if methods used in application work correctly. 

## Usage

```
program.exe 2016-03-01 2018-05-12
```

Output: `01.03.2016 - 12.05.2018`

```
program.exe 01.03.2018 12.05.2018
```

Output: `01.03 - 12.05.2018`

```
program.exe 01.04.2018 12.04.2018
```

Output: `01 - 12.04.2018`
