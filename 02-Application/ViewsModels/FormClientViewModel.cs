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
                    });
                }
                return addShowClient;
            }
        }
    }
}