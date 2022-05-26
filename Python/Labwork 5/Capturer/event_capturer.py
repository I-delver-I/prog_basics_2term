from validator import Validator

class EventCapturer:
    def __init__(self):
        pass

    def __init__(self, meetings_count):
        self.set_meetings_count(meetings_count)
    
    def get_meetings_count(self):
        return self.__meetings_count

    def set_meetings_count(self, meetings_count):
        Validator.validate_meetings_count(meetings_count)
        self.__meetings_count = meetings_count

    def capture_events(self):
        while self.get_meetings_count() > 0:
            self.__meetings_count -= 1