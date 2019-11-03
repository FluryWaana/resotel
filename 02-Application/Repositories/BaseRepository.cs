using Resotel.Entities;
using Resotel.Shared;

namespace Resotel.Repositories
{
    public abstract class BaseRepository
    {
        /**
         * Variable qui contient le Context
         */
        protected resotelEntities entities = SingletonContext.Instance.getContext();
    }
}
