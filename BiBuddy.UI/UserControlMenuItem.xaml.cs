using BiBuddy.UI.AddPanel;
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
                    ArticleView p1 = new ArticleView();
                    p1.Show();
                    break;
                case "Book":
                    BookView p2 = new BookView();
                    p2.Show();
                    break;
                case "Inbook":
                    InBookView p3 = new InBookView();
                    p3.Show();
                    break;
                case "Incollection":
                    InCollectionView p4 = new InCollectionView();
                    p4.Show();
                    break;
                case "Manual":
                    ManualView p5 = new ManualView();
                    p5.Show();
                    break;
                case "Conference":
                    ConferenceView p6 = new ConferenceView();
                    p6.Show();
                    break;
                case "Booklet":
                    BookletView p7 = new BookletView();
                    p7.Show();
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
