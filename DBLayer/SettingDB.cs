using System;
using System.Data.Entity;
using System.Linq;
using Model;

namespace DBLayer
{
    public class SettingDB
    {
        public void Insert(Setting setting)
        {
            try
            {
                var echoDbEntities = new EchoDBEntities();
                echoDbEntities.Settings.Load();
                echoDbEntities.Settings.Add(setting);
                echoDbEntities.SaveChanges();
            }
            catch (Exception exception1)
            {
                Console.WriteLine(exception1);
            }
        }

        public Setting SelectOne(int id)
        {
            try
            {
                var setting = new Setting();
                var echoDbEntities = new EchoDBEntities();
                setting = echoDbEntities.Settings.FirstOrDefault(x => x.DeviceID == id);
                echoDbEntities.SaveChanges();
                return setting;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                return null;
            }
        }


        public void UpdateSetting(Setting setting)
        {
            try
            {
                var sttg = new Setting();
                var echoDbEntities = new EchoDBEntities();
                sttg = echoDbEntities.Settings.FirstOrDefault(x => x.DeviceID == setting.DeviceID);

                if (sttg != null)
                {
                    setting.ID = sttg.ID;
                    echoDbEntities.Entry(sttg).CurrentValues.SetValues(setting);
                    //echoDbEntities.Entry(sttg).State = EntityState.Modified; 
                    echoDbEntities.SaveChanges();
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
        }

        public void DeleteOneSetting(object deviceId)
        {
            try
            {
                var echoDbEntities = new EchoDBEntities();
                var setting = new Setting();
                setting = echoDbEntities.Settings.FirstOrDefault(x => x.DeviceID == (int) deviceId);

                if (setting != null)
                {
                    echoDbEntities.Settings.Remove(setting);
                }
                echoDbEntities.SaveChanges();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
        }
    }
}