using System;
using System.Text.RegularExpressions;

namespace Labwork_1_2
{
    [Serializable]
    struct Date
    {
        private static Regex _datePattern = new Regex(@"[0-3]{1}[0-9]{1}-(0|1){1}[0-9]{1}-\d{4}$");

        private string _creationDate;
        public string CreationDate
        {
            get => _creationDate;
            set
            {
                if (_datePattern.IsMatch(value))
                {
                    _creationDate = value;
                }
                else
                {
                    throw new ArgumentException("The entered creation date isn't valid");
                }
            }
        }

        private string _expirationDate;
        public string ExpirationDate
        {
            get => _expirationDate;
            set
            {
                if (_datePattern.IsMatch(value))
                {
                    _expirationDate = value;
                }
                else
                {
                    throw new ArgumentException("The entered expiration date isn't valid");
                }
            }
        }

        private string _currentDate;
        public string CurrentDate 
        {
            get => _currentDate;
            set
            {
                if (_datePattern.IsMatch(value))
                {
                    _currentDate = value;
                }
                else
                {
                    throw new ArgumentException("The entered current date isn't valid");
                }
            }
        }
    }
}
