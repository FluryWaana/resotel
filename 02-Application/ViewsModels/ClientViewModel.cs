using Resotel.Entities;
using Resotel.Repositories;
using Resotel.Shared;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Data;
using System.Windows.Input;

namespace Resotel.ViewsModels
{
    public class ClientViewModel : ViewModelBase
    {
        /**
         *  Collection de clients observés
         */
        private ObservableCollection<FormClientViewModel> listClient;

        /**
         * Client selectionné
         */
        private FormClientViewModel clientSelected;

        /**
         * 
         */
        private ICollectionView observer;

        /**
         * Liste des clients de la base de données
         */
        private List<client> clientsDataBase;

        /**
         * 
         */
        private ClientRepository clientRepository;

        //--------------------------------------------------------------------

        /*
         * Constructeur
         */
        public ClientViewModel()
        {
            // Instanciation de ClientRepository
            clientRepository = new ClientRepository();

            // Récupération des clients dans la base de données
            clientsDataBase = clientRepository.GetClients();

            // Instanciation de ObservableCollection
            listClient = new ObservableCollection<FormClientViewModel>();

            /**
             * Remplissage de la collection d'observable avec les clients 
             * de la base de données
             */
            foreach (client client in clientsDataBase)
            {
                addClientList(client);
            }

            observer = CollectionViewSource.GetDefaultView(listClient);
            observer.CurrentChanged += Observer_CurrentChanged;
            observer.MoveCurrentToFirst();
        }

        //--------------------------------------------------------------------

        /**
         * Liste des clients
         */
        public ObservableCollection<FormClientViewModel> ListClient
        {
            get => listClient;

            set
            {
                if (value != listClient)
                {
                    listClient = value;
                    NotifyPropertyChanged();
                }
            }
        }

        //--------------------------------------------------------------------

        /**
         * Notifie que le client sélectionné a changé
         */
        private void Observer_CurrentChanged(object sender, EventArgs e)
        {
            NotifyPropertyChanged("ClientSelected");
        }

        /**
         * Supprime le client selectionné
         */
        private void delete(object sender, EventArgs e)
        {
            this.listClient.Remove(ClientSelected);
            NotifyPropertyChanged("ListClients");
            observer.MoveCurrentToFirst();
        }

        /**
         * Client selectionné
         */
        public FormClientViewModel ClientSelected
        {
            get
            {
                return (FormClientViewModel)observer.CurrentItem;
            }

            set
            {
                LogSystem.WriteLog("aaaaaa", TypeLog.Information);
                clientSelected = value;
                NotifyPropertyChanged();
            }
        }

        /**
         * Ajoute un client
         * Ajoute l'evenement de suppression au client
         */
        private void addClientList(client client)
        {
            FormClientViewModel temp = new FormClientViewModel(client);
            temp.ClientEvent += delete;
            listClient.Add(temp);
        }
    }
}
