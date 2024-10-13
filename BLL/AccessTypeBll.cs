using System;
using DBLayer;

namespace BLL
{
    public class AccessTypeBll
    {
        private readonly AccessTypeDb _accessTypeDb = new AccessTypeDb();

        public object SelectAccessType()
        {
            try
            {
                return _accessTypeDb.SelectAccessType();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}