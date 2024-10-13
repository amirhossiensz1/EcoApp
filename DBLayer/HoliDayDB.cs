using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Model;

namespace DBLayer
{
    public class HoliDayDb
    {
        private readonly EchoDBEntities _ecoDbEntities = new EchoDBEntities();

        public List<HoliDay> SelectAll()
        {
            _ecoDbEntities.HoliDays.Load();
            var holiDayList = _ecoDbEntities.HoliDays.Local.ToList();
            return holiDayList;
        }

        public int Insert(HoliDay holiDay)
        {
            var result = _ecoDbEntities.HoliDays.Add(holiDay);
            _ecoDbEntities.SaveChanges();

            return result.ID;
        }

        public int Delete(int id)
        {
            var holiday = _ecoDbEntities.HoliDays.FirstOrDefault(x => x.ID == id);

            if (holiday != null)
            {
                var result = _ecoDbEntities.HoliDays.Remove(holiday);
                _ecoDbEntities.SaveChanges();
                return result.ID;
            }
            return -1;
        }

        public int UpdateGroupId(List<int> holidaysList, int? holidaysGroupId)
        {
            var holidays = _ecoDbEntities.HoliDays.Where(x => holidaysList.Contains(x.ID)).ToList();
            holidays.ForEach(x => x.HolidaysGrpID = holidaysGroupId);
            return _ecoDbEntities.SaveChanges();
        }

        public int UpdateGroupIdToNull(List<int> holidaysList, int? holidaysGroupId)
        {
            var holidays =
                _ecoDbEntities.HoliDays.Where(x => holidaysList.Contains(x.ID) && x.HolidaysGrpID == holidaysGroupId)
                    .ToList();
            holidays.ForEach(x => x.HolidaysGrpID = null);
            return _ecoDbEntities.SaveChanges();
        }

        public List<HoliDay> SelectHolidayByHolidayGroupId(int groupId)
        {
            var holidayList = _ecoDbEntities.HoliDays.Where(x => x.HolidaysGrpID == groupId);
            return holidayList.ToList();
        }

        public string ExistDate(string date)
        {
            var holiday = _ecoDbEntities.HoliDays.FirstOrDefault(x => x.Date == date);
            if (holiday == null)
                return "";
            return holiday.Date;
        }
    }
}