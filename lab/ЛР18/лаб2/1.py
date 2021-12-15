from math import *

x = float(input("Введите число x; "))
if  x < 2.8 and x < 6:
    res = (x-1)/(x+1)
    print("%1.2f" %res)
else:
    res = exp(x) +sin(x)
    print("%1.2f" %res)
