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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BiBuddy.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            help.Text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Phasellus fermentum eros ut lorem dapibus pharetra. Etiam sit amet lectus dapibus, " +
                "congue augue sed, scelerisque diam. Aliquam pharetra risus mauris, non convallis orci placerat sodales. Cras quis urna vitae magna varius ornare. Praesent " +
                "aliquet luctus magna, id aliquam purus pretium ut. Etiam laoreet orci quis risus varius, non volutpat quam gravida. Vestibulum sed ultricies ex, at gravida " +
                "augue. Donec commodo ullamcorper tempus. Ut quis lacinia nunc. Fusce consectetur aliquam lectus at maximus. Integer pretium ultricies placerat. Quisque risus " +
                "magna, cursus sed ultricies vel, convallis nec risus. Integer consectetur sem vitae enim scelerisque convallis. Donec nulla nisl, pulvinar eget sodales et, " +
                "accumsan sed mauris. Vivamus et turpis tortor. Mauris vitae nulla suscipit, imperdiet tellus et, pellentesque massa. Suspendisse at fringilla urna. " +
                "Pellentesque non risus ligula. Quisque faucibus urna sed eros pulvinar, hendrerit finibus elit tempus. Morbi dignissim, urna et iaculis rhoncus, ipsum mi " +
                "laoreet neque, posuere bibendum arcu augue sit amet arcu.";
        }

        private void searchBib(object sender, RoutedEventArgs e)
        {
            d1.Visibility = Visibility.Collapsed;
            s1.Visibility = Visibility.Visible;
        }

        private void BackClickAN(object sender, RoutedEventArgs e)
        {
            d1.Visibility = Visibility.Visible;
            s1.Visibility = Visibility.Collapsed;
        }

        private void HelpClick(object sender, RoutedEventArgs e)
        {
            d1.Visibility = Visibility.Collapsed;
            s2.Visibility = Visibility.Visible;
        }

        private void BackClickH(object sender, RoutedEventArgs e)
        {
            d1.Visibility = Visibility.Visible;
            s2.Visibility = Visibility.Collapsed;
        }

        private void ArticleClick(object sender, RoutedEventArgs e)
        {
            AddPanels addP = new AddPanels();
            addP.Show();
            addP.sPanelArticleTxB.Visibility = Visibility.Visible;
            addP.sPanelArticleTBx.Visibility = Visibility.Visible;
        }

        private void ConferenceClick(object sender, RoutedEventArgs e)
        {
            AddPanels addP = new AddPanels();
            addP.Show();
            addP.sPanelConferenceTxB.Visibility = Visibility.Visible;
            addP.sPanelConferenceTBx.Visibility = Visibility.Visible;
        }

        private void BookletClick(object sender, RoutedEventArgs e)
        {
            AddPanels addP = new AddPanels();
            addP.Show();
            addP.sPanelBookletTxB.Visibility = Visibility.Visible;
            addP.sPanelBookletTBx.Visibility = Visibility.Visible;
        }

        private void BookClick(object sender, RoutedEventArgs e)
        {
            AddPanels addP = new AddPanels();
            addP.Show();
            addP.sPanelBookTxB.Visibility = Visibility.Visible;
            addP.sPanelBookTBx.Visibility = Visibility.Visible;
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {

        }
        private void Exit(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Are you sure to Exit ?", "BiBuddy Exit", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                System.Windows.Application.Current.Shutdown();
            }
        }

        private void IncollectionClick(object sender, RoutedEventArgs e)
        {
            AddPanels addP = new AddPanels();
            addP.Show();
            addP.sPanelIncollentionTxB.Visibility = Visibility.Visible;
            addP.sPanelIncollectionTBx.Visibility = Visibility.Visible;
        }

        private void InbookClick(object sender, RoutedEventArgs e)
        {
            AddPanels addP = new AddPanels();
            addP.Show();
            addP.sPanelInbookTxB.Visibility = Visibility.Visible;
            addP.sPanelInbookTBx.Visibility = Visibility.Visible;
        }

        private void ManuelClick(object sender, RoutedEventArgs e)
        {
            AddPanels addP = new AddPanels();
            addP.Show();
            addP.sPanelManuelTxB.Visibility = Visibility.Visible;
            addP.sPanelManuelTBx.Visibility = Visibility.Visible;
        }
    }
}
