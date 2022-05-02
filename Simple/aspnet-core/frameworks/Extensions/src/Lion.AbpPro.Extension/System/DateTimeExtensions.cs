using System;
using System.Globalization;
using System.Linq;

namespace Lion.AbpPro.Extension.System
{
    /// <summary>
    /// 时间扩展操作类
    /// </summary>
    public static class DateTimeExtensions
    {
        /// <summary>
        /// 当前时间是否周末
        /// </summary>
        /// <param name="dateTime">时间点</param>
        /// <returns></returns>
        public static bool IsWeekend(this DateTime dateTime)
        {
            DayOfWeek[] weeks = { DayOfWeek.Saturday, DayOfWeek.Sunday };
            return weeks.Contains(dateTime.DayOfWeek);
        }

        /// <summary>
        /// 当前时间是否工作日
        /// </summary>
        /// <param name="dateTime">时间点</param>
        /// <returns></returns>
        public static bool IsWeekday(this DateTime dateTime)
        {
            DayOfWeek[] weeks = { DayOfWeek.Monday, DayOfWeek.Tuesday, DayOfWeek.Wednesday, DayOfWeek.Thursday, DayOfWeek.Friday };
            return weeks.Contains(dateTime.DayOfWeek);
        }

        /// <summary>
        /// 获取时间相对唯一字符串
        /// </summary>
        /// <param name="dateTime"></param>
        /// <param name="millisecond">是否使用毫秒</param>
        /// <returns></returns>
        public static string ToUniqueString(this DateTime dateTime, bool millisecond = false)
        {
            var seconds = dateTime.Hour * 3600 + dateTime.Minute * 60 + dateTime.Second;
            var value = $"{dateTime:yyyy}{dateTime.DayOfYear}{seconds}";
            if (millisecond)
            {
                return value + dateTime.ToString("fff");
            }

            return value;
        }

        /// <summary>
        /// 将时间转换为JS时间格式(Date.getTime())
        /// </summary>
        /// <param name="dateTime"></param>
        /// <param name="millisecond">是否使用毫秒</param>
        public static string ToJsGetTime(this DateTime dateTime, bool millisecond = true)
        {
            var utc = dateTime.ToUniversalTime();
            var span = utc.Subtract(new DateTime(1970, 1, 1));
            return Math.Round(millisecond ? span.TotalMilliseconds : span.TotalSeconds).ToString(CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// 将JS时间格式的数值转换为时间
        /// </summary>
        public static DateTime FromJsGetTime(this long jsTime)
        {
            var length = jsTime.ToString().Length;
            if (!(length == 10 || length == 13))
            {
                throw new ArgumentOutOfRangeException(null, "JS时间数值的长度不正确，必须为10位或13位");
            }
            var start = new DateTime(1970, 1, 1);
            var result = length == 10 ? start.AddSeconds(jsTime) : start.AddMilliseconds(jsTime);
            return result.ToUniversalTime();
        }
    }
}