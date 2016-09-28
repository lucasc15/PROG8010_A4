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
        private float _secsInMinute = (float)60;
        private float _secsInHour = (float)60 * 60;
        private float _secsInDay = (float)60 * 60 * 24;
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
            string convertedUnits;
            float convertedTime;
            bool success = float.TryParse(_seconds, out secondsFloat);
            if (!success)
            {
                convertedStr = "";
                return;
            }

            if (secondsFloat < _secsInMinute)
            {
                convertedUnits = "seconds";
                convertedTime = secondsFloat;
            } else if (secondsFloat < _secsInHour)
            {
                convertedUnits = "minutes";
                convertedTime = secondsFloat / _secsInMinute;
            } else if (secondsFloat < _secsInDay)
            {
                convertedUnits = "hours";
                convertedTime = secondsFloat / _secsInHour;
            } else
            {
                convertedUnits = "days";
                convertedTime = secondsFloat / _secsInDay;
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
