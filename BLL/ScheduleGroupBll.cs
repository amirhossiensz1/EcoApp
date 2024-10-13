using System.Collections.Generic;
using DBLayer;
using Model;

namespace BLL
{
    public class ScheduleGroupBll
    {
        private readonly ScheduleGroupDb _schGroupDb = new ScheduleGroupDb();

        public int Insert(ScheduleGroup schGroup)
        {
            return _schGroupDb.Insert(schGroup);
        }

        public List<ScheduleGroup> SelectAll()
        {
            return _schGroupDb.SelectAll();
        }

        public List<ScheduleGroupViewModel> SelectAllForView()
        {
            return _schGroupDb.SelectAllForView();
        }

        public int Update(ScheduleGroup schGroup)
        {
            return _schGroupDb.Update(schGroup);
        }

        public int Delete(int id)
        {
            return _schGroupDb.Delete(id);
        }

        public string SelectYear(int id)
        {
            return _schGroupDb.SelectYear(id);
        }
    }
}