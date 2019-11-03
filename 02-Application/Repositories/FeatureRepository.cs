using Resotel.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resotel.Repositories
{
    public class FeatureRepository : BaseRepository
    {
        /**
         * Constructeur
         */
        public FeatureRepository() { }

        //--------------------------------------------------------------------

        /**
         * Retourne toutes les options
         */
        public List<feature> GetFeatures()
        {
            return entities.feature.ToList();
        }
    }
}
