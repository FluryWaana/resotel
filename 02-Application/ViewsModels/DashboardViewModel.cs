using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resotel.ViewsModels
{
    public class DashboardViewModel : ViewModelBase
    {
        /**
         * Constructeur
         */ 
         public DashboardViewModel()
         {
            DateSelected = DateTime.Now;
         } 

        //--------------------------------------------------------------------

        /**
         * Date Selectionnée
         */
        private DateTime dateSelected;
        public DateTime DateSelected
        {
            get
            {
                return dateSelected;
            }

            set
            {
                dateSelected = value;
                NotifyPropertyChanged("DateSelected");
            }
        }
    }
}
