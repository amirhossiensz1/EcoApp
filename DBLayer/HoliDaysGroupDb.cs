using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Model;

namespace DBLayer
{
    public class HoliDaysGroupDb
    {
        private readonly EchoDBEntities _echoDbEntities = new EchoDBEntities();

        public List<HoliDaysGroup> SelectAll()
        {
            _echoDbEntities.HoliDaysGroups.Load();
            var holidayGroupList = _echoDbEntities.HoliDaysGroups.Local.ToList();
            return holidayGroupList;
        }

        public int Insert(HoliDaysGroup holiDaysGroup)
        {
            var result = _echoDbEntities.HoliDaysGroups.Add(holiDaysGroup);
            _echoDbEntities.SaveChanges();

            return result.ID;
        }

        public object Delete(int id)
        {
            var holidaysGroup = _echoDbEntities.HoliDaysGroups.FirstOrDefault(x => x.ID == id);

            if (holidaysGroup != null)
            {
                var result = _echoDbEntities.HoliDaysGroups.Remove(holidaysGroup);
                _echoDbEntities.SaveChanges();
                return result.ID;
            }
            return -1;
        }

        public int Update(HoliDaysGroup holiDaysGroup, int id)
        {
            var holidayGroup = _echoDbEntities.HoliDaysGroups.FirstOrDefault(x => x.ID == id);
            if (holidayGroup != null)
            {
                holidayGroup.Name = holiDaysGroup.Name;

                _echoDbEntities.Entry(holidayGroup).State = EntityState.Modified;
                return _echoDbEntities.SaveChanges();
            }
            return -1;
        }
    }
}