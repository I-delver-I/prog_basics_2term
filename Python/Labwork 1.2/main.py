import pickle 
from infrastructure import *
import datetime

path = r"C:\Users\Дима\Desktop\Studying\Labs\II term\prog_basics_2term\Python\Labwork 1.2\files\\"

print(" - - - - - - - - - - - - - - - - - - - - - - - - Product list Maker - - - - - - - - - - - - - - - - - - - - - - - - - -\n")
currentDate = datetime.datetime.fromisoformat(input("Please, enter the current date (YYYY-MM-DD): "))

# Making of product list
print("\n>>> Please, enter some products' attributes separated with ENTER (use SHIFT + ENTER to end typing):\n")
productList = createProductListInFile(path)

# Output of product list was made
print('\nThe text of the initial file contains:')
outputFileContent(path, "source.bin")
print()

# Selecting of products from initial list to the new file
selectProductsToNewFile(path, productList, currentDate)

print("The products whom existing term is going to the end (<= 10%):")
outputFileContent(path, "destination.bin")