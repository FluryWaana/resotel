﻿using Resotel.Entities;
using Resotel.Shared;
using System.Collections.Generic;
using System.Data.Entity;
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
         * 
         */
        public bedroom addBedroom()
        {
            bedroom br = new bedroom();
            br.bedroom_floor  = 1;
            br.bedroom_number = 100;

            var query = entities.bedroom.Add( br );

            return null;
        }

        //--------------------------------------------------------------------

        /**
         * Récupère toutes les chambres selons les filtres
         */
        public List<bedroom> GetBedrooms( string statut = "", string floor = "" )
        {
            // Récupère toutes les chambres
            var query  = entities.bedroom.Select(x => x);

            // Si un statut est mis dans les filtres de recherche
            if( ! statut.Equals( "" ) )
            {
                query = query.Where( x => x.bedroom_status.Equals(statut));

            }

            // Si un étage est mis dans les filtres de recherche
            if( ! floor.Equals( "" ) )
            {
                query = query.Where( x => x.bedroom_floor == int.Parse( floor ) );
            }

            return query.ToList();
        }
    }
}
