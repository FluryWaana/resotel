using Resotel.Entities;
using Resotel.Repositories;
using Resotel.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Resotel.ViewsModels
{
    public class PromotionViewModel : ViewModelBase
    {
        /**
         * Repository pour la gestion requêtes
         */
        private PromotionRepository promotionRepository;

        //--------------------------------------------------------------------

        /*
         * Constructeur
         */
        public PromotionViewModel()
        {
            promotionRepository = new PromotionRepository();
            Promotions          = promotionRepository.GetPromotions();
        }

        //--------------------------------------------------------------------

        /**
         * Liste des promotions
         */
        private List<promotion> promotions;
        public List<promotion> Promotions
        {
            get
            {
                return promotions;
            }

            set
            {
                promotions = value;
                NotifyPropertyChanged("Promotions");
            }
        }

        /**
         * Binding show/hide filter
         */
        private bool showFilter;
        public bool ShowFilter
        {
            get
            {
                return showFilter;
            }

            set
            {
                showFilter = value;
                NotifyPropertyChanged("ShowFilter");
            }
        }

        //--------------------------------------------------------------------

        /**
         *  Affiche / Cache les filtres
         */
        private ICommand btnShowFilter;
        public ICommand BtnShowFilter
        {
            get
            {
                if (btnShowFilter == null)
                {
                    btnShowFilter = new RelayCommand((window) =>
                    {
                        ShowFilter = !showFilter;
                    });
                }
                return btnShowFilter;
            }
        }
    }
}
