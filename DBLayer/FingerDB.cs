using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Model;

namespace DBLayer
{
    public class FingerDB
    {
        public void InsertFinger(Finger finger)
        {
            try
            {
                var echoDbEntities = new EchoDBEntities();
                echoDbEntities.Fingers.Load();
                echoDbEntities.Fingers.Add(finger);
                echoDbEntities.SaveChanges();
            }
            catch (Exception exception1)
            {
                throw exception1;
            }
        }

        public void Deletefingers(object id)
        {
            try
            {
                var echoDbEntities = new EchoDBEntities();
                echoDbEntities.Fingers.Load();
                var fingerlist = echoDbEntities.Fingers.Where(x => x.EmpID == (int) id);
                echoDbEntities.Fingers.RemoveRange(fingerlist);
                echoDbEntities.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void DeleteOneFingerEmployee(int id, int fingerNum)
        {
            try
            {
                var echoDbEntities = new EchoDBEntities();
                echoDbEntities.Database.ExecuteSqlCommand("Delete From Finger Where EmpID= " + id + " AND FingerNum =" +
                                                          fingerNum);
                echoDbEntities.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Finger> SelectFingersEmployee(int id)
        {
            try
            {
                var echoDbEntities = new EchoDBEntities();
                echoDbEntities.Fingers.Load();
                var fingerList = echoDbEntities.Fingers.Where(x => x.EmpID == id).ToList();
                echoDbEntities.SaveChanges();
                return fingerList;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool SelectOneFinger(int id)
        {
            try
            {
                var echoDbEntities = new EchoDBEntities();
                echoDbEntities.Fingers.Load();
                var finger = echoDbEntities.Fingers.FirstOrDefault(x => x.EmpID == id);
                echoDbEntities.SaveChanges();

                if (finger != null)
                    return true;
                return false;
            }
            catch (Exception)
            {
                throw;
            }
        }


        public Finger SelectOneFinger(int id, int fingerNum)
        {
            try
            {
                var echoDbEntities = new EchoDBEntities();
                echoDbEntities.Fingers.Load();
                var finger = echoDbEntities.Fingers.FirstOrDefault(x => x.EmpID == id && x.FingerNum == fingerNum);
                echoDbEntities.SaveChanges();

                if (finger != null)
                    return finger;
                return null;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool SelectFingerMd5(int employeeId, string md5)
        {
            try
            {
                var echoDbEntities = new EchoDBEntities();
                echoDbEntities.Fingers.Load();
                var finger = echoDbEntities.Fingers.FirstOrDefault(x => x.EmpID == employeeId && x.Md5 == md5);

                echoDbEntities.SaveChanges();

                if (finger != null)
                    return true;
                return false;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Update(Finger fngr)
        {
            try
            {
                var echoDbEntities = new EchoDBEntities();
                echoDbEntities.Fingers.Load();
                var finger = echoDbEntities.Fingers.FirstOrDefault(x => x.EmpID == fngr.EmpID);

                if (finger != null)
                {
                    fngr.ID = finger.ID;
                    echoDbEntities.Entry(finger).CurrentValues.SetValues(fngr);
                    echoDbEntities.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}