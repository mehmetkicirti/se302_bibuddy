
using Bibuddy.DataAccess.Abstract;
using Bibuddy.DataAccess.Concrete.Dapper;
using Bibuddy.DataAccess.Core.DI.Ninject;
using Bibuddy.DataAccess.Core.Utility;
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

            if (sPanelArticleTBx.Visibility == Visibility.Visible)
            {

                try
                {

                    article _article = new article()
                    {
                        bibtexkey = ArticleKey.Text,
                        title = ArticleTitle.Text,
                        author = ArticleAuthor.Text,
                        journal = ArticleAuthor.Text,
                        pages = ArticlePages.Text,
                        note = ArticleNote.Text,
                        doi = ArticleDoi.Text,
                        entrytype = GetEntryType.GetValueByEnum(GetEntryType.EntryType.Article)
                    };
                    if (ArticleYear.Text=="")
                    {
                        _article.year = null;
                    }
                    if (ArticleNumber.Text=="")
                    {
                        _article.number = null;
                    }
                    if (ArticleMonth.Text=="")
                    {
                        _article.month = null;
                    }
                    if (ArticleVolume.Text=="")
                    {
                        _article.volume = null;
                    }
                    //if (!int.TryParse(ArticleMonth.Text, out _month)||!int.TryParse(ArticleNumber.Text,out _number)|| !int.TryParse(ArticleVolume.Text, out _volume)|| !int.TryParse(ArticleYear.Text, out _year))
                    //{
                    //    throw new Exception("Not usable format value");
                    //}
                    //else
                    //{
                    //    _article.year = _year;
                    //    _article.month= _month;
                    //    _article.volume = _volume;
                    //    _article.number = _number;
                    //}

                    _iArticleService.Add(_article);
                    UIElement parent = App.Current.MainWindow;
                    parent.IsEnabled = true;
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    GetTypeByFieldClear(GetEntryType.EntryType.Article);
                }
            }
           

            // This command should be the latest command end of the line! -Asil
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            UIElement parent = App.Current.MainWindow;
            parent.IsEnabled = true;
        }

        public void GetTypeByFieldClear(GetEntryType.EntryType entryType)
        {
            switch (entryType)
            {
                case GetEntryType.EntryType.Article:
                    ArticleKey.Text = "";
                    ArticleTitle.Text = "";
                    ArticleAuthor.Text = "";
                    ArticleMonth.Text = "";
                    ArticleAuthor.Text = "";
                    ArticleNumber.Text = "";
                    ArticlePages.Text = "";
                    ArticleNote.Text = "";
                    ArticleYear.Text = "";
                    ArticleVolume.Text = "";
                    ArticleDoi.Text = "";
                    break;
                case GetEntryType.EntryType.Book:
                    break;
                case GetEntryType.EntryType.Booklet:
                    break;
                case GetEntryType.EntryType.Conference:
                    break;
                case GetEntryType.EntryType.InBook:
                    break;
                case GetEntryType.EntryType.InCollection:
                    break;
                case GetEntryType.EntryType.InProceedings:
                    break;
                case GetEntryType.EntryType.Manual:
                    break;
            }

            // when the panels finish i need to collapse all of the panels. - Asil // Please use if conditions cause when the something is already collapsed and u'll try to collapse it again maybe it creates crush for this app.
        }
    }
}