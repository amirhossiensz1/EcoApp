using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Model;

namespace DBLayer
{
    public class OrganizationDb
    {
        private readonly EchoDBEntities _ecoDbEntities = new EchoDBEntities();


        public List<Organization> SelectAll()
        {
            try
            {
                _ecoDbEntities.Organizations.Load();
                var organization = _ecoDbEntities.Organizations.Local.ToList();
                return organization;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int Insert(Organization organization)
        {
            try
            {
                var result = _ecoDbEntities.Organizations.Add(organization);
                _ecoDbEntities.SaveChanges();
                return result.ID;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int Update(Organization org)
        {
            try
            {
                var organization = _ecoDbEntities.Organizations.FirstOrDefault(x => x.ID == org.ID);
                if (organization != null)
                {
                    organization.name = org.name;
                    organization.OrganizationID = org.OrganizationID;
                    _ecoDbEntities.Entry(organization).State = EntityState.Modified;
                    _ecoDbEntities.SaveChanges();
                    return organization.ID;
                }
                return -1;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int UpdateAcsGroupId(List<int> organizationIds, int? ascGroupId)
        {
            try
            {
                var holidays = _ecoDbEntities.Organizations.Where(x => organizationIds.Contains(x.ID)).ToList();
                holidays.ForEach(x => x.AcsGroupID = ascGroupId);
                return _ecoDbEntities.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int UpdateAcsGroupId(int organizationId, int? ascGroupId)
        {
            try
            {
                var organization = _ecoDbEntities.Organizations.FirstOrDefault(x => x.ID == organizationId);

                if (organization != null)
                {
                    organization.AcsGroupID = ascGroupId;
                    _ecoDbEntities.Entry(organization).State = EntityState.Modified;
                    _ecoDbEntities.SaveChanges();
                    return organization.ID;
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
                var organization = _ecoDbEntities.Organizations.FirstOrDefault(x => x.ID == id);

                if (organization != null)
                {
                    var result = _ecoDbEntities.Organizations.Remove(organization);
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

        public List<Organization> SelectOrganizationbyacsGroupId(int acsGRoupId)
        {
            try
            {
                var organizationList = _ecoDbEntities.Organizations.Where(x => x.AcsGroupID == acsGRoupId);

                return organizationList.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int UpdateAcsGroupId(int acsGroupId)
        {
            try
            {
                var organizationlist = _ecoDbEntities.Organizations.Where(x => x.AcsGroupID == acsGroupId).ToList();
                foreach (var organization in organizationlist.Where(organization => organization != null))
                {
                    organization.AcsGroupID = null;
                    _ecoDbEntities.Entry(organization).State = EntityState.Modified;
                }
                return _ecoDbEntities.SaveChanges();
            }
            catch (Exception)
            {
                return -1;
                throw;
            }
        }

        public Organization Select(int organizationId)
        {
            try
            {
                var organization = _ecoDbEntities.Organizations.FirstOrDefault(x => x.ID == organizationId);

                return organization;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}