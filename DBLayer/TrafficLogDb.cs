using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Model;
//using DevExpress.Data.Filtering.Helpers;

namespace DBLayer
{
    public class TrafficLogDb
    {
        public void Insert(TrafficLog trafficLog)
        {
            try
            {
                var echoDbEntities = new EchoDBEntities();
                echoDbEntities.TrafficLogs.Load();
                echoDbEntities.TrafficLogs.Add(trafficLog);
                echoDbEntities.SaveChanges();
            }
            catch (Exception exception1)
            {
                Console.WriteLine(exception1);
            }
        }

        public List<TrafficEmployee> SelectLog()
        {
            try
            {
                var echoDbEntities = new EchoDBEntities();
                var trafficLogList = from trafficLog in echoDbEntities.TrafficLogs
                                     join device in echoDbEntities.Devices
                        on trafficLog.DeviceID equals device.ID
                    join employee in echoDbEntities.Employees
                        on trafficLog.EmpID equals employee.ID into temp
                        from t in temp.DefaultIfEmpty()
                        select new TrafficEmployee
                        {
                            Id = t.ID,
                            EmpFname = t.EmpFname,
                            EmpLname = t.EmpLname,
                            EmpPersonalNum = t.PersonalNum,
                            DeviceName = device.DeviceName,
                            //Image = employee.Image,
                            Date = trafficLog.Date,
                            Time = trafficLog.Time,
                            Mode = trafficLog.Mode,
                            Type = trafficLog.Type,
                            SuccessPass = trafficLog.SuccessPass,ReqType = trafficLog.ReqType
                        };
                return trafficLogList.ToList();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                return null;
            }
        }

        public List<TrafficEmployee> SelectOnlineLog()
        {
            try
            {
                var echoDbEntities = new EchoDBEntities();
                var trafficLogList = from trafficLog in echoDbEntities.TrafficLogs
                    join employee in echoDbEntities.Employees
                        on trafficLog.EmpID equals employee.ID
                    join device in echoDbEntities.Devices
                        on trafficLog.DeviceSerialNumber equals device.DeviceSerial
                    where trafficLog.status == true
                    select new TrafficEmployee
                    {
                        Id = trafficLog.ID,
                        EmpFname = employee.EmpFname,
                        EmpLname = employee.EmpLname,
                        DeviceName = device.DeviceName,
                        Image = employee.Image,
                        Date = trafficLog.Date,
                        Time = trafficLog.Time,
                        Mode = trafficLog.Mode,
                        Type = trafficLog.Type
                    };
                return trafficLogList.ToList();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                return null;
            }
        }

        public List<TrafficEmployee> SelectOfflineLog()
        {
            try
            {
                var echoDbEntities = new EchoDBEntities();
                var trafficLogList = from trafficLog in echoDbEntities.TrafficLogs
                    join employee in echoDbEntities.Employees
                        on trafficLog.EmpID equals employee.ID
                    join device in echoDbEntities.Devices
                        on trafficLog.DeviceSerialNumber equals device.DeviceSerial
                    where trafficLog.status == false
                    select new TrafficEmployee
                    {
                        Id = trafficLog.ID,
                        EmpFname = employee.EmpFname,
                        EmpLname = employee.EmpLname,
                        DeviceName = device.DeviceName,
                        Image = employee.Image,
                        Date = trafficLog.Date,
                        Time = trafficLog.Time,
                        Mode = trafficLog.Mode,
                        Type = trafficLog.Type
                    };
                return trafficLogList.ToList();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                return null;
            }
        }


        public List<TrafficEmployee> SelectTodayOnlineLog(string date)
        {
            try
            {
                var echoDbEntities = new EchoDBEntities();
                var trafficLogList = from trafficLog in echoDbEntities.TrafficLogs
                    join device in echoDbEntities.Devices
                         on trafficLog.DeviceID equals device.ID
                    join employee in echoDbEntities.Employees
                        on trafficLog.EmpID equals employee.ID into temp
                                     from t in temp.DefaultIfEmpty()
                    where (trafficLog.Date == date)
                    select new TrafficEmployee
                    {
                        Id = t.ID,
                        EmpFname = t.EmpFname,
                        EmpLname = t.EmpLname,
                        DeviceName = device.DeviceName,
                        Image = t.Image,
                        Date = trafficLog.Date,
                        Time = trafficLog.Time,
                        Mode = trafficLog.Mode,
                        Type = trafficLog.Type,
                        SuccessPass = trafficLog.SuccessPass,
                        ReqType = trafficLog.ReqType
                    };
                return trafficLogList.ToList();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                return null;
            }
        }

        //public List<sp_reportTrafficStatistics_Result> GetTrafiicStatistic(string fromDate, string toDate)
        //{
        //    try
        //    {
        //        var echoDbEntities = new EchoDBEntities();


        //        return echoDbEntities.sp_reportTrafficStatistics(fromDate, toDate).ToList();
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}
    }
}