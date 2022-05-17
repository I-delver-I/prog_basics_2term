using System;

namespace Labwork_5
{
    class Time
{
    private int _hours;
    public int Hours
    {
        get => _hours;
        set
        {
            Validator.ValidateIntType(value);

            if ((value > 23) && (value < 0))
            {
                throw new ArgumentOutOfRangeException(nameof(value), 
                "The entered value doesn't meet hours' naming conventions");
            }

            _hours = value;
        }
    }
    private int _minutes;
    public int Minutes
    {
        get => _minutes;
        set
        {
            Validator.ValidateIntType(value);

            if ((value > 59) && (value < 0))
            {
                throw new ArgumentOutOfRangeException(nameof(value), 
                "The entered value doesn't meet minutes' naming conventions");
            }

            _minutes = value;
        }
    }
    private int _seconds;
    public int Seconds
    {
        get => _seconds;
        set
        {
            Validator.ValidateIntType(value);

            if ((value > 59) && (value < 0))
            {
                throw new ArgumentOutOfRangeException(nameof(value), 
                "The entered value doesn't meet seconds' naming conventions");
            }
        }
    }

    public override string ToString()
    {  
        return String.Format("{0:00}:{1:00}:{2:00}",
        this.Hours, this.Minutes, this.Seconds);
    }
}
}