using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeCalculator
{
    class ViewModel : ObservableObject
    {
        private const float kSecsInMinute = (float)60;
        private const float kSecsInHour = (float)60 * 60;
        private const float kSecsInDay = (float)60 * 60 * 24;
        private string _seconds;
        private float tol = 0.004f;
        public string seconds
        {
            get { return _seconds; }
            set { _seconds = value; OnPropertyChanged(); }
        }

        private string _convertedStr;
        public string convertedStr
        {
            get { return _convertedStr; }
            set { _convertedStr = value; OnPropertyChanged(); }
        }

        public void ConvertTime()
        {
            float secondsFloat;
            float convertedTime;
            string convertedUnits;
            
            bool success = float.TryParse(_seconds, out secondsFloat);

            if (!success)
            {
                convertedStr = "";
                return;
            }

            if (secondsFloat < kSecsInMinute)
            {
                convertedUnits = "seconds";
                convertedTime = secondsFloat;
            } else if (secondsFloat < kSecsInHour)
            {
                convertedUnits = "minutes";
                convertedTime = secondsFloat / kSecsInMinute;
            } else if (secondsFloat < kSecsInDay)
            {
                convertedUnits = "hours";
                convertedTime = secondsFloat / kSecsInHour;
            } else
            {
                convertedUnits = "days";
                convertedTime = secondsFloat / kSecsInDay;
            }

            formatString(convertedTime, convertedUnits);
        }
        private void formatString(float convertedTime, string convertedUnits)
        {
            if (convertedTime - Math.Floor(convertedTime) < tol && Math.Floor(convertedTime) == 1)
            {
                convertedUnits = convertedUnits.Substring(0, convertedUnits.Length - 1);
            }
            convertedStr = decimal.Round((decimal)convertedTime, 2).ToString("G") + " " + convertedUnits;
        }
    }
}
