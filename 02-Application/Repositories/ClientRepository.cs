using Resotel.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resotel.Repositories
{
    public class ClientRepository : BaseRepository
    {
        /**
        * Constructeur
        */
        public ClientRepository()
        {
        }

        //--------------------------------------------------------------------

        /**
         * 
         */
        public client addClient( client c )
        {
            entities.client.Add( c );
            entities.SaveChanges();
            return c;
        }

        /**
        * 
        */
        public client UpdateClient(client c)
        {
            entities.client.Add(c);
            entities.SaveChanges();
            return c;
        }

        //--------------------------------------------------------------------

        /**
         * Récupère tous les clients selons les filtres
         */
        public List<client> GetClients(string lastname = "", string firstname = "")
        {
            // Récupère tous les clients
            var query = entities.client.Select(x => x);

            // Si un lastname est mis dans les filtres de recherche
            if (!lastname.Equals(""))
            {
                query = query.Where(x => x.client_lastname.Equals(lastname));

            }

            // Si firstname est mis dans les filtres de recherche
            if (!firstname.Equals(""))
            {
                query = query.Where(x => x.client_lastname.Equals(firstname));
            }

            return query.ToList();
        }
    }
}
