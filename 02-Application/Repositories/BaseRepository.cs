using Resotel.Entities;

namespace Resotel.Repositories
{
    public abstract class BaseRepository
    {
        /**
         * Variable qui contient le Context
         */
        protected resotelEntities entities = new resotelEntities();
    }
}
