using Resotel.Entities;
using Resotel.Repositories;
using System.Collections.Generic;

namespace Resotel.ViewsModels
{
    public class BedroomViewModel : ViewModelBase
    {
        /**
         * Liste des chambres
         */
        private List<bedroom> bedrooms;

        /**
         * Repository pour la gestion requêtes
         */
        private BedroomRepository bedroomRepository;

        //--------------------------------------------------------------------

        /*
         * Constructeur
         */
        public BedroomViewModel()
        {
            bedroomRepository = new BedroomRepository();
            Bedrooms          = bedroomRepository.GetBedrooms();
        }

        //--------------------------------------------------------------------        

        /**
        * Getter & Setter
        */
        public List<bedroom> Bedrooms
        {
            get
            {
                return bedrooms;
            }

            set
            {
                bedrooms = value;
                NotifyPropertyChanged("Bedrooms");
            }
        }
    }
}
