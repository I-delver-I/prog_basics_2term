from Capturer.event_capturer import *
from Capturer.datetime_capturer import *
from person_model import *
from activity_scheduler import *
from events import *
import functions


print("Please, enter the concrete date when you are free from chores: ")
concrete_date = DateTimeCapturer.capture_date()
event_capturer = EventCapturer(EventCapturer.capture_max_meetings_count())
functions.print_dash_line()

activities = event_capturer.capture_events()
ActivityScheduler.assign_date_to_events(concrete_date)
functions.print_events(activities)

print("The last meeting of the day:")
last_meeting = ActivityScheduler.get_latest_meeting()
print(last_meeting)
functions.print_dash_line()

birthday = functions.get_birthday_from_list(activities)
print(f"Period of time between last meeting and birthday: {functions.get_time_between_events(birthday, last_meeting)}")