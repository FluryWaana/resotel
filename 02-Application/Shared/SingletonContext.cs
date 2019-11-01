using Resotel.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resotel.Shared
{
    /**
     *  Il faut utiliser un singleton pour utiliser uniquement un seul context dans EntityFramework
     *  pour éviter d'avoir plusieurs instances de celui-ci qui provoquerai lors d'un ajout
     *  ou d'une mise à jour d'un object l'erreur :
     *  An entity object cannot be referenced by multiple instances of IEntityChangeTracker
     */
    public class SingletonContext
    {
        /**
         * Variable qui contient le Context
         */
        protected resotelEntities entities;

        //--------------------------------------------------------------------

        #region Singleton
        /**
         * Instance du singleton
         */
        private static SingletonContext instance = null;
        public static SingletonContext Instance
        {
            get
            {
                if( instance ==null )
                {
                    instance = new SingletonContext();
                }
                return instance;
            }
        }
        #endregion

        //--------------------------------------------------------------------

        /**
         * Constructeur en privé pour éviter l'instanciation de classe hors
         * de celle-ci
         */
        private SingletonContext()
        {
            entities = new resotelEntities();
        }

        //--------------------------------------------------------------------
        
        /**
         * Retourne le contexte d'EntityFramework
         */
        public resotelEntities getContext()
        {
            return entities;
        }
    }
}
