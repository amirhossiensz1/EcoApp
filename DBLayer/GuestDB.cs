using System;
using System.Data.Entity;
using System.Linq;
using Model;

namespace DBLayer
{
    public class GuestDB
    {
        private readonly EchoDBEntities echoDbEntities;

        public GuestDB()
        {
            echoDbEntities = new EchoDBEntities();
        }

        public void SelectAllGuest()
        {
            try
            {
                echoDbEntities.Employees.Load();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IQueryable<GuestCard> SelectAllGuestCard()
        {
            try
            {
                var echoDbEntities = new EchoDBEntities();
                var carList = from card in echoDbEntities.Cards
                    join employee in echoDbEntities.Employees
                        on card.EmpID equals employee.ID
                    where card.IsGuest == true
                    select new GuestCard
                    {
                        ID = card.ID,
                        Name = employee.EmpFname + employee.EmpLname,
                        CardNumber = card.CardNumber,
                        CardNumberStr = "کارت شماره " + card.CardNumber
                    };
                return carList;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}