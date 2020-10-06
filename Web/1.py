from collections import OrderedDict

class Participant(object):
    def __init__(self, name, number):
        self.name = name
        self.number = number

def find_item_occurencies_number(list1, item):
    counter = 0
    for i in list1:
        if i == item:
            counter += 1
    return counter

def remove_all_occurencies(list1, item):
    while list1.count(item) > 0:
        list1.remove(item)

participants = []
flag = int(input())
for i in range(flag):
    raw_input = input().split(' ')
    participants.append(raw_input[0])
    participants.append(raw_input[1])
participants.sort()

a = []
i = 0
j = 0
while i < len(participants):
    a.append(Participant(name = participants[i], number = find_item_occurencies_number(participants, participants[i])))
    i+=a[j].number
    j+=1
a.sort(key=lambda x: x.number, reverse=True)

b = [x.number for x in a]
c = [x.name for x in a]

if b[0] == b[1] and b[0] != b[2]:
    print(c[0], c[1], sep=' ')
else:
    print('NO SOLUTION')