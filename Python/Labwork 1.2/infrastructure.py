import keyboard
import shlex
import datetime

def fillSourceFileWithProducts(path):
    with open(path + "source.bin", "wb") as source:
        while not keyboard.is_pressed('shift'):
            product = addProduct()
            source.write(bytearray(product, 'utf-8'))

def getProductsFromFile(path):
    with open(path, "rb") as file:
        productsFromFile = file.read().decode('utf-8').split('\n')
        for product in productsFromFile:
            product += '\n'

        return productsFromFile

    # Obsolete
def getProductListAndInsertToFile(path):
    productList = []
    with open(path + "source.bin", "wb") as source:
        while not keyboard.is_pressed('shift'):
            product = addProduct()
            source.write(bytearray(product, 'utf-8'))
            productList.append(product)
    return productList

def selectProductsToNewFile(path, currentDate):
    productList = getProductsFromFile(path + "source.bin")
    productListInBytes = bytearray('\n'.join(productList), 'utf-8')
       
    with open(path + "destination.bin", "wb") as destination:
        destination.write(productListInBytes)

def printProductsLastTenDaysMade(productList, currentDate):
    for product in productList:
        if checkProductWasMadeLastTenDays(product, currentDate):
            print(product)

def checkProductWasMadeLastTenDays(product, currentDate):
    if (currentDate - datetime.datetime.fromisoformat(shlex.split(product)[1])).days <= 10:
        return True
    return False

def checkSelectQuery(product, currentDate):
    creationDate = getCreationDate(product)
    expirationDate = getExpirationDate(product)
    existingTime = expirationDate - creationDate
    timeLeft = expirationDate - currentDate

    if timeLeft.days / existingTime.days <= 0.1:
        return True
    return False

def getExpirationDate(product):
    expirationDate = list(shlex.split(product))[2]
    return datetime.datetime.fromisoformat(expirationDate)

def getCreationDate(product):
    creationDate = list(shlex.split(product))[1]
    return datetime.datetime.fromisoformat(creationDate)

def outputFileContent(path):
    with open(path, "rb") as source:
        stringsFromFile = source.read().decode('utf-8').split('\n')
        for string in stringsFromFile:
            print(string)
        print('\n')

def addProduct():
    attributes = []
    attributes.append(input("Name (use quotes to product has multiple words in its name): "))
    attributes.append(input("Creation date (YYYY-MM-DD): "))
    attributes.append(input("Expiry date (YYYY-MM-DD): "))
    attributes.append(input("Price (now you can end typing): ") + "$")
    product = ' '.join(attributes)
    input("Press ENTER + SHIFT to end typing or ENTER to continue")
    if not keyboard.is_pressed('shift'):
        print("---------------------------------------------------\n")
        product += '\n'
    return product