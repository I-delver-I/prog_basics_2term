import sys
import string
import keyboard

# Primary text
def inputText(path):
    print("Please, enter some lines separated with ENTER (use SHIFT + ENTER to end typing):")
    with open(path + "\source.txt", "w") as file:
        line = ""
        while not keyboard.is_pressed('shift'):
            line = input()
            file.write(line + '\n')
            line = ""

def addSpaces(words):
    h = 0
    l = len(words)
    while h < l - 1:
        words[h] += " "
        h += 1

# Index of the word in list
def findIndex(i, row):
    row.strip()
    words = row.split(' ')
    j = 0
    temp = i
    addSpaces(words)
    
    if len(rows[0]) > i and rows[0].find(' ', i) != -1:
        return 0

    while j < len(words):
        temp -= len(words[j])
        if temp < 0:
            return j
        j += 1

# Adding of the needed whitespaces
def formatToLength(row, length):
    i = 0
    words = row.split(' ')
    addSpaces(words)
    i = row.find(' ', i)

    while len(row) < length and i != -1:
        temp = findIndex(i, row)
        words[temp] += " "
        row = mergeList(words)
        while row[i] == ' ':
            i += 1
        i = row.find(' ', i)
    if len(row) < length:
        return formatToLength(row, length)
    return row

def mergeList(lis):
    line = ""
    for word in lis:
        line += word
    return line

# Print the second.txt file    
def printSecond(path):
    print("The second file is:")
    with open(path + "\second.txt", "rt") as file:
        print(file.read())


############################################ Main program #################################################

path = r"C:\Users\Дима\Desktop\Studying\Labs\prog_basics_2term\Python\Labwork 1\Files"

inputText(path)

length = int(input("Enter the new length of the lines: "))
with open(path + "\source.txt", "rt") as file:
    rows = file.readlines()
with open(path + "\second.txt", "wt") as file:
    for row in rows:
        file.write(formatToLength(row, length))
printSecond(path)