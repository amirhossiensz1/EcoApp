using System;
using System.Collections.Generic;
using System.Linq;
using Model;

namespace DBLayer
{
    public class DayScheduleDb
    {
        public int InsertDaysch(DaySchedule daysch)
        {
            try
            {
                var echoDbEntities = new EchoDBEntities();
                var result = echoDbEntities.DaySchedules.Add(daysch);
                echoDbEntities.SaveChanges();
                return result.ID;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public object DeleteDaySch(int id)
        {
            try
            {
                var echoDbEntities = new EchoDBEntities();
                var daySchedule = echoDbEntities.DaySchedules.FirstOrDefault(x => x.ID == id);
                if (daySchedule != null)
                {
                    var result = echoDbEntities.DaySchedules.Remove(daySchedule);
                    echoDbEntities.SaveChanges();
                    return result;
                }
                return null;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<DaySchedule> SelectDaySchWithDayTypeId(int? dayTypeId)
        {
            try
            {
                var echoDbEntities = new EchoDBEntities();
                return echoDbEntities.DaySchedules.Where(x => x.DayTypeID == dayTypeId).ToList();
            }
            catch (Exception exception)
            {
                throw;
            }
        }

        public int UpdateDaySch(DaySchedule daySchedule)
        {
            try
            {
                var echoDbEntities = new EchoDBEntities();
                var daysch = echoDbEntities.DaySchedules.FirstOrDefault(x => x.DayTypeID == daySchedule.DayTypeID);

                if (daysch != null)
                {
                    daysch.AccessTypeID = daySchedule.AccessTypeID;
                    daysch.StartTime = daySchedule.StartTime;
                    daysch.EndTime = daySchedule.EndTime;
                    echoDbEntities.Entry(daysch).CurrentValues.SetValues(daysch);
                    echoDbEntities.SaveChanges();
                    return daysch.ID;
                }
                return -1;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}