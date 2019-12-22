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

namespace BiBuddy.UI.AddPanel
{
    /// <summary>
    /// Interaction logic for ArticleView.xaml
    /// </summary>
    public partial class ArticleView : Window
    {
        private readonly IArticleDal _iArticleService;
        public ArticleView()
        {
            _iArticleService = InstanceFactory.GetInstance<DapperArticleDal>();
            InitializeComponent();
            DataContext = new article();
           
        }

        private void Add_Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = Application.Current.Windows.OfType<MainWindow>().First();
            article _article = new article()
            {
                bibtexkey = bibtexKey_Txt.Text,
                title = title_Txt.Text,
                year = year_Txt.Text != "" ? Convert.ToInt32(year_Txt.Text) : null as int?,
                number = number_Txt.Text != "" ? Convert.ToInt32(number_Txt.Text) : null as int?,
                month = month_Txt.Text != "" ? Convert.ToInt32(month_Txt.Text) : null as int?,
                volume = volume_Txt.Text != "" ? Convert.ToInt32(volume_Txt.Text) : null as int?,
                author = author_Txt.Text,
                journal = journal_Txt.Text,
                pages = pages_Txt.Text,
                note = note_Txt.Text,
                doi = doi_Txt.Text,
                entrytype = GetEntryType.GetValueByEnum(GetEntryType.EntryType.Article)
            };
            
            
            bool result = AllFieldEmpty();
            if (!result)
            {
                _iArticleService.Add(_article);
                SetFieldClear();
                UIElement parent = App.Current.MainWindow;
                parent.IsEnabled = true;
                main.DataGridMain.ItemsSource = GetEntryType.GetAllByTypes();
                this.Close();
            }
            else
            {
                if (MessageBox.Show("Are you Sure to create a empty .bib", "Question", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
                {
                    //do no stuff
                    return;
                }
                else
                {
                    _iArticleService.Add(_article);
                    SetFieldClear();
                    main.DataGridMain.ItemsSource = GetEntryType.GetAllByTypes();
                    UIElement parent = App.Current.MainWindow;
                    parent.IsEnabled = true;
                    this.Close();
                    //do yes stuff
                }
            }
            
            //var r=Application.Current.Windows.OfType<W_MessageBox>();
            
        }

        private void Cancel_Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            UIElement parent = App.Current.MainWindow;
            parent.IsEnabled = true;
        }
        public void SetFieldClear()
        {
                    bibtexKey_Txt.Text = "";
                    title_Txt.Text = "";
                    author_Txt.Text = "";
                    journal_Txt.Text = "";
                    month_Txt.Text = "";
                    number_Txt.Text = "";
                    pages_Txt.Text = "";
                    note_Txt.Text = "";
                    year_Txt.Text = "";
                    volume_Txt.Text = "";
                    doi_Txt.Text = "";
        }
        public bool AllFieldEmpty()
        {
            if (bibtexKey_Txt.Text == "" &&
            title_Txt.Text == "" &&
            author_Txt.Text == "" && 
            journal_Txt.Text == "" &&
            month_Txt.Text == "" &&
            number_Txt.Text == "" &&
            pages_Txt.Text == "" &&
            note_Txt.Text == "" &&
            year_Txt.Text == "" &&
            volume_Txt.Text == "" &&
            doi_Txt.Text == "")
            {
                return true;
            }
            return false;
        }
        //private void Window_Closed(object sender, EventArgs e)
        //{
        //    UIElement parent = App.Current.MainWindow;
        //    parent.IsEnabled = true;
        //}
        private void shomaretextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            // xaml.cs code
            if (!char.IsDigit(e.Text, e.Text.Length - 1))
                e.Handled = true;
        }
    }

}
