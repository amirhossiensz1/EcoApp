using System;
using System.Collections.Generic;
using DBLayer;
using Model;

namespace BLL
{
    public class DayScheduleBll
    {
        private readonly DayScheduleDb _dayschdb = new DayScheduleDb();

        public int InsertDayScheduler(DaySchedule daysch)
        {
            return _dayschdb.InsertDaysch(daysch);
        }


        public object DeleteDayScheduler(int id)
        {
            return _dayschdb.DeleteDaySch(id);
        }

        public int UpdateDaySch(DaySchedule daysch)
        {
            return _dayschdb.UpdateDaySch(daysch);
        }

        public List<DaySchedule> SelectDaySchWithDayTypeId(int? dayTypeId)
        {
            try
            {
                return _dayschdb.SelectDaySchWithDayTypeId(dayTypeId);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}