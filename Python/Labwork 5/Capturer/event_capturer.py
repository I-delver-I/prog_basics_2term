from datetime import *
from activity_scheduler import *
from Capturer.datetime_capturer import *
from Capturer.person_capturer import *
from validator import *
import functions

class EventCapturer:
    def __init__(self, meetings_count = 1):
        self.set_meetings_count(meetings_count)
    
    def get_meetings_count(self):
        return self.__meetings_count

    def set_meetings_count(self, meetings_count):
        Validator.validate_meetings_count(meetings_count)
        self.__meetings_count = meetings_count

    def capture_events(self):
        while self.__meetings_count > 0:
            try:    
                self.__meetings_count -= 1
                ActivityScheduler.add_activity(EventCapturer.__capture_meeting())

                if self.__meetings_count == 0:
                    ActivityScheduler.add_activity(self.__capture_birthday())
            except ValueError as ve:
                print(ve)
                self.__meetings_count += 1

        return ActivityScheduler.get_activities_list()

    @staticmethod
    def capture_max_meetings_count():
        exception_is_thrown = True
        max_meetings_count = 0
        eventCapturer = EventCapturer()

        while exception_is_thrown:
            exception_is_thrown = False

            try:
                eventCapturer.set_meetings_count(int(input("Please, enter maximal count of meetings per day: ")))
            except TypeError as te:
                print(te)
                exception_is_thrown = True
            except ValueError as ve:
                print(ve)
                exception_is_thrown = True

        return eventCapturer.get_meetings_count()

    @staticmethod
    def __capture_place(activity):
        place = ""
        exception_is_thrown = True

        while exception_is_thrown:
            exception_is_thrown = False

            try:
                if isinstance(activity, Birthday):
                    place = input("Please, enter the meeting place: ")
                    activity.set_celebration_place(place)
                elif isinstance(activity, Meeting):
                    place = input("Please, enter the celebration place: ")
                    activity.set_place(place)
            except ValueError as ve:
                print(ve)
                exception_is_thrown = True

        return place         

    @staticmethod
    def __capture_meeting():
        meeting = Meeting(datetime(1, 1, 1), PersonModel(" ", " ", " "), " ")
        exception_is_thrown = True

        while exception_is_thrown:
            print("You are forming a meeting:")
            exception_is_thrown = False

            try:
                print("Please, identificate the person to meet:")
                PersonCapturer.capture_person(meeting)
                EventCapturer.__capture_place(meeting)
                meeting.set_date_time(datetime.combine(meeting.get_date_time().date(), DateTimeCapturer.capture_time()))
                functions.print_dash_line()
            except ValueError as ve:
                print(ve)
                exception_is_thrown = True

        return meeting

    @staticmethod
    def __capture_birthday():
        birthday = Birthday(PersonModel(' ', ' ', ' '), datetime(1, 1, 1), 1, ' ')
        exception_is_thrown = True

        while exception_is_thrown:
            print("You are forming a birthday:")
            exception_is_thrown = False

            try:
                print("Please, identificate the celebrant:")
                PersonCapturer.capture_person(birthday)
                EventCapturer.__capture_place(birthday)
                birthday.set_date_time(datetime.combine(birthday.get_date_time().date(), DateTimeCapturer.capture_time()))
                functions.print_dash_line()
            except ValueError as ve:
                print(ve)
                exception_is_thrown = True

        return birthday