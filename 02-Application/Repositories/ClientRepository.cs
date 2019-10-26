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
        public client addClient()
        {
            client cl = new client();
            cl.client_lastname = "";
            cl.client_firstname = "";

            var query = entities.client.Add(cl);

            return null;
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
