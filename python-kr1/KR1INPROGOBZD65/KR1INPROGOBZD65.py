# coding: utf-8


# Write a program that determines the number of negative numbers in the sequence entered from the keyboard (the length of the sequence is unlimited).
# Напишите программу, которая определяет число отрицательных чисел во введенной с клавиатуры последовательности (длина последовательности неограниченна).
# python не может в русский текст почему то

print('Task 65 Cipher 29 Second year of Mogilev State Polytechnic College')

max = +1
max = int(input("Enter the maximum positive number of the sequence: "))
t = 0.0
i = 0

while True:
      t = float(input("Input the sequence : "));
      if t <= 0:
        i += 1
      if t >= max:
       break
print("The number of Negative numbers - ", i)
