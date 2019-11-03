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

        public bedroom SetFree( int bedroom_number )
        {
            LogSystem.WriteLog("aa", TypeLog.Information);
            // Récupère la chambre dans la base de données
            bedroom temp = entities.bedroom.Where(x => x.bedroom_number == bedroom_number).FirstOrDefault();

            // Met à jour le statut
            temp.bedroom_status = "libre";

            // Sauvegarde la modification
            entities.SaveChanges();

            return temp;
        }
        
        //--------------------------------------------------------------------

        /**
         * Récupère toutes les chambres selons les filtres
         */
        public List<bedroom> GetBedrooms( string statut = "", int floor = 0, bedroom_type b_type = null )
        {
            // Récupère toutes les chambres
            var query  = entities.bedroom.Select(x => x);

            // Si un statut est mis dans les filtres de recherche
            if( ! statut.Equals( "" ) )
            {
                query = query.Where( x => x.bedroom_status.Equals(statut));
            }

            // Si un étage est mis dans les filtres de recherche
            if( floor > 0 )
            {
                query = query.Where(x => x.bedroom_floor == floor);
            }

            // Si un type de chambre est mis dans les filtres
            if( b_type != null )
            {
                query = query.Where(x => x.bedroom_type.bedroom_type1 == b_type.bedroom_type1);
            }
            return query.ToList();
        }
    }
}
