using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Model;

namespace DBLayer
{
    public class ScheduleGroupDb
    {
        private readonly EchoDBEntities _ecoDbEntities = new EchoDBEntities();

        public int Insert(ScheduleGroup schGroup)
        {
            try
            {
                var result = _ecoDbEntities.ScheduleGroups.Add(schGroup);
                _ecoDbEntities.SaveChanges();
                return result.ID;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<ScheduleGroup> SelectAll()
        {
            try
            {
                _ecoDbEntities.ScheduleGroups.Load();
                return _ecoDbEntities.ScheduleGroups.Local.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<ScheduleGroupViewModel> SelectAllForView()
        {
            try
            {
                _ecoDbEntities.ScheduleGroups.Load();
                return  _ecoDbEntities.ScheduleGroups.Local.ToList()
                    .Select(x => new ScheduleGroupViewModel()
                    {
                        ID =x.ID,
                        Name = x.Name,
                        NameId = x.Name + " ("+ x.ID +")"
                    }).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int Update(ScheduleGroup schGroup)
        {
            try
            {
                var scheduleGroup = _ecoDbEntities.ScheduleGroups.FirstOrDefault(x => x.ID == schGroup.ID);

                if (scheduleGroup != null)
                {
                    scheduleGroup.Name = schGroup.Name;
                    scheduleGroup.year = schGroup.year;

                    _ecoDbEntities.Entry(scheduleGroup).State = EntityState.Modified;
                    _ecoDbEntities.SaveChanges();
                    return scheduleGroup.ID;
                }
                return -1;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public int Delete(int id)
        {
            try
            {
                var scheduleGroup = _ecoDbEntities.ScheduleGroups.FirstOrDefault(x => x.ID == id);

                if (scheduleGroup != null)
                {
                    var result = _ecoDbEntities.ScheduleGroups.Remove(scheduleGroup);
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

        public string SelectYear(int id)
        {
            try
            {
                var schGroup = _ecoDbEntities.ScheduleGroups.FirstOrDefault(x => x.ID == id);

                return schGroup != null ? schGroup.year : "";
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}