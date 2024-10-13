using DBLayer;
using Model;

namespace BLL
{
    public class HoliDaysSchGroupBll
    {
        private readonly HoliDaysSchGroupDb _holiDaysSchGroupDb = new HoliDaysSchGroupDb();

        public int Insert(HoliDaysSchGroup holiDaysSchGroup)
        {
            return _holiDaysSchGroupDb.Insert(holiDaysSchGroup);
        }

        public int UpdateAndAdd(HoliDaysSchGroup holiDaysSchGroup)
        {
            return _holiDaysSchGroupDb.UpdateAndAdd(holiDaysSchGroup);
        }

        public int Delete(HoliDaysSchGroup holiDaysSchGroup)
        {
            return _holiDaysSchGroupDb.Delete(holiDaysSchGroup);
        }

        public int SelectHolidayGroupId(int schGroupId)
        {
            return _holiDaysSchGroupDb.SelectHolidayGroupId(schGroupId);
        }

        public int DeleteBySchGroupId(int id)
        {
            return _holiDaysSchGroupDb.DeleteBySchGroupId(id);
        }
    }
}