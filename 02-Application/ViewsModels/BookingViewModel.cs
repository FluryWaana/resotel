using Resotel.Entities;
using Resotel.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resotel.ViewsModels
{
    public class BookingViewModel : ViewModelBase
    {
        /**
         * Liste des reservations
         */
        private List<booking> bookings;

        private BookingRepository bookingRepository;

        /*
         * Constructeur
         */
        public BookingViewModel()
        {
            bookingRepository = new BookingRepository();
            Bookings = bookingRepository.GetBookings();
        }

        public List<booking> Bookings
        {
            get
            {
                return bookings;
            }

            set
            {
                bookings = value;
                NotifyPropertyChanged("Bookings");
            }
        }


    }
}
