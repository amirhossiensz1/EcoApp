using System.Collections.Generic;
using DBLayer;
using Model;

namespace BLL
{
    public class DeviceSchGroupBll
    {
        private readonly DeviceSchGroupDb _deviceSchGroupDb = new DeviceSchGroupDb();

        public int Insert(DeviceSchGroup deviceSchGroup)
        {
            return _deviceSchGroupDb.Insert(deviceSchGroup);
        }

        public object SelectSchIdById(int acsAreaId)
        {
            return _deviceSchGroupDb.SelectSchIdById(acsAreaId);
        }

        public List<DeviceSchGroup> SelectDeviceIdByAcsAreaId(int acsAreaId)
        {
            return _deviceSchGroupDb.SelectDeviceIdByAcsAreaId(acsAreaId);
        }

        public int UpdateAndAdd(Device device, DeviceSchGroup deviceSchGroup)
        {
            return _deviceSchGroupDb.UpdateAndAdd(device, deviceSchGroup);
        }

        public int Delete(Device device, DeviceSchGroup deviceSchGroup)
        {
            return _deviceSchGroupDb.Delete(device, deviceSchGroup);
        }

        public int Delete(int id)
        {
            return _deviceSchGroupDb.Delete(id);
        }

        public object UpdateToNull(int id)
        {
            return _deviceSchGroupDb.UpdateToNull(id);
        }
    }
}