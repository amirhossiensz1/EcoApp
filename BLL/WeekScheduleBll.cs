using System.Collections.Generic;
using DBLayer;
using Model;

namespace BLL
{
    public class WeekScheduleBll
    {
        private readonly WeekScheduleDb _weekScheduleDb = new WeekScheduleDb();

        public void Insert(WeekSchedule weekSchedule)
        {
            _weekScheduleDb.Insert(weekSchedule);
        }

        public void UpdateAndAdd(WeekSchedule weekSchedule)
        {
            _weekScheduleDb.UpdateAndAdd(weekSchedule);
        }

        public List<WeekSchedule> SelectWeekDaysBySchGroupId(int schGroupId)
        {
            return _weekScheduleDb.SelectWeekDaysBySchGroupId(schGroupId);
        }

        public int DeleteBySchId(WeekSchedule weekSchedule)
        {
            return _weekScheduleDb.DeleteBySchId(weekSchedule);
        }

        public int DeleteBySchGroupId(int id)
        {
            return _weekScheduleDb.DeleteBySchGroupId(id);
        }
    }
}