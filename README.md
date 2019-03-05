# DotNetTest

The steps of execution are:

1)Ask from the user to enter the directory.
2)Program checks the directory exits or not.
3)If it exists then it shows all the files to the user which has prefix "quest" and suffix ".txt".
4)Then it asks user to enter a file name on which the computation has to be occur.
5)then program checks that the input file has the prefix "quest" and suffix ".txt" .
6)After that it checks whether the file is present in initial input directory.
7)if it is not present there it it shows the proper message.
8)if file is present then first it makes the another file.
9)The another file is named as "solved_" + user input file name.
10)After that the data from quest+ "*" + .txt is start to read.
11)After reading the data it validates the conditions.

Condition 1: The operand must be int.
Condition 2: The operator must be from {+,-,/,*,%}
Condition 3: There must be two operands.

12)If any condition voilates then it handles the exception by implementing Custom Exception and print the valid message in the file named as solved_+inputFileName+.txt.
13)If all the conditions are true then it prints the result in the file named as solved_+inputFileName+.txt .

Use Case: 

15 / 3 and 10 - 5
4 * 3
apple / 23 and 23 / x
-346.8 / 74
-232 ^ 884 and -33 & 222
1234

Output:
5 and 5
12
INVALID OPERRAND
INVALID OPERRAND
INVALID OPERATOR
INVALID INSTRUCTION



