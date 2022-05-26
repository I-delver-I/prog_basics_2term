from email.policy import default
import validator as v


class PersonModel:
    def __init__(self):
        pass

    def __init__(self, first_name, second_name, patronymic):
        self.set_first_name(first_name)
        self.set_second_name(second_name)
        self.set_patronymic(patronymic)

    def get_first_name(self):
        return self.__first_name

    def set_first_name(self, first_name):
        v.Validator.validate_name(first_name)
        self.__first_name = first_name

    def get_second_name(self):
        return self.__second_name

    def set_second_name(self, second_name):
        v.Validator.validate_name(second_name)
        self.__second_name = second_name

    def get_patronymic(self):
        return self.__patronymic

    def set_patronymic(self, patronymic):
        v.Validator.validate_name(patronymic)
        self.__patronymic = patronymic

    def __str__(self) -> str:
        return f"First name - {self.get_first_name()}, Second name - {self.get_second_name()}, Patronymic - {self.get_patronymic()}"