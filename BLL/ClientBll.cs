using System;
using System.Collections.Generic;
using DBLayer;
using Model;

namespace BLL
{
    public class ClientBll
    {
        private readonly ClientDb _clientDb = new ClientDb();

        public List<Client> SelectClients()
        {
            try
            {
                return _clientDb.SelectClients();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int Insert(Client client)
        {
            try
            {
                return _clientDb.Insert(client);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int UpdateClient(Client client)
        {
            try
            {
                return _clientDb.UpdateClient(client);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int Delete(int rowIndex)
        {
            try
            {
                return _clientDb.Delete(rowIndex);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}