from email.policy import default
import event as ev
import validator as v

class Birthday(ev.Event):
    def __init__(self):
        pass

    def __init__(self, celebrant, date_time, age, celebration_place):
        super().__init__(date_time)
        self.set_celebrant(celebrant)
        self.set_age(age)
        self.set_celebration_place(celebration_place)

    def get_age(self):
        return self.__age

    def set_age(self, age):
        v.Validator.validate_age(age)
        self.__age = age
    
    def get_celebration_place(self):
        return self.__celebration_place

    def set_celebration_place(self, celebration_place):
        v.Validator.validate_place(celebration_place)
        self.__celebration_place = celebration_place

    def get_celebrant(self):
        return self.__celebrant

    def set_celebrant(self, celebrant):
        self.__celebrant = celebrant

    def __str__(self) -> str:
        return super().__str__() + self.__place