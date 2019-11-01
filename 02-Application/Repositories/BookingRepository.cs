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

        //-----------List accès aux champs
        public List<client> GetClients()
        {
            return entities.client.Select(x => x).ToList();
        }

        public List<booking> GetBookings()
        {
            return entities.booking.Select(x => x).ToList();
        }

        public List<bedroom> GetBedrooms()
        {
            return entities.bedroom.Select(x => x).ToList();
        }



        //----------Ajout reservation table booking
        public booking AddBooking(booking book)
        {  

            entities.booking.Add(book);

            return null;

        }


        

        public booking SaveBooking( int booking_id)

        {
            // Recupère la réservation
            booking resa = entities.booking.Where(x => x.booking_id == booking_id).FirstOrDefault();

            // Sauvegarde les modifications
            entities.SaveChanges();

            // Retourne la réservation
            return resa;
        }
    }
}
