using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text.Json;

namespace DesktopClock.Library
{
    public static class CustomHolidaysParser
    {

        public static ObservableCollection<KeyValuePair<DateTime, string>> Deserialize(string customHolidaysString)
        {
            var customHolidays = new ObservableCollection<KeyValuePair<DateTime, string>>();

            if (!String.IsNullOrEmpty(customHolidaysString)) {
                var dic = JsonSerializer.Deserialize<Dictionary<string, string>>(customHolidaysString);
                foreach (var item in dic)
                {
                    string[] date = item.Key.Split('-');
                    customHolidays.Add(new KeyValuePair<DateTime, string>(
                            new DateTime(Int32.Parse(date[0]), Int32.Parse(date[1]), Int32.Parse(date[2])), item.Value)
                            );
                }
            }
            return customHolidays;
        }


        public static string Serialize(ObservableCollection<KeyValuePair<DateTime, string>> customHolidays)
        {

            var dic = new Dictionary<string, string>();
            foreach (var keyValuePair in customHolidays)
            {
                dic.Add(keyValuePair.Key.ToString("yyyy-MM-dd"),keyValuePair.Value);
            }
            return JsonSerializer.Serialize(dic);
        }
    }
}
