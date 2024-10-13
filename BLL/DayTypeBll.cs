using System.Collections.Generic;
using DBLayer;
using Model;

namespace BLL
{
    public class DayTypeBll
    {
        private readonly DayTypeDb _dayTypeDb = new DayTypeDb();

        public int InsertDayType(DayType dayType)
        {
            return _dayTypeDb.InsertDayType(dayType);
        }

        public List<DayType> SelectAll()
        {
            return _dayTypeDb.SelectAll();
        }

        public object UpdateDayType(DayType dayType)
        {
            return _dayTypeDb.UpdateDayType(dayType);
        }
    }
}