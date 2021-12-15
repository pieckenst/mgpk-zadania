from math import *

x = float(input("Введите число x; "))
y = float(input("Введите число y; "))
if  y < x:
    y = 0
    print(x)
    print(y)
elif x < y:
    x = 0
    print(x)
    print(y)
elif x == y:
    x = 100
    y = 100
    print(x)
    print(y)

