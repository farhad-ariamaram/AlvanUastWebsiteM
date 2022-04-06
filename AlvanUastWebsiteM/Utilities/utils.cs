using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace AlvanUastWebsiteM.Utilities
{
    public static class utils
    {
        public static string toPersianDate(this DateTime d)
        {
            try
            {
                string res = "";
                PersianCalendar pc = new PersianCalendar();
                string dayOfWeek = "شنبه";
                switch (pc.GetDayOfWeek(d))
                {
                    case DayOfWeek.Sunday:
                        dayOfWeek = "یکشنبه";
                        break;
                    case DayOfWeek.Monday:
                        dayOfWeek = "دوشنبه";
                        break;
                    case DayOfWeek.Tuesday:
                        dayOfWeek = "سشنبه";
                        break;
                    case DayOfWeek.Wednesday:
                        dayOfWeek = "چهارشنبه";
                        break;
                    case DayOfWeek.Thursday:
                        dayOfWeek = "پنجشنبه";
                        break;
                    case DayOfWeek.Friday:
                        dayOfWeek = "جمعه";
                        break;
                    case DayOfWeek.Saturday:
                        dayOfWeek = "شنبه";
                        break;
                    default:
                        dayOfWeek = "شنبه";
                        break;
                }
                string month = "تیر";
                switch (pc.GetMonth(d))
                {
                    case 1:
                        month = "فروردین";
                        break;
                    case 2:
                        month = "اردیبهشت";
                        break;
                    case 3:
                        month = "خرداد";
                        break;
                    case 4:
                        month = "تیر";
                        break;
                    case 5:
                        month = "مرداد";
                        break;
                    case 6:
                        month = "شهریور";
                        break;
                    case 7:
                        month = "مهر";
                        break;
                    case 8:
                        month = "آبان";
                        break;
                    case 9:
                        month = "آذر";
                        break;
                    case 10:
                        month = "دی";
                        break;
                    case 11:
                        month = "بهمن";
                        break;
                    case 12:
                        month = "اسفند";
                        break;
                    default:
                        month = "تیر";
                        break;
                }
                res = string.Format("{0} - {1} {2} {3}", dayOfWeek, pc.GetDayOfMonth(d), month, pc.GetYear(d));
                return res;
            }
            catch (Exception)
            {
                return "شنبه - 16 تیر 1400";
            }
        }

        public static string ToW3CDate(this DateTime dt)
        {
            return $"{dt.ToUniversalTime().ToString("s")}Z";
        }
    }
}
