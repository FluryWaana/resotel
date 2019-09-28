using Resotel.ViewsModels;
using System.Windows;
using System.Windows.Input;

namespace Resotel.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainViewModel();
        }

        private void BtnDragMove(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
    }
}
