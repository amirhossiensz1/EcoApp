using System.Collections.Generic;
using DBLayer;
using Model;

namespace BLL
{
    public class OrganizationBll
    {
        private readonly OrganizationDb _organizationDb = new OrganizationDb();

        public List<Organization> SelectAll()
        {
            return _organizationDb.SelectAll();
        }

        public int Insert(Organization organization)
        {
            return _organizationDb.Insert(organization);
        }

        public int Update(Organization org)
        {
            return _organizationDb.Update(org);
        }

        public int Delete(int p)
        {
            return _organizationDb.Delete(p);
        }

        public int UpdateAcsGroup(List<int> organizationIds, int? acsGroupId)
        {
            return _organizationDb.UpdateAcsGroupId(organizationIds, acsGroupId);
        }

        public int UpdateAcsGroup(int organizationId, int? acsGroupId)
        {
            return _organizationDb.UpdateAcsGroupId(organizationId, acsGroupId);
        }

        public List<Organization> SelectOrganizationbyacsGroupId(int acsGRoupId)
        {
            return _organizationDb.SelectOrganizationbyacsGroupId(acsGRoupId);
        }

        public object UpdateAcsGroup(int acsGroupId)
        {
            return _organizationDb.UpdateAcsGroupId(acsGroupId);
        }

        public Organization Select(int organizationId)
        {
            return _organizationDb.Select(organizationId);
        }
    }
}