using System.Collections.Generic;
using DBLayer;
using Model;

namespace BLL
{
    public class AcsGroupAcsAreaBll
    {
        private readonly AcsGroupAcsAreaDb _acsGroupAcsAreaDb = new AcsGroupAcsAreaDb();


        public int Insert(AcsGroupAcsArea acsGroupAcsArea)
        {
            return _acsGroupAcsAreaDb.Insert(acsGroupAcsArea);
        }

        public List<AcsGroupAcsArea> SelectAcsAreaIdByAcsgroup(int acsGroupId)
        {
            return _acsGroupAcsAreaDb.SelectAcsAreaIdByAcsgroup(acsGroupId);
        }


        public int UpdateAndAdd(AccessArea accessArea, AcsGroupAcsArea acsGroupAcsArea)
        {
            return _acsGroupAcsAreaDb.UpdateAndAdd(accessArea, acsGroupAcsArea);
        }

        public int Delete(AccessArea accessArea, AcsGroupAcsArea acsGroupAcsArea)
        {
            return _acsGroupAcsAreaDb.Delete(accessArea, acsGroupAcsArea);
        }

        public int Delete(int id)
        {
            return _acsGroupAcsAreaDb.Delete(id);
        }
    }
}