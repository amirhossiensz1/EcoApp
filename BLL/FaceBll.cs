using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBLayer;
using Model;

namespace BLL
{
    public class FaceBll
    {
        public FaceBll()
        {
        }

        public Boolean InsertFace(Face face)
        {
            return new FaceDB().InsertFace(face);
        }

        public byte[] GetImage(int employeeId)
        {
            return new FaceDB().GetImage(employeeId);
        }

        public static bool ExistEmployeeFace(int id)
        {
            try {
                return new FaceDB().ExistEmployeeFace(id);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public bool UpdateFace(Face face)
        {
            try
            {
                return new FaceDB().UpdateFace(face);
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
                return new FaceDB().GetFaceStr(employee);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
