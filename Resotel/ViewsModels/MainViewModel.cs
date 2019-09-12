using Resotel.Shared;
using Resotel.Views;
using System.Windows;
using System.Windows.Input;
using Meziantou.WpfFontAwesome;

namespace Resotel.ViewsModels
{
    public class MainViewModel : ViewModelBase
    {
        public MainViewModel() { }

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
         * Commande pour réduire la fenêtre de l'application
         */
        private ICommand moveApp;
        public ICommand MoveApp
        {
            get
            {
                if (moveApp == null)
                {
                    moveApp = new RelayCommand((window) =>
                    {
                        if (window != null)
                        {
                            MainWindow temp = (MainWindow)window;
                            temp.btnMoveWindow.PreviewMouseDown += teeeest;
                        }
                    });
                }
                return reduceApp;
            }
        }

        private void teeeest( object obj, MouseEventArgs e  )
        {
            temp.DragMove();
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
