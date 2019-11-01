using Resotel.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resotel.Shared
{
    public class SingletonContext
    {
        /**
         * Variable qui contient le Context
         */
        protected resotelEntities entities;

        #region Singleton
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

        private SingletonContext()
        {
            entities = new resotelEntities();
        }
        
        public resotelEntities getContext()
        {
            return entities;
        }
    }
}
