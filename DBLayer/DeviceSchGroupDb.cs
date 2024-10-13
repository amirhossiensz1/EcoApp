using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Model;

namespace DBLayer
{
    public class DeviceSchGroupDb
    {
        private readonly EchoDBEntities _ecoDbEntities = new EchoDBEntities();


        public int Insert(DeviceSchGroup deviceSchGroup)
        {
            try
            {
                var result = _ecoDbEntities.DeviceSchGroups.Add(deviceSchGroup);
                _ecoDbEntities.SaveChanges();
                return result.ID;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int SelectSchIdById(int acsAreaId)
        {
            try
            {
                var result = _ecoDbEntities.DeviceSchGroups.FirstOrDefault(x => x.AcsAreaID == acsAreaId);
                if (result != null) if (result.SchgroupID != null) return (int) result.SchgroupID;
                return 0;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<DeviceSchGroup> SelectDeviceIdByAcsAreaId(int acsAreaId)
        {
            try
            {
                return _ecoDbEntities.DeviceSchGroups.Where(x => x.AcsAreaID == acsAreaId).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int UpdateAndAdd(Device device, DeviceSchGroup deviceSch)
        {
            try
            {
                var deviceSchgroup =
                    _ecoDbEntities.DeviceSchGroups.FirstOrDefault(
                        x => x.AcsAreaID == deviceSch.AcsAreaID && x.DeviceID == device.ID);
                var result = deviceSchgroup;
                if (deviceSchgroup != null)
                {
                    deviceSchgroup.AcsAreaID = deviceSch.AcsAreaID;
                    deviceSchgroup.DeviceID = device.ID;
                    deviceSchgroup.SchgroupID = deviceSch.SchgroupID;

                    _ecoDbEntities.Entry(deviceSchgroup).CurrentValues.SetValues(deviceSchgroup);
                }
                else
                {
                    var dvcSchGroup = new DeviceSchGroup();
                    dvcSchGroup.AcsAreaID = deviceSch.AcsAreaID;
                    dvcSchGroup.DeviceID = device.ID;
                    dvcSchGroup.SchgroupID = deviceSch.SchgroupID;
                    result = _ecoDbEntities.DeviceSchGroups.Add(dvcSchGroup);
                }
                _ecoDbEntities.SaveChanges();
                return result.ID;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int Delete(Device device, DeviceSchGroup deviceSch)
        {
            try
            {
                var deviceSchGroup = _ecoDbEntities.DeviceSchGroups.FirstOrDefault(
                    x => x.DeviceID == device.ID && x.AcsAreaID == deviceSch.AcsAreaID);
                if (deviceSchGroup != null)
                {
                    var result = _ecoDbEntities.DeviceSchGroups.Remove(deviceSchGroup);
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

        public int UpdateToNull(int id)
        {
            try
            {
                var dvcSchGroup = _ecoDbEntities.DeviceSchGroups.FirstOrDefault(x => x.ID == id);

                if (dvcSchGroup != null)
                {
                    dvcSchGroup.AcsAreaID = null;
                    _ecoDbEntities.Entry(dvcSchGroup).State = EntityState.Modified;
                    _ecoDbEntities.SaveChanges();
                    return dvcSchGroup.ID;
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
                var dvcSchGroup = _ecoDbEntities.DeviceSchGroups.FirstOrDefault(x => x.ID == id);

                if (dvcSchGroup != null)
                {
                    var result = _ecoDbEntities.DeviceSchGroups.Remove(dvcSchGroup);
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
    }
}