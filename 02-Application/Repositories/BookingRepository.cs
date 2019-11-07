using Resotel.Entities;
using Resotel.Shared;
using System;
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
            return entities.booking.Select(x => x).OrderByDescending( x => x.booking_start ).ToList();
        }

        //--------------------------------------------------------------------

        /**
         * Retourne la liste de chambre en fonction des paramètres:
         * Type de chambre, Date_start, date_end
         */
        public List<bedroom> GetBedrooms( DateTime date_start, DateTime date_end, bedroom_type b_type = null )
        {
            // Récupération de toutes les chambres disponibles en fonction du type et
            List<int> temp_bedroom_number = entities.Database.SqlQuery<int>("SELECT bedroom_number " +
                                "FROM bedroom " +
                                "WHERE bedroom_number NOT IN(SELECT br.bedroom_number " +
                                "FROM bedroom br " +
                                "LEFT JOIN booking bk ON br.bedroom_number = bk.bedroom_number " +
                                "WHERE bk.booking_start >= '" + date_start.ToString("yyyy-MM-dd") + "' " +
                                "AND bk.booking_end <= '" + date_end.ToString("yyyy-MM-dd") + "' " +
                                "ORDER BY bedroom_number ASC) ORDER BY bedroom_number").ToList<int>();

            /**
             * Filtre les chambres disponibles en fonction des dates en paramètre.
             * temp_bedroom_number.Contains( x.bedroom_number ) représente le where IN
             */
            var query = entities.bedroom.Select(x => x).Where( x => temp_bedroom_number.Contains( x.bedroom_number ) );
            
            /**
             * Filtre le type de chambre
             * Si le type de chambre est différent de null alors on récupère
             * toutes les chambres de ce type
             */ 
            if ( b_type != null )
            {
                query = query.Where(x => x.bedroom_type.bedroom_type1 == b_type.bedroom_type1);
            }

            return query.ToList();
        }


        //--------------------------------------------------------------------

        /**
         * 
         */
        public booking AddBooking(booking book, int client_id, int beedroom_number)
        {
            // Récupération du client
            client client_temp = entities.client.Where(x => x.client_id == client_id).FirstOrDefault();

            // Récupération de la chambre
            bedroom bedroom_temp = entities.bedroom.Where(x => x.bedroom_number == beedroom_number).FirstOrDefault();

            // Assigne le client à la réservation
            book.client_id = client_temp.client_id;

            // Assigne la chambre
            book.bedroom_number = bedroom_temp.bedroom_number;

            // Ajoute la réservation à la base de données
            entities.booking.Add(book);

            entities.SaveChanges();

            return book;
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
