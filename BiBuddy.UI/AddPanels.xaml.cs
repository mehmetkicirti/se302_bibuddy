using Bibuddy.Business.Abstract;
using Bibuddy.Business.Concrete.Dapper;
using Bibuddy.Business.DI.Ninject;
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
        private readonly IArticleService _iArticleService;
        private readonly IBookService _iBookService;

        public AddPanels()
        {
            _iArticleService = InstanceFactory.GetInstance<DapperArticleManager>();
            _iBookService =
                InstanceFactory.GetInstance<DapperBookManager>();
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
            this.Close(); 
            
            // This command should be the latest command end of the line! -Asil
        }
        
        
        
        // when the panels finish i need to collapse all of the panels. - Asil // Please use if conditions cause when the something is already collapsed and u'll try to collapse it again maybe it creates crush for this app.
    }
}
