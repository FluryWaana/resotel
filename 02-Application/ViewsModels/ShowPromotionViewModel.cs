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
    public class ShowPromotionViewModel : ViewModelBase
    {
        /**
         * Repository Promotion
         */
        private PromotionRepository promotionRepository;

        /**
         * Repository Feature
         */
        private FeatureRepository featureRepository;

        //--------------------------------------------------------------------

        /**
         * Constructeur
         */
        public ShowPromotionViewModel( int promotion_id )
        {
            promotionRepository = new PromotionRepository();
            featureRepository   = new FeatureRepository();
            Promotion           = promotionRepository.GetPromotion(promotion_id);
            Features            = featureRepository.GetFeatures();
        }

        //--------------------------------------------------------------------

        /**
         * Promotion
         */
        private promotion promotion;
        public promotion Promotion
        {
            get
            {
                return promotion;
            }

            set
            {
                promotion = value;
                NotifyPropertyChanged("Promotion");
            }
        }

        //--------------------------------------------------------------------

        /**
         * Liste des options
         */
        private List<feature> features;
        public List<feature> Features
        {
            get
            {
                return features;
            }

            set
            {
                features = value;
                NotifyPropertyChanged("Features");
            }
        }

        //--------------------------------------------------------------------

        /**
         *  Commande Sauvegarde Modification
         */
        private ICommand btnSavePromotion;
        public ICommand BtnSavePromotion
        {
            get
            {
                if (btnSavePromotion == null)
                {
                    btnSavePromotion = new RelayCommand((window) =>
                    {

                    });
                }
                return btnSavePromotion;
            }
        }

        //--------------------------------------------------------------------

        /**
         *  Commande Sauvegarde Modification
         */
        private ICommand btnDeletePromotion;
        public ICommand BtnDeletePromotion
        {
            get
            {
                if (btnDeletePromotion == null)
                {
                    btnDeletePromotion = new RelayCommand((window) =>
                    {
                        promotionRepository.DeletePromotion(promotion.promotion_id);

                    });
                }
                return btnDeletePromotion;
            }
        }

    }
}
