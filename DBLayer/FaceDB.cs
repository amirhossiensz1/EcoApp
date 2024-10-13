using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace DBLayer
{
    public class FaceDB
    {
        EchoDBEntities _echoDbEntities;
        public FaceDB()
        {
            _echoDbEntities = new EchoDBEntities();
            //_echoDbEntities.Faces.Load();
        }

        //public Boolean Insert(Model.Face)
        //{

        //}


        public bool InsertFace(Face face)
        {
            try
            {
               
                _echoDbEntities.Faces.Add(face);
                if (_echoDbEntities.SaveChanges() > 0)
                    return true;
                return false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public bool UpdateFace(Face face)
        {
            try
            {
                var fce = _echoDbEntities.Faces.FirstOrDefault(x => x.EmpId == face.EmpId);

                if (fce != null)
                {
                    face.ID = fce.ID;
                    _echoDbEntities.Entry(fce).CurrentValues.SetValues(face);
                    
                }
                if (_echoDbEntities.SaveChanges() >= 0)
                {
                    return true;
                }
                else return false;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public string GetFaceStr(Employee employee)
        {
            try
            {
                if (_echoDbEntities != null) return _echoDbEntities.Faces.FirstOrDefault(x => x.EmpId == employee.ID).FaceData;
                return "";
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public bool ExistEmployeeFace(int id)
        {
            try
            {
                var face = _echoDbEntities.Faces.FirstOrDefault(x => x.EmpId == id);
                _echoDbEntities.SaveChanges();


                if (face != null)
                    return true;
                return false;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public byte[] GetImage(int employeeId)
        {
            try
            {
                if (_echoDbEntities != null) return _echoDbEntities.Faces.FirstOrDefault(x => x.EmpId == employeeId)?.image;
                return null;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }
    }
}


