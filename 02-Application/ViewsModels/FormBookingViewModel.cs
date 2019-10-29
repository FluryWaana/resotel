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
        private List<client> clients;

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

        public List<client> Client
        {
            get
            {
                return clients;
            }

            set
            {
                clients = value;
                NotifyPropertyChanged("Client");
            }
        }


    }
}
