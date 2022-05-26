from datetime import time, datetime

class DateTimeCapturer:
    @staticmethod
    def capture_time():
        result = time()
        value_is_used = False

        while not value_is_used:
            value_is_used = True

            try:
                result = time.strftime(input())
            except:
                pass

        return result