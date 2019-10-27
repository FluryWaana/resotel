using Resotel.Entities;
using Resotel.Repositories;
using Resotel.Shared;
using System.Collections.Generic;
using System.Windows.Controls;

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

        private string statutString = "";
        public string StatutString
        {
            get
            {
                return statutString;
            }

            set
            {
                LogSystem.WriteLog((string)value, TypeLog.Information);
                statutString = value;
                NotifyPropertyChanged("StatutString");
                UpdateBedrooms();
            }
        }

        private string floorString = "";
        public string FloorString
        {
            get
            {
                return floorString;
            }

            set
            {
                LogSystem.WriteLog( value, TypeLog.Information);
                floorString = value;
                NotifyPropertyChanged("FloorString");
                UpdateBedrooms();
            }
        }

        //--------------------------------------------------------------------

        /**
         * Permet de mettre à jour la liste des chambres
         */
        private void UpdateBedrooms()
        {
            Bedrooms = bedroomRepository.GetBedrooms( "", FloorString);
        }
    }
}
