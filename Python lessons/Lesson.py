def factorial(number):
    result = 1
    for j in range(1, number + 1):
        result *= j
    return result


file = open('Resources.txt')
number_of_conditions = int(file.readline())

i = 0
condition = ""
for i in range(1, number_of_conditions + 1):
    condition = file.readline()
    if i != number_of_conditions:
        condition = condition[:-1]
    condition = condition.split()
    N = int(condition[0])
    K = int(condition[1])
    print(int(factorial(N)/(factorial(K) * factorial(N - K))))
