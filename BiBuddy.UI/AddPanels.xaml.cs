using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace BiBuddy.UI
{
    /// <summary>
    /// Interaction logic for AddPanels.xaml
    /// </summary>
    public partial class AddPanels : Window
    {
        public AddPanels()
        {
            InitializeComponent();
        }

        private void addClickP(object sender, RoutedEventArgs e)
        {
            this.Close(); // This command should be the latest command end of the line! -Asil
        }// when the panels finish i need to collapse all of the panels. - Asil // Please use if conditions cause when the something is already collapsed and u'll try to collapse it again maybe it creates crush for this app.
    }
}
