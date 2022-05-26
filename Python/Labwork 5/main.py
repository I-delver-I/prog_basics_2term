from datetime import *
from email.policy import default
import birthday as b
import person_model as pm
import activity_scheduler as acs
import meeting as m


# def capture_meetings():
#     i = 0
#     meetings = []

#     while i != 2:
#         time = input("Please, enter the time of meeting:")
#         place = input("Please, enter the place of meeting:")
#         meetings.append(Meeting(time, place))
#         i -= 1

#     return meetings


# def parse_duration(duration):
#     seconds = abs(timedelta(duration))
#     duration = timedelta(seconds=seconds)


# def print_meetings(meetings):
#     for meeting in meetings:
#         print(meeting)


acs.ActivityScheduler.add_activity(b.Birthday(pm.PersonModel("sanya", "rambo", "vasiliev"), 
    datetime.strptime('26.05.2022'), 19, 'forest'))
meetings = list(filter(lambda activity: activity is m.Meeting, acs.ActivityScheduler.__activities))
max_date_time = max(list(map(lambda meeting: m.Meeting(meeting).get_date_time(), meetings)))
print(max_date_time)


# print("Please, enter the concrete date when you are free from chores: ")





