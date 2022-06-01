from datetime import *

class Validator:
    @staticmethod
    def validate_name(name):
        if name == "":
            raise ValueError("Name musn't be empty")

    @staticmethod
    def validate_age(age):
        if age < 1:
            raise ValueError("The entered age musn't be less than 1")

    @staticmethod
    def validate_meetings_count(meetings_count):
        if meetings_count < 0:
            raise ValueError("The count of meetings per day can't be less than 0")

        max_meetings_count = 126

        if meetings_count > max_meetings_count:
            raise ValueError("The count of meetings per day can't be "
                + "more than 126 (at least 10 minutes per meeting and 3 hours for birthday)")

    @staticmethod
    def validate_place(place):
        if str(place) == "":
            raise ValueError("The name of place shouldn't be empty")

    @staticmethod
    def validate_meeting_time(meeting_date_time):
        last_available_meeting_time = time(20, 50)
        
        if meeting_date_time.time() > last_available_meeting_time:
            raise ValueError("The time of event shouldn't be bigger than last available (20:50)")

    @staticmethod
    def validate_birthday_time(birthday_date_time):
        mandatory_for_birthday_start = time(21, 0, 0)

        if birthday_date_time.time() > mandatory_for_birthday_start:
            raise ValueError("The mandatory for birthday celebrating is at 21 o'clock."
                + f" Current time is {birthday_date_time}")
