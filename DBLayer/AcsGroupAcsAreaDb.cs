using System;
using System.Collections.Generic;
using System.Linq;
using Model;

namespace DBLayer
{
    public class AcsGroupAcsAreaDb
    {
        private readonly EchoDBEntities _ecoDbEntities = new EchoDBEntities();

        public int Insert(AcsGroupAcsArea acsGroupAcsArea)
        {
            try
            {
                var result = _ecoDbEntities.AcsGroupAcsAreas.Add(acsGroupAcsArea);
                _ecoDbEntities.SaveChanges();
                return result.ID;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public List<AcsGroupAcsArea> SelectAcsAreaIdByAcsgroup(int acsGroupId)
        {
            try
            {
                return _ecoDbEntities.AcsGroupAcsAreas.Where(x => x.AcsGroupID == acsGroupId).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int Delete(AccessArea accessArea, AcsGroupAcsArea acsGroupAcsArea)
        {
            try
            {
                var acsGroupArea =
                    _ecoDbEntities.AcsGroupAcsAreas.FirstOrDefault(
                        x => x.AcsAreaID == accessArea.ID && x.AcsGroupID == acsGroupAcsArea.AcsGroupID);

                if (acsGroupArea != null)
                {
                    var result = _ecoDbEntities.AcsGroupAcsAreas.Remove(acsGroupArea);
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

        public int UpdateAndAdd(AccessArea accessArea, AcsGroupAcsArea acsGroupAcsArea)
        {
            try
            {
                var acsGroupArea =
                    _ecoDbEntities.AcsGroupAcsAreas.FirstOrDefault(
                        x => x.AcsAreaID == accessArea.ID && x.AcsGroupID == acsGroupAcsArea.AcsGroupID);

                var result = acsGroupArea;

                if (acsGroupArea != null)
                {
                    acsGroupArea.AcsAreaID = accessArea.ID;
                    acsGroupArea.AcsGroupID = acsGroupAcsArea.AcsGroupID;

                    _ecoDbEntities.Entry(acsGroupArea).CurrentValues.SetValues(acsGroupArea);
                }
                else
                {
                    var accessGroupArea = new AcsGroupAcsArea();
                    accessGroupArea.AcsAreaID = accessArea.ID;
                    accessGroupArea.AcsGroupID = acsGroupAcsArea.AcsGroupID;

                    result = _ecoDbEntities.AcsGroupAcsAreas.Add(accessGroupArea);
                }

                _ecoDbEntities.SaveChanges();
                return result.ID;
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
                var acsGroupArea =
                    _ecoDbEntities.AcsGroupAcsAreas.FirstOrDefault(
                        x => x.AcsGroupID == id);

                if (acsGroupArea != null)
                {
                    var result = _ecoDbEntities.AcsGroupAcsAreas.Remove(acsGroupArea);
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