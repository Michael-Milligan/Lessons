requested_toppings = []

active = True
while active:
    answer = input('Enter the topping you want: ')
    if answer.lower() == 'quit':
        break
    requested_toppings.append(answer.lower())
print(requested_toppings)
