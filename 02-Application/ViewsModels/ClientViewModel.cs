using Resotel.Entities;
using System;
using System.Collections.Generic;
using Resotel.Repositories;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Resotel.ViewsModels
{
    public class ClientViewModel : ViewModelBase
    {
        /**
        * Liste des clients
        */
        private List<client> clients;
        private ClientRepository clientRepository;

        public ObservableCollection<client> Clients { get; set; }
        private ICollectionView observer;

        public ClientViewModel ContactSelected
        {
            get { return observer.CurrentItem as ClientViewModel; }
        }

        public ClientViewModel()
        {
            clients = new ObservableCollection<client>();
            List<client> lst = Repositories.ClientRepository.Instance.ChargerContacts();
            foreach (client person in lst)
            {
                ClientViewModel vm = new ClientViewModel(client);
                vm.OnDeleted += ContactOnDeleted;
                ListeContacts.Add(vm);
            }

            observer = CollectionViewSource.GetDefaultView(ListeContacts);
            observer.MoveCurrentToFirst();
            observer.CurrentChanged += Observer_CurrentChanged;
        }

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
