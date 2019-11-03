using Resotel.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Resotel.Repositories
{
    public class PromotionRepository : BaseRepository
    {
        /**
         * Constructeur
         */
        public PromotionRepository() { }

        //--------------------------------------------------------------------

        /**
         * Retourne toutes les promotions
         */
        public List<promotion> GetPromotions()
        {
            return entities.promotion.ToList();
        }

        //--------------------------------------------------------------------

        /**
         * Retourne une promotion en fonction de l'id en paramètre
         */
        public promotion GetPromotion( int promotion_id )
        {
            return entities.promotion.Where(x => x.promotion_id == promotion_id).FirstOrDefault();
        }

        //--------------------------------------------------------------------

        /**
         * Créer une promotion dans la base de données
         */
        public promotion AddPromotion( promotion promo )
        {
            entities.promotion.Add(promo);
            entities.SaveChanges();
            return promo;
        }

        //-------------------------------------------------------------------

        /**
         * Supprime une promotion
         */
         public bool DeletePromotion( int promotion_id )
         {
            try
            {
                // Récupère la promotion
                promotion temp = entities.promotion.Where(x => x.promotion_id == promotion_id).FirstOrDefault();

                // Supprime la promotion
                entities.promotion.Remove(temp);

                // Sauvegarde la suppression
                entities.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
          }
    }
}
