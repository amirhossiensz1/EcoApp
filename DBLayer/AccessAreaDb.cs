using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Model;

namespace DBLayer
{
    public class AccessAreaDb
    {
        private readonly EchoDBEntities _ecoDbEntities = new EchoDBEntities();

        public List<AccessArea> SelectAll()
        {
            try
            {
                _ecoDbEntities.AccessAreas.Load();
                var acsareaList = _ecoDbEntities.AccessAreas.Local.ToList();
                return acsareaList;
            }
            catch (Exception exception)
            {
                throw;
            }
        }

        public int Insert(AccessArea acsArea)
        {
            try
            {
                var result = _ecoDbEntities.AccessAreas.Add(acsArea);
                _ecoDbEntities.SaveChanges();
                return result.ID;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int? Update(AccessArea acsArea)
        {
            try
            {
                var accessarea = _ecoDbEntities.AccessAreas.FirstOrDefault(x => x.ID == acsArea.ID);
                if (accessarea != null)
                {
                    accessarea.Name = acsArea.Name;

                    _ecoDbEntities.Entry(accessarea).State = EntityState.Modified;
                    _ecoDbEntities.SaveChanges();
                    return accessarea.ID;
                }
                return -1;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int Delete(int id)
        {
            var accessarea = _ecoDbEntities.AccessAreas.FirstOrDefault(x => x.ID == id);
            if (accessarea != null)
            {
                var result = _ecoDbEntities.AccessAreas.Remove(accessarea);
                _ecoDbEntities.SaveChanges();
                return result.ID;
            }
            return -1;
        }
    }
}