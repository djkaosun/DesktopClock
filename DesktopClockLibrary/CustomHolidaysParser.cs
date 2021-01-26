using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text.Json;

namespace DesktopClock.Library
{
    /// <summary>
    /// 保存のため、カスタム休日をシリアライズ、デシリアライズします。
    /// </summary>
    public static class CustomHolidaysParser
    {
        /// <summary>
        /// シリアライズされた文字列を、<see cref="System.Collections.ObjectModel.ObservableCollection{T}"/> に戻します。
        /// </summary>
        /// <param name="customHolidaysString">シリアライズされた文字列。</param>
        /// <param name="customHolidays">でシリアライス結果を入れるコレクション。渡されたコレクションはクリアされます。null の場合は新しいコレクションが生成されます。</param>
        /// <returns>カスタム休日を格納した <see cref="System.Collections.ObjectModel.ObservableCollection{T}"/>。</returns>
        public static ObservableCollection<KeyValuePair<DateTime, string>> Deserialize(string customHolidaysString, ObservableCollection<KeyValuePair<DateTime, string>> customHolidays = null)
        {
            if (customHolidays == null)
            {
                customHolidays = new ObservableCollection<KeyValuePair<DateTime, string>>();
            }
            else
            {
                customHolidays.Clear();
            }

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

        /// <summary>
        /// カスタム休日を格納した <see cref="System.Collections.ObjectModel.ObservableCollection{T}"/> を、文字列にシリアライズします。
        /// </summary>
        /// <param name="customHolidays">カスタム休日を格納した <see cref="System.Collections.ObjectModel.ObservableCollection{T}"/>。</param>
        /// <returns>シリアライズされた文字列。</returns>
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
