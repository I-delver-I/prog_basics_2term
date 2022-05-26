import birthday as b
import meeting as m
import validator as v
import activity_scheduler as acs
from datetime import date, datetime, time
import event as ev

class ActivityScheduler:
    __activities = []
    
    @staticmethod
    def add_activity(activity):
        v.Validator.validate_event_time(activity)
        ActivityScheduler.__activities.append(activity)

    @staticmethod
    def get_activities_list():
        return ActivityScheduler.__activities

    @staticmethod
    def get_latest_meeting():
        meetings = list(filter(lambda activity: activity is m.Meeting, ActivityScheduler.__activities))
        max_date_time = max(list(map(lambda meeting: m.Meeting(meeting).get_date_time(), meetings)))

        return next(meeting for meeting in meetings if m.Meeting(meeting).get_date_time() == max_date_time())

    @staticmethod
    def assign_date_to_events(date):
        for activity in acs.ActivityScheduler.get_activities_list():
            # if activity is m.Meeting:
            #     activity. = datetime.combine(date, time())
            # elif activity is b.Birthday:
            #     activity. = datetime.combine(date, time())
            pass