from math import *

x = float(input("Введите число x; "))
y = float(input("Введите число y; "))
a1 = cos(x) ** 4  + sin(y) ** 2 + 1/4* cos(2 * x) ** 2 -1
a2 = sin(x+y) * sin(y-x)
print(a1)
print(a2)