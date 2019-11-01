using Resotel.Entities;
using Resotel.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resotel.ViewsModels
{
    public delegate void ClientEventHandler(object sender, EventArgs e);
    public class FormClientViewModel : ViewModelBase
    {
        /**
         *  Client
         */
        private client client;

        //-----------------------------------------------------------

        /**
         * Constructeur
         */
        public FormClientViewModel(client client)
        {
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
    }
}