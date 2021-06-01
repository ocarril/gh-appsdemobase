using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Demo.Tools.helpers
{
    public static class HelpTime
    {

        public static string ConvertYYYYMMDD(Nullable<DateTime> ValorFecha)
        {
            if (ValorFecha == null)
                return string.Empty;
            return ValorFecha.Value.Year.ToString().Trim() +
                   ValorFecha.Value.Month.ToString().Trim().PadLeft(2, '0') +
                   ValorFecha.Value.Day.ToString().Trim().PadLeft(2, '0');
        }

        public static ulong DateTimeToUnixTimestamp(this DateTime dateTime)
        {
            return Convert.ToUInt64((dateTime - new DateTime(1970, 1, 1).ToLocalTime()).TotalMilliseconds);
        }


        public static DateTime UnixTimeStampToDateTime(ulong unixTimeStamp)
        {
            DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddMilliseconds(Convert.ToDouble(unixTimeStamp)).ToLocalTime();
            return dtDateTime;
        }

    }
}
