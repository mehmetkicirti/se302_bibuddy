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
    /// Interaction logic for SelectEntry.xaml
    /// </summary>
    public partial class SelectEntry : Window
    {
        public SelectEntry()
        {
            InitializeComponent();
        }
        private void Article_btn_click(object sender, RoutedEventArgs e)
        {

            AddPanels addP = new AddPanels();
            addP.Show();
            addP.sPanelArticleTxB.Visibility = Visibility.Visible;
            addP.sPanelArticleTBx.Visibility = Visibility.Visible;
        }
        private void Book_btn_click(object sender, RoutedEventArgs e)
        {

            AddPanels addP = new AddPanels();
            addP.Show();
            addP.sPanelBookTxB.Visibility = Visibility.Visible;
            addP.sPanelBookTBx.Visibility = Visibility.Visible;
        }
        private void InBook_btn_click(object sender, RoutedEventArgs e)
        {

            AddPanels addP = new AddPanels();
            addP.Show();
            addP.sPanelInbookTxB.Visibility = Visibility.Visible;
            addP.sPanelInbookTBx.Visibility = Visibility.Visible;
        }
        private void InCollection_btn_click(object sender, RoutedEventArgs e)
        {

            AddPanels addP = new AddPanels();
            addP.Show();
            addP.sPanelIncollectionTxB.Visibility = Visibility.Visible;
            addP.sPanelIncollectionTBx.Visibility = Visibility.Visible;
        }
        private void Manual_btn_click(object sender, RoutedEventArgs e)
        {

            AddPanels addP = new AddPanels();
            addP.Show();
            addP.sPanelManualTxB.Visibility = Visibility.Visible;
            addP.sPanelManualTBx.Visibility = Visibility.Visible;
        }
        private void Booklet_btn_click(object sender, RoutedEventArgs e)
        {

            AddPanels addP = new AddPanels();
            addP.Show();
            addP.sPanelBookletTxB.Visibility = Visibility.Visible;
            addP.sPanelBookletTBx.Visibility = Visibility.Visible;
        }
        private void Conference_btn_click(object sender, RoutedEventArgs e)
        {

            AddPanels addP = new AddPanels();
            addP.Show();
            addP.sPanelConferenceTxB.Visibility = Visibility.Visible;
            addP.sPanelConferenceTBx.Visibility = Visibility.Visible;
        }
        private void Window_Closed_1(object sender, EventArgs e)
        {
            // change the event to avoid close form
            UIElement parent = App.Current.MainWindow;
            parent.IsEnabled = true;

        }
    }
}
