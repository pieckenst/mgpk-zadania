rows = int(input('Rows: '))
cols = int(input('Columns: '))
arr = [[int(input()) for i in range(cols)] for j in range(rows)]
 
for row in arr:
    print(row)
 
print('Count rows without zeros: ')
print(len([i for i in arr if 0 not in i]))

n = int(input('Enter row index where you wish to locate the maximum: ')) # индекс массива
print(f'Maximum in row: {max(arr[n])}')