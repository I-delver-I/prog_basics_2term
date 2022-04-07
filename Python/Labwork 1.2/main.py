from infrastructure import *
import datetime

path = r"C:\Users\Дима\Desktop\Studying\Labs\II term\prog_basics_2term\Python\Labwork 1.2\files\\"

print(" - - - - - - - - - - - - - - - - - - - - - - - - Product list Maker - - - - - - - - - - - - - - - - - - - - - - - - - -\n")
currentDate = datetime.datetime.fromisoformat(input("Please, enter the current date (YYYY-MM-DD): "))

# Making of product list
print("\n>>> Please, enter some products' attributes\n")
productList = getProductListAndInsertToFile(path)

# Output of product list was made
print('\nThe text of the initial file contains:')
outputFileContent(path, "source.bin")
print()

# Selecting of products from initial list to the new file
selectedProducts = selectProductsToNewFileAndReturnThem(path, productList, currentDate)

print("The products whom existing term is going to the end (<= 10%):")
outputFileContent(path, "destination.bin")

print("\nThe products from total list were made for the last 10 (ten) days:\n")
printProductsLastTenDaysMade(productList, currentDate)

print("\nThe products from selected list were made for the last 10 (ten) days:\n")
printProductsLastTenDaysMade(selectedProducts, currentDate)