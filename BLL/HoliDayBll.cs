using System.Collections.Generic;
using DBLayer;
using Model;

namespace BLL
{
    public class HoliDayBll
    {
        private readonly HoliDayDb _holiDayDb = new HoliDayDb();

        public List<HoliDay> SelectAll()
        {
            return _holiDayDb.SelectAll();
        }

        public int Add(HoliDay holiDay)
        {
            return _holiDayDb.Insert(holiDay);
        }

        public int Delete(int id)
        {
            return _holiDayDb.Delete(id);
        }

        public int UpdateGroupId(List<int> holidaysList, int? holidaysGroupId)
        {
            return _holiDayDb.UpdateGroupId(holidaysList, holidaysGroupId);
        }

        public int UpdateGroupIdToNull(List<int> holidaysList, int? holidaysGroupId)
        {
            return _holiDayDb.UpdateGroupIdToNull(holidaysList, holidaysGroupId);
        }

        public List<HoliDay> SelectHolidayByHolidayGroupId(int groupId)
        {
            return _holiDayDb.SelectHolidayByHolidayGroupId(groupId);
        }

        public string ExistDate(string date)
        {
            return _holiDayDb.ExistDate(date);
        }
    }
}