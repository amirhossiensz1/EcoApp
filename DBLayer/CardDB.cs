using System;
using System.Data.Entity;
using System.Linq;
using Model;

namespace DBLayer
{
    public class CardDB
    {
        public void InsertCardData(Card card)
        {
            try
            {
                var echoDbEntities = new EchoDBEntities();
                echoDbEntities.Cards.Load();
                echoDbEntities.Cards.Add(card);
                echoDbEntities.SaveChanges();
            }
            catch (Exception exception1)
            {
                throw;
            }
        }

        public void DeleteOneCard(object id)
        {
            try
            {
                var echoDbEntities = new EchoDBEntities();
                var card = echoDbEntities.Cards.FirstOrDefault(x => x.EmpID == (int) id);
                echoDbEntities.Cards.Remove(card);
                echoDbEntities.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void DeleteCards(object id)
        {
            try
            {
                var echoDbEntities = new EchoDBEntities();
                echoDbEntities.Cards.Load();
                var cardlist = echoDbEntities.Cards.Where(x => x.EmpID == (int) id);
                echoDbEntities.Cards.RemoveRange(cardlist);
                echoDbEntities.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }


        public bool SelectOneCard(string cardData)
        {
            try
            {
                var echoDbEntities = new EchoDBEntities();
                echoDbEntities.Cards.Load();
                var card = echoDbEntities.Cards.FirstOrDefault(x => x.CardData == cardData);
                echoDbEntities.SaveChanges();
                // ReSharper disable once ConditionIsAlwaysTrueOrFalse

                if (card != null)
                    return true;
                return false;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                return false;
            }
        }

        public string SelectCardData(int? empId)
        {
            try
            {
                var echoDbEntities = new EchoDBEntities();
                echoDbEntities.Cards.Load();
                var card = echoDbEntities.Cards.FirstOrDefault(x => x.EmpID == empId);
                echoDbEntities.SaveChanges();

                if (card != null)
                    return card.CardData;
                return "";
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                return "";
            }
        }

        public bool SelectOneCard(int id)
        {
            try
            {
                var echoDbEntities = new EchoDBEntities();
                echoDbEntities.Cards.Load();
                var card = echoDbEntities.Cards.FirstOrDefault(x => x.EmpID == id);
                echoDbEntities.SaveChanges();

                // ReSharper disable once ConditionIsAlwaysTrueOrFalse
                if (card != null)
                    return true;
                return false;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool ExistCard(int? empId)
        {
            try
            {
                var echoDbEntities = new EchoDBEntities();
                echoDbEntities.Cards.Load();
                var card = echoDbEntities.Cards.FirstOrDefault(x => x.EmpID == empId);
                echoDbEntities.SaveChanges();

                if (card != null)
                    return true;
                return false;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void UpdateGuestCard(Card card)
        {
            try
            {
                var echoDbEntities = new EchoDBEntities();
                var crd = echoDbEntities.Cards.FirstOrDefault(x => x.EmpID == card.EmpID);

                if (crd != null)
                {
                    crd.CardData = card.CardData;
                    echoDbEntities.Entry(crd).CurrentValues.SetValues(crd);
                    echoDbEntities.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }


        public bool ExistCardNumber(int cardNumber)
        {
            try
            {
                var echoDbEntities = new EchoDBEntities();
                echoDbEntities.Cards.Load();
                var card = echoDbEntities.Cards.FirstOrDefault(x => x.CardNumber == cardNumber);
                echoDbEntities.SaveChanges();

                if (card != null)
                    return true;
                return false;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}