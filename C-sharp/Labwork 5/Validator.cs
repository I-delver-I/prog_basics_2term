using System;

namespace Labwork_5
{
    public class Validator
    {
        public static void ValidateIntType(object value)
        {
            if (!(value is TypeCode.Int32) && !(value is TypeCode.Int16) && !(value is TypeCode.Int64))
            {
                throw new ArgumentException("The entered value isn't integer");
            }
        }
    }
}