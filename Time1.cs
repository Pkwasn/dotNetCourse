using System;

/*
Modify Time1 Object so that it keeps time as a single integer. That is 3600 * hours +
60 * minutes + seconds. Keep same functionality
*/
namespace TimeTest1
{

    public class Time1 : Object
    {
        // new Object to keep time as a single integer
        private int timeInSeconds;

        public Time1(int p_hours = 0, int p_minutes = 0, int p_seconds = 0)
        {
            SetTime(p_hours, p_minutes, p_seconds);
        }

        // Set new time value in 24-hour format. Perform validity
        // checks on the data. Set invalid values to zero.
        public void SetTime(int p_hours, int p_minutes, int p_seconds)
        {
			timeInSeconds = 0;
			hour = p_hours;
			minute = p_minutes;
			second = p_seconds;
        } 

        // convert time to universal-time (24 hour) format string
        public string ToUniversalString()
        {
            return $"{hour:D2}:{minute:D2}:{second:D2}";

        }

        // convert time to standard-time (12 hour) format string
        public string ToStandardString()
        {
            return $"{(hour % 12):D2}:{minute:D2}:{second:D2} {(hour < 12 ? "AM" : "PM")}";
        }

        public int hour
		{
			get {return timeInSeconds / 3600; }
			set
			{
				if (value < 0 || value > 24){
					throw new ArgumentOutOfRangeException(nameof(value),
                      "The valid range is between 0 and 24.");
				}
				timeInSeconds += (value - hour) * 3600;
			}
		}

        public int second
		{
			get { return timeInSeconds - (hour * 3600 + minute * 60); }
			set
			{
				if (value < 0 || value > 60)
				{
					throw new ArgumentOutOfRangeException(nameof(value),
                      "The valid range is between 0 and 60.");
				}
				timeInSeconds += (value - second);
			}
		}
		
		public int minute
		{
			get { return timeInSeconds / 60 - hour * 60; }
			set
			{
				if (value < 0 || value > 60)
				{
					throw new ArgumentOutOfRangeException(nameof(value),
                      "The valid range is between 0 and 60.");
				}
				timeInSeconds += (value - minute) * 60;
			}
		}
    }
}