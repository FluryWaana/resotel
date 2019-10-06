using Resotel.Entities;
using Resotel.Repositories;
using Resotel.Views;
using System;
using System.Data.Entity.Core;
using System.Windows;

namespace Resotel.ViewsModels
{
    public class AuthenticationViewModel : ViewModelBase
    {
        /**
         * Boolean permet de savoir si un utilisateur est connecté
         */ 
        private bool isAuthenticated;

        /**
         * User permet de connaître l'utilisateur authentifié
         */
        private user currentUser;

        /**
         * Message d'erreur
         */
        private string error;

        /**
         * Variable UserRepository
         */
        private UserRepository userRepository;

        //--------------------------------------------------------------------

        /**
         * Constructeur
         */
        public AuthenticationViewModel()
        {
            IsAuthenticated = false;
            CurrentUser     = new user();
            userRepository  = new UserRepository();
        }

        //--------------------------------------------------------------------

        /**
         * 
         */
         public string Error
         {
            get
            {
                return error;
            }

            set
            {
                if(value != error)
                {
                    error = value;
                    NotifyPropertyChanged();
                }
            }
         }

        /**
         * Getter & Setter isAuthenticated
         */
        public bool IsAuthenticated 
        {
            get
            {
                return isAuthenticated;
            }

            set
            {
                if (value != isAuthenticated)
                {
                    isAuthenticated = value;
                    NotifyPropertyChanged();
                    NotifyPropertyChanged("IsNotAuthenticated");
                }
            }
        }

        public user CurrentUser
        {
            get
            {
                return currentUser;
            }

            set

            {
                if (value != currentUser)
                {
                    currentUser = value;
                    NotifyPropertyChanged();
                }
            }
        }

        /**
         * Boolean qui permet de gérer la visiblité de fenêtre si 
         * l'utilisateur n'est pas authentifié
         */
        public bool IsNotAuthenticated
        {
            get
            {
                return !IsAuthenticated;
            }
        }

        /**
         * Connecte un utilisateur
         * Il est impossible de binder un Password Box pour des raisons de sécurité.
         * Celui-ci ne doit pas être stocker en mémoire
         */
        public bool Login( LoginControl lc )
        {
            try
            {
                // Récupération de l'utilisateur 
                user temp = userRepository.GetUserByIdentifiant( CurrentUser.user_identifiant.ToLower() );

                if (temp != null)
                {
                    CurrentUser = temp;

                    // Vérification du mot de passe
                    if (BCrypt.Net.BCrypt.Verify(lc.passwordBox.Password, CurrentUser.user_password))
                    {
                        // Suppression du mot de passe dans la mémoire
                        CurrentUser.user_password = "";
                        lc.passwordBox.Password   = "";

                        // Change le statut
                        IsAuthenticated = true;
                        messageError(lc, false);
                        return true;
                    }
                }
                else
                {
                    messageError(lc, true, "Identifiants incorrects, veuillez vérifier votre email et mot de passe.");
                }                    
            }
            catch( EntityException e )
            {
                messageError(lc, true, "Impossible de se connecter à la base de données");
            }
            catch( Exception e )
            {
                messageError(lc, true, e.Message);
            }
            
            return false;
        }

        /**
         * Permet l'affichage de message d'erreur
         */
        private void messageError(LoginControl lc, bool show, string message = "")
        {
            lc.loginStatut.Text = message;

            if ( show )
            {
                lc.loginStatut.Visibility = Visibility.Visible;
            }
            else
            {
                lc.loginStatut.Visibility = Visibility.Collapsed;
            }
        }

        /**
         * Déconnecte un utilisateur
         */
        public void Logout()
        {
            IsAuthenticated = false;
            CurrentUser     = new user();
        }
    }
}
