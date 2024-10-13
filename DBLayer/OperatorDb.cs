using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Model;

namespace DBLayer
{
    public class OperatorDb
    {
        private readonly EchoDBEntities _echoDbEntities = new EchoDBEntities();

        public int Insert(Operator opert)
        {
            try
            {
                var result = _echoDbEntities.Operators.Add(opert);
                _echoDbEntities.SaveChanges();
                return result.ID;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Operator> Select()
        {
            try
            {
                _echoDbEntities.Operators.Load();
                var operatorList = _echoDbEntities.Operators.Local.ToList();
                return operatorList;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool ExistUserName(string username)
        {
            try
            {
                var opert = _echoDbEntities.Operators.FirstOrDefault(x => x.UserName == username);
                _echoDbEntities.SaveChanges();
                return opert != null;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool ExistPass(string pass)
        {
            try
            {
                var opert = _echoDbEntities.Operators.FirstOrDefault(x => x.Password == pass);

                _echoDbEntities.SaveChanges();
                return opert != null;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Operator SelectOneOpert(string username)
        {
            try
            {
                var opert = _echoDbEntities.Operators.FirstOrDefault(x => x.UserName == username);

                _echoDbEntities.SaveChanges();
                return opert;
            }
            catch (Exception)
            {
                throw;
            }
        }


        public List<Operator> SelectAllOperator()
        {
            try
            {
                _echoDbEntities.Operators.Load();

                return _echoDbEntities.Operators.Local.ToList();
            }
            catch (Exception exception)
            {
                throw;
            }
        }

        public Operator SelectOneOpert(object id)
        {
            try
            {
                var opert = _echoDbEntities.Operators.FirstOrDefault(x => x.ID == (int) id);
                _echoDbEntities.SaveChanges();
                return opert;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int UpdateOneOperator(Operator opert)
        {
            try
            {
                var operat = _echoDbEntities.Operators.FirstOrDefault(x => x.ID == opert.ID);

                if (operat != null)
                {
                    _echoDbEntities.Entry(operat).CurrentValues.SetValues(opert);
                    _echoDbEntities.SaveChanges();
                    return operat.ID;
                }
                return -1;
            }
            catch (Exception exception)
            {
                return -1;
            }
        }

        public int Delete(int rowindex)
        {
            try
            {
                var opert = _echoDbEntities.Operators.FirstOrDefault(x => x.ID == rowindex);

                if (opert != null)
                {
                    var result = _echoDbEntities.Operators.Remove(opert);
                    _echoDbEntities.SaveChanges();
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