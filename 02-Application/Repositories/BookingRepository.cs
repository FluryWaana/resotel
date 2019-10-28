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
            return entities.booking.Select(x => x).ToList();
        }

        public booking SaveBooking( int booking_id)

        {
            // Recupère la véservation
            booking resa = entities.booking.Where(x => x.booking_id == booking_id).FirstOrDefault();

            // Modifie les attributs
            resa.bedroom_number = 20;

            // Sauvegarde les modifications
            entities.SaveChanges();

            // Retourne la réservation
            return resa;
        }
    }
}
