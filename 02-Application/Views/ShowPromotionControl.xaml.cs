using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Resotel.Views
{
    /// <summary>
    /// Logique d'interaction pour ShowPromotionControl.xaml
    /// </summary>
    public partial class ShowPromotionControl : UserControl
    {
        public ShowPromotionControl()
        {
            InitializeComponent();

            percentage.PreviewTextInput += TextBoxOnlyNumber;

        }

        private void TextBoxOnlyNumber(object sender, TextCompositionEventArgs e)
        {
            e.Handled = new Regex("[^0-9]+").IsMatch(e.Text);
        }
    }
}
