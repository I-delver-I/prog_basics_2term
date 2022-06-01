from events import *
from person_model import *


class PersonCapturer:
    @staticmethod
    def __capture_age(birthday):
        age = 0
        exception_is_thrown = True

        while exception_is_thrown:
            exception_is_thrown = False
            age = int(input("Please, enter the celebrant's age: "))

            try:
                Birthday(birthday).set_age(age)
            except TypeError:
                print("The entered value isn't a number")
                exception_is_thrown = True
            except ValueError as ve:
                print(ve)
                exception_is_thrown = True

        return age

    @staticmethod
    def capture_person(activity):
        person = PersonModel(' ', ' ', ' ')
        exception_is_thrown = True

        while exception_is_thrown:
            exception_is_thrown = False

            try:
                person.set_first_name(input("Please, enter the first name: "))
                person.set_second_name(input("Please, enter the second name: "))
                person.set_patronymic(input("Please, enter the patronymic: "))

                if isinstance(activity, Birthday):
                    PersonCapturer.__capture_age(activity)
                    activity.set_celebrant(person)
                elif isinstance(activity, Meeting):
                    activity.set_person(person)
            except ValueError as ve:
                print(ve)
                exception_is_thrown = True

        return person