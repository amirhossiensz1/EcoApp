using System.Collections.Generic;
using DBLayer;
using Model;

namespace BLL
{
    public class AccessGroupBll
    {
        private readonly AccessGroupDb _accessGroupDb = new AccessGroupDb();


        public int? Insert(AccessGroup accessGroup)
        {
            return _accessGroupDb.Insert(accessGroup);
        }

        public List<AccessGroup> SelectAll()
        {
            return _accessGroupDb.SelectAll();
        }

        public List<AccessGroupViewModel> SelectAllForViewModel()
        {
            return _accessGroupDb.SelectAllViewModel();
        }

        public int SelectSchIdById(int acsGRoupId)
        {
            return _accessGroupDb.SelectSchIdById(acsGRoupId);
        }

        public int Update(AccessGroup accessGroup)
        {
            return _accessGroupDb.Update(accessGroup);
        }

        public object UpdateSchGroup(int id)
        {
            return _accessGroupDb.UpdateSchGroup(id);
        }

        public int Delete(int id)
        {
            return _accessGroupDb.Delete(id);
        }

        public AccessGroup Select(int id)
        {
            return _accessGroupDb.Select(id);
        }
    }
}