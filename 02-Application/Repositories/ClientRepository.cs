using Resotel.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
         * Ajoute et modifie les informations du client
         */
        public client addClient(client c)
        {
            if (c.client_id > 0)
            {
                entities.client.Attach(c);
                entities.Entry(c).State = EntityState.Modified;
            }
            else
            {
               entities.client.Add(c); ;
            }
            entities.SaveChanges();
            return c;
        }

        /**
        * Supprime le client
        */
        public bool DeleteClient(client c)
        {
            if (c.client_id > 0)
            {
                {
                    entities.client.Attach(c);
                    entities.Entry(c).State = EntityState.Deleted;
                }
                entities.SaveChanges();
                return true;
            }
            return false;
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
