using Meziantou.WpfFontAwesome;
using Resotel.Shared;
using Resotel.Views;
using System.Windows;
using System.Windows.Input;

namespace Resotel.ViewsModels
{
    public class MainViewModel : ViewModelBase
    {
        /**
         * Vue Modèle qui gère l'authentification
         */
        public AuthenticationViewModel AuthVM { get; set; }

        //--------------------------------------------------------------------

        /**
         * Constructeur
         */
        public MainViewModel()
        {
            AuthVM            = new AuthenticationViewModel();
            SelectedViewModel = new LoginViewModel();
        }

        //--------------------------------------------------------------------

        private object selectedViewModel;

        public object SelectedViewModel

        {

            get
            {
                return selectedViewModel;
            }

            set
            {
                selectedViewModel = value;
                NotifyPropertyChanged("SelectedViewModel");
            }

        }

        //--------------------------------------------------------------------

        /**
         * Methode pour connecter un utilisateur
         */
        private ICommand login;
        public ICommand Login
        {
            get
            {
                if( login == null )
                {
                    login = new RelayCommand((window) =>
                    {
                        LoginControl lc = (LoginControl)window;

                        if (AuthVM.Login(lc))
                        {
                            SelectedViewModel = new DashboardViewModel();
                        }
                    },
                    (window) =>
                    {
                        if (string.IsNullOrWhiteSpace(AuthVM.CurrentUser.user_identifiant) || string.IsNullOrWhiteSpace(((LoginControl)window).passwordBox.Password) )
                        {
                            return false;
                        }
                        return true;
                    });
                }
                return login;
            }
        }

        /**
         *  Methode pour déconnecter un utilisateur
         */
        private ICommand btnlogout;
        public ICommand BtnLogout
        {
            get
            {
                if (btnlogout == null)
                {
                    btnlogout = new RelayCommand((window) =>
                    {
                        AuthVM.Logout();
                        SelectedViewModel = new LoginViewModel();
                    });
                }
                return btnlogout;
            }
        }

        /**
         * Commande pour réduire la fenêtre de l'application
         */
        private ICommand reduceApp;
        public ICommand ReduceApp
        {
            get
            {
                if (reduceApp == null)
                {
                    reduceApp = new RelayCommand((window) =>
                    {
                        if (window != null)
                        {
                            ((MainWindow)window ).WindowState = WindowState.Minimized;
                        }
                    });
                }
                return reduceApp;
            }
        }

        /**
         * Commande pour aggrandir la fenêtre de l'application
         */
        private ICommand enlargeApp;
        public ICommand EnlargeApp
        {
            get
            {
                if (enlargeApp == null)
                {
                    enlargeApp = new RelayCommand((window) =>
                    {
                        if (window != null)
                        {
                            MainWindow temp = (MainWindow)window;
                            if ( temp.WindowState != WindowState.Maximized )
                            {
                                temp.WindowState        = WindowState.Maximized;
                                temp.sizeIcon.SolidIcon = FontAwesomeSolidIcon.WindowRestore;
                            }
                            else
                            {
                                temp.WindowState        = WindowState.Normal;
                                temp.sizeIcon.SolidIcon = FontAwesomeSolidIcon.WindowMaximize;
                            }
                        }
                    });
                }
                return enlargeApp;
            }
        }

        /**
         * Commande pour fermer l'application
         */
        private ICommand closeApp;
        public ICommand CloseApp
        {
            get
            {
                if (closeApp == null)
                {
                    closeApp = new RelayCommand((window) =>
                    {
                        if ( window != null )
                        {
                            ((MainWindow)window).Close();
                        }
                    });
                }
                return closeApp;
            }
        }

        /**
         * Commande sur le bouton "Accueil"
         */
        private ICommand btnAccueil;
        public ICommand BtnAccueil
        {
            get
            {
                if (btnAccueil == null)
                {
                    btnAccueil = new RelayCommand((window) =>
                    {
                        SelectedViewModel = new DashboardViewModel();
                    });
                }
                return btnAccueil;
            }
        }

        /**
         * Commande sur le bouton "Client"
         */
        private ICommand btnClient;
        public ICommand BtnClient
        {
            get
            {
                if (btnClient == null)
                {
                    btnClient = new RelayCommand((window) =>
                    {
                        SelectedViewModel = new ClientViewModel();
                    });
                }
                return btnClient;
            }
        }

        /**
         * Commande sur le bouton "Chambre"
         */
        private ICommand btnBedroom;
        public ICommand BtnBedroom
        {
            get
            {
                if (btnBedroom == null)
                {
                    btnBedroom = new RelayCommand((window) =>
                    {
                        SelectedViewModel = new BedroomViewModel();
                    });
                }
                return btnBedroom;
            }
        }

        /**
         * Commande sur le bouton "Chambre"
         */
        private ICommand btnBooking;
        public ICommand BtnBooking
        {
            get
            {
                if (btnBooking == null)
                {
                    btnBooking = new RelayCommand((window) =>
                    {
                        SelectedViewModel = new BookingViewModel();
                    });
                }
                return btnBooking;
            }
        }

        /**
         * Commande sur le bouton "Chambre"
         */
        private ICommand btnShowBedroom;
        public ICommand BtnShowBedroom
        {
            get
            {
                if (btnShowBedroom == null)
                {
                    btnShowBedroom = new RelayCommand(( bedroom_number ) =>
                    {
                        SelectedViewModel = new ShowBedroomViewModel( ( int ) bedroom_number );
                    });
                }
                return btnShowBedroom;
            }
        }

        /**
         * Commande sur le bouton "Chambre"
         */
        private ICommand btnShowFormBooking;
        public ICommand BtnShowFormBooking
        {
            get
            {
                if (btnShowFormBooking == null)
                {
                    btnShowFormBooking = new RelayCommand((window) =>
                    {
                        SelectedViewModel = new FormBookingViewModel();
                    });
                }
                return btnShowFormBooking;
            }
        }

    }
}
