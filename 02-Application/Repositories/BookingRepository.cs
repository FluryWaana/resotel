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

        public List<bedroom_type> GetBedroomType()
        {
            return entities.bedroom_type.ToList();
        }

        public List<booking> GetBookings()
        {
            return entities.booking.Select(x => x).ToList();
        }

        public List<bedroom> GetBedrooms(bedroom_type b_type = null, string date_start = "", string date_end = "")
        {
            // Récupère toutes les chambres
            var query = entities.bedroom.Select(x => x);


            // Si un type de chambre est mis dans les filtres
            if (b_type != null)
            {
                query = query.Where(x => x.bedroom_type.bedroom_type1 == b_type.bedroom_type1);
            }

            if (!date_start.Equals("") && !date_end.Equals(""))
            {
                List<int> temp_bedroom_number = entities.Database.SqlQuery<int>("SELECT bedroom_number " +
                                                "FROM bedroom " +
                                                "WHERE bedroom_number NOT IN(SELECT br.bedroom_number " +
                                                    "FROM bedroom br " +
                                                    "LEFT JOIN booking bk ON br.bedroom_number = bk.bedroom_number " +
                                                    "WHERE bk.booking_start >="+date_start+
                                                    "AND bk.booking_end <=" +date_end+
                                                "ORDER BY bedroom_number ASC").ToList<int>();

            }
            return query.ToList();
        }


        //----------Ajout reservation table booking
        public booking AddBooking(booking book, int client_id, int beedroom_number)
        {
            // Récupération du client
            client client_temp = entities.client.Where(x => x.client_id == client_id).FirstOrDefault();

            // Récupération de la chambre
            bedroom bedroom_temp = entities.bedroom.Where(x => x.bedroom_number == beedroom_number).FirstOrDefault();

            // TODO : 
            // Assigne le client à la réservation
            // book. = client_temp;

            // Assigne la chambre
            book.bedroom_number = bedroom_temp.bedroom_number;

            // Ajoute la réservation à la base de données
            entities.booking.Add(book);

            //entities.SaveChanges();

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
