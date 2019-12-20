using BiBuddy.UI.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
    /// Interaction logic for UserControlMenuItem.xaml
    /// </summary>
    public partial class UserControlMenuItem : UserControl
    {
        
        public UserControlMenuItem(ItemMenu itemMenu)
        {
            InitializeComponent();
            
            ExpanderMenu.Visibility = itemMenu.SubItems != null ? Visibility.Visible: Visibility.Collapsed;
            ListViewItemMenu.Visibility = itemMenu.SubItems == null ? Visibility.Visible: Visibility.Collapsed;

            this.DataContext = itemMenu;
        }

        private void OpenAddPanelByType(object sender, MouseButtonEventArgs e)
        {
            var selectedItem = ListViewMenu.SelectedItem as SubItem;
            Window parentWindow = Window.GetWindow((DependencyObject)sender);
            if (parentWindow != null)
            {
                parentWindow.IsEnabled = false;
            }
            switch (selectedItem.Name)
            {
                case "Article":
                    AddPanels p1 = new AddPanels();
                    p1.Show();
                    p1.sPanelArticleTxB.Visibility = Visibility.Visible;
                    p1.sPanelArticleTBx.Visibility = Visibility.Visible;
                    break;
                case "Book":
                    AddPanels p2 = new AddPanels();
                    p2.Show();
                    p2.sPanelBookTxB.Visibility = Visibility.Visible;
                    p2.sPanelBookTBx.Visibility = Visibility.Visible;
                    break;
                case "Inbook":
                    AddPanels p3 = new AddPanels();
                    p3.Show();
                    p3.sPanelInbookTxB.Visibility = Visibility.Visible;
                    p3.sPanelInbookTBx.Visibility = Visibility.Visible;
                    break;
                case "Incollection":
                    AddPanels p4 = new AddPanels();
                    p4.Show();
                    p4.sPanelIncollectionTxB.Visibility = Visibility.Visible;
                    p4.sPanelIncollectionTBx.Visibility = Visibility.Visible;
                    break;
                case "Manual":
                    AddPanels p5 = new AddPanels();
                    p5.Show();
                    p5.sPanelManualTxB.Visibility = Visibility.Visible;
                    p5.sPanelManualTBx.Visibility = Visibility.Visible;
                    break;
                case "Conference":
                    AddPanels p6 = new AddPanels();
                    p6.Show();
                    p6.sPanelConferenceTxB.Visibility = Visibility.Visible;
                    p6.sPanelConferenceTBx.Visibility = Visibility.Visible;
                    break;
                case "Booklet":
                    AddPanels p7 = new AddPanels();
                    p7.Show();
                    p7.sPanelBookletTxB.Visibility = Visibility.Visible;
                    p7.sPanelBookletTBx.Visibility = Visibility.Visible;
                    break;
                default:
                    break;
            }
        }

        private void Grid_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (ExpanderMenu.DesiredSize.Width>=40 && ExpanderMenu.DesiredSize.Width<100)
            {
                ExpanderMenu.Visibility = Visibility.Hidden;
                ExpanderMenu.IsExpanded = false;
            }

            else if (ExpanderMenu.DesiredSize.Width == 160)
            {
                ExpanderMenu.Visibility = Visibility.Visible;
            }
        }
    }
}
