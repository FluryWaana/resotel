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
        }

        private void BtnDragMove(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
    }
}
