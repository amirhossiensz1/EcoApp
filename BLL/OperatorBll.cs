using System;
using System.Collections.Generic;
using DBLayer;
using Model;

namespace BLL
{
    public class OperatorBll
    {
        private readonly OperatorDb _operatorDb = new OperatorDb();

        public int Insert(Operator opert)
        {
            try
            {
                return _operatorDb.Insert(opert);
            }
            catch (Exception)
            {
                return -1;
                throw;
            }
        }

        public bool CheckValidate(string username, string password)
        {
            try
            {
                var opert = _operatorDb.SelectOneOpert(username);
                if (opert == null)
                    return false;
                return username == opert.UserName && password == opert.Password;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool CheckUserExist(string username)
        {
            if (_operatorDb.ExistUserName(username))
                return true;
            return false;
        }

        public List<Operator> SelectAllOperator()
        {
            try
            {
                return _operatorDb.SelectAllOperator();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Operator SelectOneOperator(object id)
        {
            try
            {
                return _operatorDb.SelectOneOpert(id);
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
                return _operatorDb.UpdateOneOperator(opert);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool CheckPassExist(string pass)
        {
            try
            {
                if (_operatorDb.ExistPass(pass))
                    return true;
                return false;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int Delete(int rowindex)
        {
            try
            {
                return _operatorDb.Delete(rowindex);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}