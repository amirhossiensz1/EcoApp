using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Model;

namespace DBLayer
{
    public class ClientDb
    {
        private readonly EchoDBEntities _ecoDbEntities = new EchoDBEntities();

        public List<Client> SelectClients()
        {
            try
            {
                _ecoDbEntities.Clients.Load();
                var clientList = _ecoDbEntities.Clients.Local.ToList();
                return clientList;
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
                var result = _ecoDbEntities.Clients.Add(client);
                _ecoDbEntities.SaveChanges();
                return result.ID;
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
                var clt = _ecoDbEntities.Clients.FirstOrDefault(x => x.ID == client.ID);

                if (clt != null)
                {
                    _ecoDbEntities.Entry(clt).CurrentValues.SetValues(client);
                    _ecoDbEntities.SaveChanges();
                    return clt.ID;
                }
                return -1;
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
                var client = _ecoDbEntities.Clients.FirstOrDefault(x => x.ID == id);
                if (client != null)
                {
                    var result = _ecoDbEntities.Clients.Remove(client);
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