n = int(input())

# Iterative fibonacci sequence
def fibonacci(n):
    f = [-1] * (n+2)
    f[0] = 0
    f[1] = 1

    for i in range(2, n+1):
        f[i] = f[i-2] + f[i-1]
    
    return f[n]

print(fibonacci(n))