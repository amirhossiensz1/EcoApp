using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using DBLayer;
using Model;

namespace BLL
{
    public class TrafficLogBLL
    {
        private readonly PersianCalendar _perCalendar = new PersianCalendar();

        public void Log(string OnlineLog)
        {
            try
            {
                var trafficLog = new TrafficLog();


                var personIdIndex = OnlineLog.IndexOf("Person_ID", StringComparison.Ordinal);
                var authenTypeIndex = OnlineLog.IndexOf("Authen_Type", StringComparison.Ordinal);
                var cardCodeIndex = OnlineLog.IndexOf("Person_Card_Code", StringComparison.Ordinal);
                var pdpIdIndex = OnlineLog.IndexOf("PDP_ID", StringComparison.Ordinal);
                var enterDirIndex = OnlineLog.IndexOf("Enter_Dir", StringComparison.Ordinal);
                var taTimeIndex = OnlineLog.IndexOf("TA_Time", StringComparison.Ordinal);
                var endIndex = OnlineLog.IndexOf("\r\n\r\n", StringComparison.Ordinal);

                var personId =
                    Convert.ToInt32(OnlineLog.Substring(personIdIndex + 10, authenTypeIndex - (personIdIndex + 10)));
                trafficLog.EmpID = personId;

                var authenType =
                    Convert.ToInt32(OnlineLog.Substring(authenTypeIndex + 12, cardCodeIndex - (authenTypeIndex + 12)));
                trafficLog.Mode = authenType;

                var str = OnlineLog.Substring(cardCodeIndex + 17, pdpIdIndex - (cardCodeIndex + 19));
                var personCardCode = str == "\r\n"
                    ? "0"
                    : OnlineLog.Substring(cardCodeIndex + 17, pdpIdIndex - (cardCodeIndex + 19));

                var pdpId = Convert.ToInt32(OnlineLog.Substring(pdpIdIndex + 7, enterDirIndex - (pdpIdIndex + 7)));
                trafficLog.DeviceID = pdpId;

                var enterDir =
                    Convert.ToInt32(OnlineLog.Substring(enterDirIndex + 10, taTimeIndex - (enterDirIndex + 10)));
                trafficLog.Type = enterDir;

                var dateAndTime = OnlineLog.Substring(taTimeIndex + 8, endIndex - (taTimeIndex + 8));
                var timeIndex = dateAndTime.IndexOf(" ");
                var taDate = dateAndTime.Substring(0, timeIndex);
                trafficLog.Date = ConvertDate(taDate);

                var taTime = dateAndTime.Substring(timeIndex, 7);
                trafficLog.Time = ConvertTime(taTime);

                var trafficLogDb = new TrafficLogDb();
                trafficLogDb.Insert(trafficLog);
            }
            catch (Exception e)
            {
                throw;
            }
        }

        private string ConvertDate(string taDate)
        {
            string Date;
            Date = taDate.Substring(0, 4);
            Date += "/";
            Date += taDate.Substring(4, 2);
            Date += "/";
            Date += taDate.Substring(6, 2);

            return Date;
        }

        private string ConvertTime(string taTime)
        {
            string time;
            time = taTime.Substring(0, 3);
            time += ":";
            time += taTime.Substring(3, 2);
            time += ":";
            time += taTime.Substring(5, 2);
            return time;
        }

        public List<TrafficEmployee> SelectLog()
        {
            var trafficLogDb = new TrafficLogDb();
            var trafficLogs = trafficLogDb.SelectLog();
            return trafficLogs;
        }


        public List<TrafficEmployee> SelectOnlineLog()
        {
            var trafficList = new List<object>();
            var trafficLogDb = new TrafficLogDb();
            var trafficLogs = trafficLogDb.SelectOnlineLog();
            return trafficLogs;
        }

        public List<TrafficEmployee> SelectOfflineLog()
        {
            var trafficLogDb = new TrafficLogDb();
            var trafficLogs = trafficLogDb.SelectOfflineLog();
            return trafficLogs;
        }

        public List<TrafficEmployee> SelectTodayOnlineLog()
        {
            var trafficLogDb = new TrafficLogDb();
            var trafficLogs = trafficLogDb.SelectTodayOnlineLog(GetTodayShamsiDate());
            return trafficLogs;
        }

        public string GetTodayShamsiDate()
        {
            var year = _perCalendar.GetYear(DateTime.Now).ToString(CultureInfo.InvariantCulture);
            var month = _perCalendar.GetMonth(DateTime.Now).ToString(CultureInfo.InvariantCulture);
            var day = _perCalendar.GetDayOfMonth(DateTime.Now).ToString(CultureInfo.InvariantCulture);
            day = (day.Length == 1) ? "0" + day : day;
            month = (month.Length == 1) ? "0" + month : month;
            return ConvertDate((year + month + day));
        }


        //public DataTable GetTrafiicStatistic(string fromDate, string toDate)
        //{
        //    try
        //    {
        //        var trafficLogDb = new TrafficLogDb();
        //        var table = new DataTable("Table1");
        //        table.Columns.Add("Argument", typeof (string));
        //        table.Columns.Add("Value", typeof (int));
        //        var traffics = trafficLogDb.GetTrafiicStatistic(fromDate, toDate);
        //        DataRow row = null;

        //        for (var i = 0; i < traffics.Count(); i++)
        //        {
        //            row = table.NewRow();
        //            row["Argument"] = traffics[i].DeviceName;
        //            row["Value"] = traffics[i].countTraffic;
        //            table.Rows.Add(row);
        //        }

        //        return table;
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}
    }
}