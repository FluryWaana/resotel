using Resotel.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resotel.ViewsModels
{
    public class AuthenticationViewModel : ViewModelBase
    {
        /**
         * Constructeur
         */ 
        public AuthenticationViewModel()
        {
            IsAuthenticated = false;
        }

        /**
         * Boolean qui permet de savoir si l'utilisateur
         * est connecté ou pas
         */
        private bool isAuthenticated;
        public bool IsAuthenticated
        {
            get { return isAuthenticated; }
            set
            {
                if (value != isAuthenticated)
                {
                    isAuthenticated = value;
                    NotifyPropertyChanged("IsAuthenticated");
                    NotifyPropertyChanged("IsNotAuthenticated");
                }
            }
        }

        /**
         * Boolean qui permet de savoir si l'utilisateur
         * est déconnecté ou pas
         */
        public bool IsNotAuthenticated
        {
            get
            {
                return !IsAuthenticated;
            }
        }

        private user currentUser;
        public user CurrentUser
        {
            get { return currentUser; }
            set

            {
                if (value != currentUser)
                {
                    currentUser = value;
                    NotifyPropertyChanged("CurrentUser");
                }
            }
        }

        /**
         * Connecte un utilisateur
         */
        public void Login( string password )
        {
            IsAuthenticated = true;
        }

        /**
         * Déconnecte un utilisateur
         */ 
        public void Logout()
        {
            IsAuthenticated = false;
            CurrentUser     = null;
        }
    }
}
