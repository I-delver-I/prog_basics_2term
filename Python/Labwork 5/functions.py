from datetime import timedelta
from events import *


def print_events(events):
    for event in events:
        print(event)


def print_dash_line():
    print('-' * 70)


def get_birthday_from_list(activities):
    for activity in activities:
        if isinstance(activity, Birthday):
            return activity


def get_time_between_events(first_event, second_event):
        result = first_event.get_date_time() - second_event.get_date_time()

        if result.seconds // 3600 < 0 or (result.seconds // 60) % 60 < 0:
            result = timedelta(seconds = abs(result.total_seconds()))

        return result


def validate_event_time(activity, activities_list):
        min_meeting_duration = timedelta(minutes = 10)

        for activity_from_list in activities_list:
            time_between_events = timedelta(seconds = abs(get_time_between_events(activity, activity_from_list).total_seconds()))
            
            if time_between_events < min_meeting_duration:
                raise ValueError("The time between events should be at least 10 minutes")