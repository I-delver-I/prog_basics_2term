from validator import *
from datetime import *
from events import *
import functions


class ActivityScheduler:
    __activities = []
    
    @staticmethod
    def add_activity(activity):
        functions.validate_event_time(activity, ActivityScheduler.get_activities_list())
        ActivityScheduler.__activities.append(activity)

    @staticmethod
    def get_activities_list():
        return ActivityScheduler.__activities

    @staticmethod
    def get_latest_meeting():
        meetings = list(filter(lambda activity: isinstance(activity, Meeting), ActivityScheduler.__activities))
        result = meetings[0]

        for meeting in meetings:
            if meeting.get_date_time() > result.get_date_time():
                result = meeting

        return result

    @staticmethod
    def assign_date_to_events(date):
        for activity in ActivityScheduler.get_activities_list():
            if isinstance(activity, Meeting):
                activity.set_date_time(datetime.combine(date, activity.get_date_time().time()))
            elif isinstance(activity, Birthday):
                activity.set_date_time(datetime.combine(date, activity.get_date_time().time()))
            