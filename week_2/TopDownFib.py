n = int(input())

# Top down dynamic programming, right?
def fibonacci(n):
    fib_array = [0, 1]

    while (len(fib_array) < n + 1):
        fib_array.append(-1)
    
    if n <= 1:
        return n
    else:
        if fib_array[n-1] == -1:
            fib_array[n-1] = fibonacci(n-1)
        if fib_array[n-2] == -1:
            fib_array[n-2] = fibonacci(n-2)
    
    fib_array[n] = fib_array[n-2] + fib_array[n-1]
    return fib_array[n]

print(fibonacci(n))