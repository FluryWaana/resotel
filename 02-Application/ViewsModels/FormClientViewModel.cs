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
    public delegate void ClientEventHandler(object sender, EventArgs e);
    public class FormClientViewModel : ViewModelBase
    {
        /**
        *  Evenement de Suppression du client
        */
        public event EventHandler OnDeleted;

        /**
         *  Client
         */
        private client client;

        /**
         * Repository pour la gestion requêtes
         */
        private ClientRepository clientRepository;

        //-----------------------------------------------------------

        /**
         * Constructeur
         */
        public FormClientViewModel(client client)
        {
            clientRepository = new ClientRepository();
            this.client = client;
        }

        //--------------------------------------------------------------

        public client Client
        {
            get => client;
            set
            {
                client = value;
                NotifyPropertyChanged("Client");
            }
        }

        //--------------------------------------------------------------------

        /**
         *  
         */
        public ClientEventHandler ClientEvent;
        public void RaiseTheEvent()
        {
            ClientEvent?.Invoke(this, EventArgs.Empty);
        }

        //-------------------------------------------------------------

        private ICommand addShowClient;
        public ICommand AddShowClient
        {
            get
            {
                if (addShowClient == null)
                {
                    addShowClient = new RelayCommand((window) =>
                    {
                        clientRepository.addClient(client);
                    },
                    (window) =>
                    {
                        if ( string.IsNullOrWhiteSpace(Client.client_lastname)     ||
                             string.IsNullOrWhiteSpace(Client.client_firstname)    ||
                             string.IsNullOrWhiteSpace(Client.client_address)      || 
                             string.IsNullOrWhiteSpace(Client.client_city)         ||
                             string.IsNullOrWhiteSpace(Client.client_postalCode)   ||
                             string.IsNullOrWhiteSpace(Client.client_email)        ||
                             string.IsNullOrWhiteSpace(Client.client_phone)        ||
                             Client.client_postalCode.Length > 5 )
                        {
                            return false;
                        }
                        return true;
                    });
                }
                return addShowClient;
            }
        }

        private ICommand commandDelete;
        public ICommand CommandDelete
        {
            get
            {
                if (commandDelete == null)
                {
                    commandDelete = new RelayCommand(sender => {

                        if (Client.client_id > 0) clientRepository.DeleteClient(client);
                        OnDeleted?.Invoke(this, EventArgs.Empty);
                    });
                }
                return commandDelete;
            }
        }
    }
}