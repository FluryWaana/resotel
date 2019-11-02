using Resotel.Entities;
using Resotel.Shared;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.Linq;

namespace Resotel.Repositories
{
    public class BedroomRepository : BaseRepository
    {
        /**
         * Constructeur
         */
        public BedroomRepository()
        {
        }

        //--------------------------------------------------------------------

        /**
         * Retourne une chambre en fonction de son numéro
         */
        public bedroom GetBedroom( int number  )
        {
            return entities.bedroom.Where( x => x.bedroom_number == number ).FirstOrDefault();
        }

        //--------------------------------------------------------------------

        /**
         * Retourne la liste de tous les étages
         */
        public List<int> GetEtages()
        {
            return entities.Database.SqlQuery<int>("SELECT bedroom_floor FROM bedroom GROUP BY bedroom_floor").ToList<int>();
        }

        //--------------------------------------------------------------------

        /**
         * Retourne la liste de tous les statuts
         */
         public List<string> GetStatuts()
         {
            return new List<string> { "libre", "occupée", "reservée", "à nettoyer" };
         }

        //--------------------------------------------------------------------

        /**
         * Retourne la liste de type de chambre
         */
         public List<bedroom_type> GetBedroomType()
         {
            return entities.bedroom_type.ToList();
         }
        
        //--------------------------------------------------------------------

        /**
         * Récupère toutes les chambres selons les filtres
         */
        public List<bedroom> GetBedrooms( string statut = "", int floor = 0, string date_start = "", string date_end = "" )
        {
            // Récupère toutes les chambres
            var query  = entities.bedroom.Select(x => x);

            // Si un statut est mis dans les filtres de recherche
            if( ! statut.Equals( "" ) )
            {
                query = query.Where( x => x.bedroom_status.Equals(statut));
            }

            // Si un étage est mis dans les filtres de recherche
            if(  floor > 0 )
            {
                query = query.Where(x => x.bedroom_floor == floor);
            }

            if( ! date_start.Equals( "" ) && ! date_end.Equals( "" ) )
            {
                List<int> temp_bedroom_number = entities.Database.SqlQuery<int>("SELECT bedroom_number " +
                                                "FROM bedroom " +
                                                "WHERE bedroom_number NOT IN(SELECT br.bedroom_number " +
                                                    "FROM bedroom br " +
                                                    "LEFT JOIN booking bk ON br.bedroom_number = bk.bedroom_number " +
                                                    "WHERE bk.booking_start >= '2019-04-26' " +
                                                    "AND bk.booking_end <= '2019-04-27') " +
                                                "ORDER BY bedroom_number ASC").ToList<int>();

            }
            return query.ToList();
        }
    }
}
