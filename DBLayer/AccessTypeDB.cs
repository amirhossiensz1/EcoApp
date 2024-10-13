using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Model;

namespace DBLayer
{
    public class AccessTypeDb
    {
        private readonly EchoDBEntities _echoDbEntities = new EchoDBEntities();

        public List<AccessType> SelectAccessType()
        {
            try
            {
                _echoDbEntities.AccessTypes.Load();
                var accessTypeList = _echoDbEntities.AccessTypes.Local.ToList();
                return accessTypeList;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}