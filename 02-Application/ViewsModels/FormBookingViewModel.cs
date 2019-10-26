using Resotel.Entities;
using Resotel.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resotel.ViewsModels
{
    class FormBookingViewModel : ViewModelBase
    {
        private booking booking;

        public booking Booking
        {
            get
            {
                return booking;
            }

            set
            {
                booking = value;
                NotifyPropertyChanged("Booking");
            }
        }


    }
}
