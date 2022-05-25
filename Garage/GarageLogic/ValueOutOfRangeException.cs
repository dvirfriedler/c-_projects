using System;

namespace Garage_DvirFriedler
{
    public class ValueOutOfRangeException : Exception
    {
        public ValueOutOfRangeException(float i_MinValue, float i_MaxValue)
            : base(string.Format("The value must be between {0} to {1}", i_MinValue, i_MaxValue))
        {
        }
    }
}
