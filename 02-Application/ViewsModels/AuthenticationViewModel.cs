using Resotel.Entities;
using Resotel.Repositories;
using Resotel.Shared;
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
                    NotifyPropertyChanged("IsAuthenticated");
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
                    NotifyPropertyChanged("CurrentUser");
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
         * Cas particulier où il ne faut pas respecter l'architecture MVVM
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
                        lc.passwordBox.Password   = "";

                        // Change le statut
                        IsAuthenticated = true;
                        RoleAdministrateur = Administrateur();
                        RoleFacturation = Facturation();
                        RoleHebergement = Hebergement();
                        RoleNettoyage = Nettoyage();
                        RoleRestauration = Restauration();
                        messageError(lc, false);
                        return true;
                    }
                }
                messageError(lc, true, "Identifiants incorrects, veuillez vérifier votre email et mot de passe.");                     
            }
            catch( EntityException )
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

        //--------------------------------------------------------------------

        /**
         * Vérification des roles qui peuvent accéder aux onglets qui 
         * concerne l'hébergement
         */
        public bool Hebergement()
        {
            if( currentUser.role_name.Equals("hote d'accueil") || currentUser.role_name.Equals("standardiste") || currentUser.role_name.Equals("administrateur") )
            {
                return true;
            }
            return false;
        }

        private bool roleHebergement;
        public bool RoleHebergement
        {
            get
            {
                return roleHebergement;
            }

            set
            {
                roleHebergement = value;
                NotifyPropertyChanged("RoleHebergement");
            }
        }

        /**
         * Vérification des roles qui peuvent accéder aux onglets qui 
         * concerne la facturation
         */
        public bool Facturation()
        {
            if (currentUser.role_name.Equals("hote d'accueil") || currentUser.role_name.Equals("administrateur"))
            {
                return true;
            }
            return false;
        }

        private bool roleFacturation;
        public bool RoleFacturation
        {
            get
            {
                return roleFacturation;
            }

            set
            {
                roleFacturation = value;
                NotifyPropertyChanged("RoleFacturation");
            }
        }

        /**
         * Vérification des roles qui peuvent accéder aux onglets qui 
         * concerne le nettoyage
         */
        public bool Nettoyage()
        {
            if (currentUser.role_name.Equals("responsable de l'hygiène") || currentUser.role_name.Equals("administrateur"))
            {
                return true;
            }
            return false;
        }

        private bool roleNettoyage;
        public bool RoleNettoyage
        {
            get
            {
                return roleNettoyage;
            }

            set
            {
                roleNettoyage = value;
                NotifyPropertyChanged("RoleNettoyage");
            }
        }

        /**
         * Vérification des roles qui peuvent accéder aux onglets qui 
         * concerne la restauration
         */
        public bool Restauration()
        {
            if (currentUser.role_name.Equals("responsable de la restauration") || currentUser.role_name.Equals("administrateur"))
            {
                return true;
            }
            return false;
        }

        private bool roleRestauration;
        public bool RoleRestauration
        {
            get
            {
                return roleRestauration;
            }

            set
            {
                roleRestauration = value;
                NotifyPropertyChanged("RoleRestauration");
            }
        }

        /**
         * Vérification des roles qui peuvent accéder aux onglets qui 
         * concerne l'administration
         */
        public bool Administrateur()
        {
            if (currentUser.role_name.Equals("administrateur"))
            {
                return true;
            }
            return false;
        }

        private bool roleAdministrateur;
        public bool RoleAdministrateur
        {
            get
            {
                return roleAdministrateur;
            }

            set
            {
                roleAdministrateur = value;
                NotifyPropertyChanged("RoleAdministrateur");
            }
        }

    }
}
