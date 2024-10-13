using System.Collections.Generic;
using DBLayer;
using Model;

namespace BLL
{
    public class AccessAreaBll
    {
        private readonly AccessAreaDb _acsAccessAreaDb = new AccessAreaDb();

        public List<AccessArea> SelectAll()
        {
            return _acsAccessAreaDb.SelectAll();
        }

        public int Insert(AccessArea acsArea)
        {
            return _acsAccessAreaDb.Insert(acsArea);
        }

        public int? Update(AccessArea acsArea)
        {
            return _acsAccessAreaDb.Update(acsArea);
        }

        public int Delete(int id)
        {
            return _acsAccessAreaDb.Delete(id);
        }
    }
}