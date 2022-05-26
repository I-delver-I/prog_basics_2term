from datetime import date, datetime, timedelta
from email.policy import default
import validator as v
from abc import ABC
import birthday as b
import meeting as m

class Event(ABC):
    def __init__(self):
        super().__init__()

    def __init__(self, date_time):
        self.set_date_time(date_time)
    
    def get_date_time(self):
        return self.__date_time

    def set_date_time(self, date_time):
        if self is b.Birthday:
            v.Validator.validate_birthday_time(date_time)
        elif self is m.Meeting:
            v.Validator.validate_meeting_time(date_time)

        self.__date_time = date_time

    @staticmethod
    def get_time_between_events(first_event, second_event):
        result = timedelta(Event(first_event).get_date_time() - Event(second_event).get_date_time())

        if result.seconds // 3600 < 0 or (result.seconds // 60) % 60 < 0:
            result = timedelta(abs(result.total_seconds()))

        return result

    def __str__(self) -> str:
        return self.get_date_time()