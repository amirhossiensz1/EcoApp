using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Model;

namespace DBLayer
{
    public class WeekScheduleDb
    {
        private readonly EchoDBEntities _ecoDbEntities = new EchoDBEntities();

        public void Insert(WeekSchedule weekSchedule)
        {
            try
            {
                _ecoDbEntities.WeekSchedules.Add(weekSchedule);
                _ecoDbEntities.SaveChanges();
            }
            catch (Exception exception)
            {
                throw;
            }
        }

        public void UpdateAndAdd(WeekSchedule weekSchedule)
        {
            try
            {
                var weekSch =
                    _ecoDbEntities.WeekSchedules.FirstOrDefault(
                        x => x.SchGroupID == weekSchedule.SchGroupID & x.weekday == weekSchedule.weekday);
                if (weekSch != null)
                {
                    weekSch.DayTypeID = weekSchedule.DayTypeID;

                    _ecoDbEntities.Entry(weekSch).State = EntityState.Modified;
                }
                else
                {
                    _ecoDbEntities.WeekSchedules.Add(weekSchedule);
                }
                _ecoDbEntities.SaveChanges();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public List<WeekSchedule> SelectWeekDaysBySchGroupId(int schGroupId)
        {
            try
            {
                var weekdaysSch = _ecoDbEntities.WeekSchedules.Where(x => x.SchGroupID == schGroupId);
                return weekdaysSch.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int DeleteBySchId(WeekSchedule weekSchedule)
        {
            try
            {
                var weeksch = _ecoDbEntities.WeekSchedules.FirstOrDefault(x => x.SchGroupID == weekSchedule.SchGroupID &
                                                                               x.weekday == weekSchedule.weekday);

                if (weeksch != null)
                {
                    var result = _ecoDbEntities.WeekSchedules.Remove(weeksch);
                    _ecoDbEntities.SaveChanges();
                    return result.ID;
                }
                return -1;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int DeleteBySchGroupId(int schGroupId)
        {
            try
            {
                var weekschList = _ecoDbEntities.WeekSchedules.Where(x => x.SchGroupID == schGroupId);
                {
                    _ecoDbEntities.WeekSchedules.RemoveRange(weekschList);
                    _ecoDbEntities.SaveChanges();
                    return 1;
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