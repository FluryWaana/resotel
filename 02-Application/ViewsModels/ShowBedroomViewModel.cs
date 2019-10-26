using Resotel.Entities;
using Resotel.Repositories;
using Resotel.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resotel.ViewsModels
{
    public class ShowBedroomViewModel : ViewModelBase
    {
        /**
         * Liste des chambres
         */
        private bedroom _bedroom;

        /**
         * Repository pour la gestion requêtes
         */
        private BedroomRepository bedroomRepository;

        //--------------------------------------------------------------------

        /*
         * Constructeur
         */
        public ShowBedroomViewModel() {}

        /*
         * Constructeur
         */
        public ShowBedroomViewModel( int bedroom_number )
        {
            // TODO Gestion d'erreur si la chambre est n'existe pas
            this.bedroomRepository = new BedroomRepository();
            this._bedroom          = bedroomRepository.GetBedroom(bedroom_number);
        }

        //--------------------------------------------------------------------

        /**
        * Getter
        */
        public bedroom Bedroom
        {
            get
            {
                return _bedroom;
            }
        }
    }
}
