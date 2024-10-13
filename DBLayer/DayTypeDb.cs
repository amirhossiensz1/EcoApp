using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Model;

namespace DBLayer
{
    public class DayTypeDb
    {
        public int InsertDayType(DayType dayType)
        {
            try
            {
                var echoDbEntities = new EchoDBEntities();
                var result = echoDbEntities.DayTypes.Add(dayType);
                echoDbEntities.SaveChanges();
                return result.ID;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<DayType> SelectAll()
        {
            try
            {
                var echoDbEntities = new EchoDBEntities();
                echoDbEntities.DayTypes.Load();
                return echoDbEntities.DayTypes.Local.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int UpdateDayType(DayType dayType)
        {
            try
            {
                var echoDbEntities = new EchoDBEntities();
                var daytype = echoDbEntities.DayTypes.FirstOrDefault(x => x.ID == dayType.ID);

                if (daytype != null)
                {
                    echoDbEntities.Entry(daytype).CurrentValues.SetValues(dayType);
                    echoDbEntities.SaveChanges();
                    return daytype.ID;
                }
                return -1;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}