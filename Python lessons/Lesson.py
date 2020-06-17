from decimal import Decimal

file = open('Resources.txt', 'r')
quantity_of_numbers = int(file.readline())


def calculate_sides(x1, y1, x2, y2, x3, y3):
    a = Decimal(((x1 - x2) ** 2 + (y1 - y2) ** 2) ** 0.5)
    b = Decimal(((x1 - x3) ** 2 + (y1 - y3) ** 2) ** 0.5)
    c = Decimal(((x3 - x2) ** 2 + (y3 - y2) ** 2) ** 0.5)
    return a, b, c


def calculate_area(sides):
    halfperimeter = Decimal((int(sides[0]) + int(sides[1]) + int(sides[2]))/2)
    return Decimal((halfperimeter * (halfperimeter - int(sides[0])) * (halfperimeter - int(sides[1])) * (halfperimeter -
                                                                                                         int(sides[2])))
                   ** 0.5)


for i in range(quantity_of_numbers):
    condition = file.readline().split()
    sides = calculate_sides(int(condition[0]), int(condition[1]), int(condition[2]),
                            int(condition[3]), int(condition[4]), int(condition[5]))
    print(str(calculate_area(sides)) + " ")

file.close()
