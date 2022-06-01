from datetime import *

class DateTimeCapturer:
    @staticmethod
    def capture_time():
        result = time()
        value_is_valid = False

        while not value_is_valid:
            value_is_valid = True

            try:
                result = time.fromisoformat(input("Please, enter the time: "))
            except ValueError as ve:
                print(ve)
                value_is_valid = False

        return result

    @staticmethod
    def capture_date():
        result = date(1, 1, 1)
        value_is_valid = False

        while not value_is_valid:
            value_is_valid = True

            try:
                iso_date = input("Please, enter the date: ")
                result = date.fromisoformat(iso_date)
            except ValueError as ve:
                print(ve)
                value_is_valid = False
            except TypeError as te:
                print(te)
                value_is_valid = False

        return result