using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Model;

namespace DBLayer
{
    public class DeviceDB
    {
        public List<Device> SelectDevice()
        {
            try
            {
                var DeviceList = new List<Device>();
                var echoDbEntities = new EchoDBEntities();
                echoDbEntities.Devices.Load();
                DeviceList = echoDbEntities.Devices.Local.ToList();
                echoDbEntities.SaveChanges();
                return DeviceList;
            }
            catch (Exception e1)
            {
                Console.WriteLine(e1);
                return null;
            }
        }

        public void AddDevice(Device device)
        {
            try
            {
                var echoDbEntities = new EchoDBEntities();
                echoDbEntities.Devices.Load();
                echoDbEntities.Devices.Add(device);
                echoDbEntities.SaveChanges();
            }
            catch (Exception exception1)
            {
                Console.WriteLine(exception1);
            }
        }

        public void DeleteOneDevice(object id)
        {
            try
            {
                var echoDbEntities = new EchoDBEntities();
                var device = new Device();
                device = echoDbEntities.Devices.FirstOrDefault(x => x.ID == (int) id);
                echoDbEntities.Devices.Remove(device);
                echoDbEntities.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Device SelectOneDevice(int id)
        {
            var echoDbEntities = new EchoDBEntities();
            var device = new Device();
            device = echoDbEntities.Devices.FirstOrDefault(x => x.ID == id);
            echoDbEntities.SaveChanges();
            return device;
        }

        public Device SelectOneDevice(string ip)
        {
            var echoDbEntities = new EchoDBEntities();
            var device = new Device();
            device = echoDbEntities.Devices.FirstOrDefault(x => x.IP == ip);
            echoDbEntities.SaveChanges();
            return device;
        }


        public void UpdateDevice(Device device)
        {
            try
            {
                var dvc = new Device();
                var echoDbEntities = new EchoDBEntities();
                dvc = echoDbEntities.Devices.FirstOrDefault(x => x.ID == device.ID);

                if (dvc != null)
                {
                    echoDbEntities.Entry(dvc).CurrentValues.SetValues(device);
                    echoDbEntities.SaveChanges();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public bool ExistSerial(string serial)
        {
            try
            {
                var echoDbEntities = new EchoDBEntities();
                var dvc = echoDbEntities.Devices.FirstOrDefault(x => x.DeviceSerial == serial);
                echoDbEntities.SaveChanges();
                if (dvc != null)
                    return true;
                return false;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DateTime GetTimeFromServer()
        {
            try
            {
                var echoDbEntities = new EchoDBEntities();
                var dateQuery = echoDbEntities.Database.SqlQuery<DateTime>("SELECT getdate()");
                var serverDate = dateQuery.AsEnumerable().First();
                return serverDate;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<DeviceType> SelectDeviceType()
        {
            try
            {
                var echoDbEntities = new EchoDBEntities();
                echoDbEntities.DeviceTypes.Load();
                return echoDbEntities.DeviceTypes.Local.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}