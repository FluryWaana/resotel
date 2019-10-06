using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Resotel.Entities;

namespace Resotel.Repositories
{
    public class UserRepository : BaseRepository
    {
        /**
         * Constructeur
         */ 
        public UserRepository()
        {
        }

        //--------------------------------------------------------------------

        /**
         * Retourne un utilisateur en fonction de son identifiant
         */
        public user GetUserByIdentifiant( string identifiant )
        {
            return entities.user.Where( x => x.user_identifiant.Equals( identifiant ) ).FirstOrDefault();
        }
    }
}
