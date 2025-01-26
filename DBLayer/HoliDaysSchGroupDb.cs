using System;
using System.Collections.Generic;
using System.Linq;
using Model;

namespace DBLayer
{
    public class HoliDaysSchGroupDb
    {
        private readonly EchoDBEntities _ecoDbEntities = new EchoDBEntities();

        public int Insert(HoliDaysSchGroup holiDaysSchGroup)
        {
            var result = _ecoDbEntities.HoliDaysSchGroups.Add(holiDaysSchGroup);
            _ecoDbEntities.SaveChanges();
            return result.ID;
        }

        public int UpdateAndAdd(HoliDaysSchGroup holiDaysSchGroup)
        {
            try
            {
                var holidayscheduleGroup =
                    _ecoDbEntities.HoliDaysSchGroups.FirstOrDefault(x => x.SchGroupID == holiDaysSchGroup.SchGroupID);
                var result = holidayscheduleGroup;

                if (holidayscheduleGroup != null)
                {
                    holidayscheduleGroup.HoliDaysGroupID = holiDaysSchGroup.HoliDaysGroupID;
                    _ecoDbEntities.Entry(holidayscheduleGroup).CurrentValues.SetValues(holidayscheduleGroup);
                }
                else
                {
                    result = _ecoDbEntities.HoliDaysSchGroups.Add(holiDaysSchGroup);
                }
                _ecoDbEntities.SaveChanges();
                return result.ID;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<HoliDaysSchGroup> selectAllHolidaySchGroup(int HoliDaysGroupId)
        {
            return _ecoDbEntities.HoliDaysSchGroups.Where(x => x.HoliDaysGroupID == HoliDaysGroupId).ToList();
        }

        public int Delete(HoliDaysSchGroup holiDaysSchGroup)
        {
            try
            {
                var holidayscheduleGroup =
                    _ecoDbEntities.HoliDaysSchGroups.FirstOrDefault(x => x.SchGroupID == holiDaysSchGroup.SchGroupID);

                if (holidayscheduleGroup != null)
                {
                    var result = _ecoDbEntities.HoliDaysSchGroups.Remove(holidayscheduleGroup);
                    _ecoDbEntities.SaveChanges();
                    return result.ID;
                }
                return 0;
            }
            catch (Exception)
            {
                return -1;
                throw;
            }
        }

        public int SelectHolidayGroupId(int schGroupId)
        {
            try
            {
                var holiDaysSchGroup = _ecoDbEntities.HoliDaysSchGroups.FirstOrDefault(x => x.SchGroupID == schGroupId);
                if (holiDaysSchGroup != null)
                    if (holiDaysSchGroup.HoliDaysGroupID != null)
                        return (int) holiDaysSchGroup.HoliDaysGroupID;
                return 0;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int DeleteBySchGroupId(int id)
        {
            try
            {
                var holidayscheduleGroup = _ecoDbEntities.HoliDaysSchGroups.FirstOrDefault(x => x.SchGroupID == id);

                if (holidayscheduleGroup != null)
                {
                    var result = _ecoDbEntities.HoliDaysSchGroups.Remove(holidayscheduleGroup);
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
    }
}