from email.policy import default
import event as ev
import validator as v

class Meeting(ev.Event):
    def __init__(self):
        pass

    def __init__(self, date_time, person, place):
        super().__init__(date_time)
        self.set_person(person)
        self.set_place(place)

    def get_place(self):
        return self.__place

    def set_place(self, place):
        v.Validator.validate_place(place)
        self.__place = place

    def get_person(self):
        return self.__person

    def set_person(self, person):
        self.__person = person

    def __str__(self) -> str:
        return super().__str__() + self.get_place() + self.get_person()