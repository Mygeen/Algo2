triple_data = [[1, 7, 4], [10, 12, 2], [2, 5, 3], [8, 11, 4], [12, 13, 3], [3, 9, 5], [3, 4, 3],
               [4, 6, 3], [5, 8, 2], [4, 13, 6]]
intervals = []


m = [None] * len(intervals)
m[0] = 0

p = []


class Triplet:
    def __init__(self, s, f, v):
        self.s = s
        self.f = f
        self.v = v


def init_intervals(arr):
    global intervals
    for x in arr:
        intervals.append(Triplet(x[0], x[1], x[2]))


def compute_memoized_opt(i):
    if m[i] is None:
        m[i] = max(intervals[i].v + compute_memoized_opt(p[i]),
                   compute_memoized_opt(i-1))
    return m[i]


def max(a, b):
    if a >= b:
        return a
    else:
        return b


def main():
    init_intervals(triple_data)


main()
