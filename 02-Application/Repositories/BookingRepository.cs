using Resotel.Entities;
using Resotel.Shared;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Resotel.Repositories
{
    class BookingRepository : BaseRepository
    {

        /**
        * Constructeur
        */
        public BookingRepository()
        {
        }

        //--------------------------------------------------------------------

        public booking addBooking()
        {
            booking book = new booking();

            // ici ajouter des fake reservations pour test
            book.bedroom_number = 10;
            


            var query = entities.booking.Add(book);

            return null;

        }


        public List<booking> GetBookings()
        {
            // Récupère toutes les reservations
            var query = entities.booking.Select(x => x);

            return query.ToList();
        }
    }
}
