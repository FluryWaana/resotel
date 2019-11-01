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
        private List<client> clients;
        private List<booking> bookings;
        private List<bedroom> bedrooms;

        public FormBookingViewModel()
        {
            bookingRepository = new BookingRepository();
            Client = bookingRepository.GetClients();
            Booking = bookingRepository.GetBookings();
            Bedroom = bookingRepository.GetBedrooms();
        }

        private BookingRepository bookingRepository;

        public List<booking> Booking
        {
            get
            {
                return bookings;
            }

            set
            {
                bookings = value;
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

        public List<bedroom> Bedroom
        {
            get
            {
                return bedrooms;
            }

            set
            {
                bedrooms = value;
                NotifyPropertyChanged("Bedroom");
            }
        }


    }
}
