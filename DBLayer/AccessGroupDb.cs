using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Model;

namespace DBLayer
{
    public class AccessGroupDb
    {
        private readonly EchoDBEntities _ecoDbEntities = new EchoDBEntities();


        public int? Insert(AccessGroup accessGroup)
        {
            try
            {
                var result = _ecoDbEntities.AccessGroups.Add(accessGroup);
                _ecoDbEntities.SaveChanges();
                return result.ID;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<AccessGroup> SelectAll()
        {
            try
            {
                _ecoDbEntities.AccessGroups.Load();
                var accessgroupList = _ecoDbEntities.AccessGroups.Local.ToList();
                return accessgroupList;
            }
            catch (Exception exception)
            {
                throw;
            }
        }

        public List<AccessGroupViewModel> SelectAllViewModel()
        {
            try
            {
                _ecoDbEntities.AccessGroups.Load();
                var accessgroupList = _ecoDbEntities.AccessGroups.Local.ToList()
                    .Select(x => new AccessGroupViewModel()
                    {
                        ID = x.ID,
                        Name = x.Name,
                        NameID = x.Name + " (" + x.ID + ")"
                    }).ToList();
                return accessgroupList;
            }
            catch (Exception exception)
            {
                return null;
            }
        }

        public int SelectSchIdById(int acsGRoupId)
        {
            try
            {
                var result = _ecoDbEntities.AccessGroups.FirstOrDefault(x => x.ID == acsGRoupId);
                //    if (result != null) if (result.SchGroupID != null) return (int) result.SchGroupID;
                return 0;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int Update(AccessGroup acsGroup)
        {
            try
            {
                var accessgroup = _ecoDbEntities.AccessGroups.FirstOrDefault(x => x.ID == acsGroup.ID);

                if (accessgroup != null)
                {
                    accessgroup.Name = acsGroup.Name;

                    _ecoDbEntities.Entry(accessgroup).State = EntityState.Modified;
                    _ecoDbEntities.SaveChanges();
                    return accessgroup.ID;
                }
                return -1;
            }
            catch (Exception)
            {
                throw;
            }
        }


        public object UpdateSchGroup(int id)
        {
            try
            {
                var accessgroup = _ecoDbEntities.AccessGroups.FirstOrDefault(x => x.ID == id);

                if (accessgroup != null)
                {
                    //          accessgroup.SchGroupID = null;

                    _ecoDbEntities.Entry(accessgroup).State = EntityState.Modified;
                    _ecoDbEntities.SaveChanges();
                    return accessgroup.ID;
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
            try
            {
                var accessgroup = _ecoDbEntities.AccessGroups.FirstOrDefault(x => x.ID == id);
                if (accessgroup != null)
                {
                    var result = _ecoDbEntities.AccessGroups.Remove(accessgroup);
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

        public AccessGroup Select(int id)
        {
            try
            {
                var accessgroup = _ecoDbEntities.AccessGroups.FirstOrDefault(x => x.ID == id);
                return accessgroup;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}