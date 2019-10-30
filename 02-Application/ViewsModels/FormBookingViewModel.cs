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
    class FormBookingViewModel : ViewModelBase
    {
        /**
         * Repository Booking
         */
        private BookingRepository bookingRepository = new BookingRepository();

        //--------------------------------------------------------------------

        /**
         * Constructeur
         */ 
        public FormBookingViewModel()
        {
            // Récupération de la liste des clients
            Clients = bookingRepository.GetClients();

            // Récupération de la liste des chambres disponibles
            Bedrooms = bookingRepository.GetBedrooms();

            // Création d'une réservation
            Booking = new booking
            {
                booking_start = DateTime.Now,
                booking_end   = DateTime.Now
            };
        }

        //--------------------------------------------------------------------

        /**
         * Réservation
         */
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

        /**
         * Liste des clients
         */
        private List<client> clients;
        public List<client> Clients
        {
            get
            {
                return clients;
            }

            set
            {
                clients = value;
                NotifyPropertyChanged("Clients");
            }
        }

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
         * client_id
         */
        private int client_id;
        public int Client_id
        {
            get
            {
                return client_id;
            }

            set
            {
                client_id = value;
                NotifyPropertyChanged("Client_id");
            }
        }

        /**
         * beedroom_number
         */
        private int beedroom_number;
        public int Beedroom_number
        {
            get
            {
                return beedroom_number;
            }

            set
            {
                beedroom_number = value;
                NotifyPropertyChanged("Beedroom_number");
            }
        }

        //--------------------------------------------------------------------

        /**
         * Commande réservation
         */
        private ICommand btnAddBooking;
        public ICommand BtnAddBooking
        {
            get
            {
                if (btnAddBooking == null)
                { 
                    btnAddBooking = new RelayCommand( x =>
                    {
                        bookingRepository.AddBooking(booking, client_id, Beedroom_number);
                    },
                    window =>
                    {
                        /**
                         * TODO: Revoir conditions
                         * Si pas de chambre, Si pas de client, Si la date start est inférieure à aujourd'hui,
                         * Si la date end est inférieure à aujourd'hui && inférieure à date end de start
                         * booking.bedroom_number == 0                     ||
                         * client_id              == 0                     ||
                         *  26/04/2016 < 27/04/2016
                         */
                        if ( 
                             
                             booking.booking_start   < DateTime.Now          ||
                             booking.booking_end     < booking.booking_start
                           )
                        {
                            return false;
                        }
                        return true;
                    });
                }
                return btnAddBooking;
            }
        }


    }
}
