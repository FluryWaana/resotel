using Meziantou.WpfFontAwesome;
using Resotel.Shared;
using Resotel.Views;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Resotel.ViewsModels
{
    public class MainViewModel : ViewModelBase
    {
        /**
         * Vue Modèle qui gère l'authentification
         */
        public AuthenticationViewModel AuthVM { get; set; }

        public MainViewModel()
        {
            AuthVM = new AuthenticationViewModel();
        }

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
                    login = new RelayCommand((passwordBox) =>
                    {
                        PasswordBox pb  = (PasswordBox)passwordBox;
                        string password = BCrypt.Net.BCrypt.HashPassword( pb.Password );
                        AuthVM.Login( password );
                    });
                }
                return login;
            }
        }

        /**
         *  Methode pour déconnecter un utilisateur
         */
        private ICommand logout;
        public ICommand Logout
        {
            get
            {
                if (logout == null)
                {
                    logout = new RelayCommand((window) =>
                    {
                        AuthVM.Logout();
                    });
                }
                return logout;
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
    }
}
