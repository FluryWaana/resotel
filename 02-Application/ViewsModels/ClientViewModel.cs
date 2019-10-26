using Resotel.Entities;
using System;
using System.Collections.Generic;
using Resotel.Repositories;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resotel.ViewsModels
{
    public class ClientViewModel : ViewModelBase
    {
        /**
        * Liste des clients
        */
        private List<client> clients;

        private ClientRepository clientRepository;

        //--------------------------------------------------------------------

        /*
         * Constructeur
         */
        public ClientViewModel()
        {
            clientRepository = new ClientRepository();
            Clients = clientRepository.GetClients();
        }


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
    }
}
