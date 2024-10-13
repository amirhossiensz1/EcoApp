using System.Collections.Generic;
using System.Linq;
using DBLayer;
using Model;

namespace BLL
{
    public class GuestBLL
    {
        private GuestDB guestdb;

        public GuestBLL()
        {
            guestdb = new GuestDB();
        }

        public IQueryable<GuestCard> SelectGuestCards()
        {
            var guestDb = new GuestDB();

            return guestDb.SelectAllGuestCard();
        }

        public List<GuestCard> CreateListCard(int fromcardNumber, int tocardNumber)
        {
            var guestCard = new GuestCard[(tocardNumber - fromcardNumber) + 1];
            var guestCards = new List<GuestCard>();

            for (var i = fromcardNumber; i <= tocardNumber; i++)
            {
                guestCard[i - fromcardNumber] = new GuestCard();
                guestCard[i - fromcardNumber].ID = i;
                guestCard[i - fromcardNumber].Name = "مهمان " + i;
                guestCard[i - fromcardNumber].CardNumber = i;
                guestCard[i - fromcardNumber].CardNumberStr = "کارت شماره " + i;
                guestCards.Add(guestCard[i - fromcardNumber]);
            }
            return guestCards;
        }
    }
}