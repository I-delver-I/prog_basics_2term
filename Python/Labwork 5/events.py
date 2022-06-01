from datetime import *
from person_model import *
import validator


class Event:
    def __init__(self, date_time = datetime(1, 1, 1)):
        self.set_date_time(date_time)

    def __eq__(self, event) -> bool:
        return self.__date_time == event.get_datetime()

    def get_date_time(self):
        return self.__date_time

    def set_date_time(self, date_time):
        if isinstance(self, Birthday):
            validator.Validator.validate_birthday_time(date_time)
        elif isinstance(self, Meeting):
            validator.Validator.validate_meeting_time(date_time)

        self.__date_time = date_time

    def __str__(self) -> str:
        return f"Date and time - {self.__date_time}"


class Meeting(Event):
    def __init__(self, date_time = datetime(1, 1, 1), person = PersonModel(), place = ' '):
        super().__init__(date_time)
        self.set_person(person)
        self.set_place(place)

    def get_place(self):
        return self.__place

    def set_place(self, place):
        validator.Validator.validate_place(place)
        self.__place = place

    def get_person(self):
        return self.__person

    def set_person(self, person):
        self.__person = person

    def __str__(self) -> str:
        return f"{super().__str__()}, Place - {self.__place}, Person to meet - {self.__person}"


class Birthday(Event):
    def __init__(self, celebrant = PersonModel(), date_time = datetime(1, 1, 1), age = 1, celebration_place = ' '):
        super().__init__(date_time)
        self.set_celebrant(celebrant)
        self.set_age(age)
        self.set_celebration_place(celebration_place)

    def get_age(self):
        return self.__age

    def set_age(self, age):
        validator.Validator.validate_age(age)
        self.__age = age
    
    def get_celebration_place(self):
        return self.__celebration_place

    def set_celebration_place(self, celebration_place):
        validator.Validator.validate_place(celebration_place)
        self.__celebration_place = celebration_place

    def get_celebrant(self):
        return self.__celebrant

    def set_celebrant(self, celebrant):
        self.__celebrant = celebrant

    def __str__(self) -> str:
        return f"{super().__str__()}, Celebration place - {self.__celebration_place}, Celebrant - {self.__celebrant}"