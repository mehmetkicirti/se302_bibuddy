
using Bibuddy.DataAccess.Abstract;
using Bibuddy.DataAccess.Concrete.Dapper;
using Bibuddy.DataAccess.Core.DI.Ninject;
using BiBuddy.Entities.Concrete;
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
        private readonly IArticleDal _iArticleService;
        private readonly IBookDal _iBookService;

        public AddPanels()
        {
            _iArticleService = InstanceFactory.GetInstance<DapperArticleDal>();
            _iBookService =
                InstanceFactory.GetInstance<DapperBookDal>();
            InitializeComponent();
        }

        private void addClickP(object sender, RoutedEventArgs e)
        {
            
            if (sPanelArticleTBx.Visibility==Visibility.Visible)
            {
                article _article = new article()
                {
                    bibtexkey = ArticleKey.Text,
                    title = ArticleTitle.Text,
                    author = ArticleAuthor.Text,
                    month = Convert.ToInt32(ArticleMonth.Text),
                    journal = ArticleAuthor.Text,
                    number = Convert.ToInt32(ArticleNumber.Text),
                    pages = ArticlePages.Text,
                    note = ArticleNote.Text,
                    year = Convert.ToInt32(ArticleYear.Text),
                    volume = Convert.ToInt32(ArticleVolume.Text)
                };
                if (ArticleAuthor.Text == "" || ArticleTitle.Text == "" || ArticleJournal.Text == "" || ArticleYear.Text == "" || ArticleVolume.Text == "")
                {
                    MessageBox.Show("You need to fill all required fields! ", "Error", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }
                else
                {
                    _iArticleService.Add(_article);
                }
            }
            UIElement parent = App.Current.MainWindow;
            parent.IsEnabled = true;
            this.Close(); 
            
            // This command should be the latest command end of the line! -Asil
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            UIElement parent = App.Current.MainWindow;
            parent.IsEnabled = true;
        }



        // when the panels finish i need to collapse all of the panels. - Asil // Please use if conditions cause when the something is already collapsed and u'll try to collapse it again maybe it creates crush for this app.
    }
}
