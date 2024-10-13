using System.Collections.Generic;
using DBLayer;
using Model;

namespace BLL
{
    public class HoliDaysGroupBll
    {
        private readonly HoliDaysGroupDb _holiDaysGroupDb = new HoliDaysGroupDb();

        public List<HoliDaysGroup> SelectAll()
        {
            return _holiDaysGroupDb.SelectAll();
        }

        public int Add(HoliDaysGroup holiDaysGroup)
        {
            return _holiDaysGroupDb.Insert(holiDaysGroup);
        }

        public object Delete(int id)
        {
            return _holiDaysGroupDb.Delete(id);
        }

        public int Update(HoliDaysGroup holiDaysGroup, int id)
        {
            return _holiDaysGroupDb.Update(holiDaysGroup, id);
        }
    }
}