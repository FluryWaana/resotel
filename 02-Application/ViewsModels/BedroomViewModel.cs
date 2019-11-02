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
            Floors            = bedroomRepository.GetEtages();
            Floors.Add(0);
            Statuts           = bedroomRepository.GetStatuts();
            Statuts.Add("");
            BedroomType       = bedroomRepository.GetBedroomType();
            BedroomType.Add(new bedroom_type());
        }

        //--------------------------------------------------------------------     

        /**
         * Liste des chambres
         */
        private List<bedroom> bedrooms;
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

        /**
         * Liste des étages
         */
        private List<int> floors;
        public List<int> Floors
        {
            get
            {
                return floors;
            }

            set
            {
                floors = value;
                NotifyPropertyChanged("Floors");
            }
        }

        /**
         * Binding du filtre pour l'étage
         */
        private int floor_filter;
        public int Floor_filter
        {
            get
            {
                return floor_filter;
            }

            set
            {
                floor_filter = value;
                NotifyPropertyChanged("Floor_filter");
                UpdateBedrooms();
            }
        }

        /**
         * Liste des étages
         */
        private List<string> statuts;
        public List<string> Statuts
        {
            get
            {
                return statuts;
            }

            set
            {
                statuts = value;
                NotifyPropertyChanged("Statuts");
            }
        }

        /**
         * Binding du filtre pour l'état
         */
        private string statutString = "";
        public string StatutString
        {
            get
            {
                return statutString;
            }

            set
            {
                statutString = value;
                NotifyPropertyChanged("StatutString");
                UpdateBedrooms();
            }
            
        }

        /**
         * Liste des types de chambres
         */
        private List<bedroom_type> bedroomType;
        public List<bedroom_type> BedroomType
        {
            get
            {
                return bedroomType;
            }

            set
            {
                bedroomType = value;
                NotifyPropertyChanged("BedroomType");
            }
        }

        /**
         * Binding du filtre pour le type de chambre
         */
        private bedroom_type bedroom_type;
        public bedroom_type Bedroom_type
        {
            get
            {
                return bedroom_type;
            }

            set
            {
                bedroom_type = value;
                NotifyPropertyChanged("Bedroom_type");
                UpdateBedrooms();
            }

        }


        //--------------------------------------------------------------------

        /**
         * Permet de mettre à jour la liste des chambres
         */
        private void UpdateBedrooms()
        {
            Bedrooms = bedroomRepository.GetBedrooms( StatutString, Floor_filter);
        }
    }
}
