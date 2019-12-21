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
    public partial class BookView : Window
    {
        private readonly IBookDal _iBookService;
        public BookView()
        {
            _iBookService = InstanceFactory.GetInstance<DapperBookDal>();
            InitializeComponent();
            DataContext = new book();
        }

        private void Add_Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = Application.Current.Windows.OfType<MainWindow>().First();
            book _book= new book()
            {
                bibtexkey = bibtexkey_Txt.Text,
                title = title_Txt.Text,
                year = year_Txt.Text != "" ? Convert.ToInt32(year_Txt.Text) : null as int?,
                month = month_Txt.Text != "" ? Convert.ToInt32(month_Txt.Text) : null as int?,
                volume = volume_Txt.Text != "" ? Convert.ToInt32(volume_Txt.Text) : null as int?,
                author = author_Txt.Text,
                address = address_Txt.Text,
                publisher = publisher_Txt.Text,
                note= note_Txt.Text,
                edition = edition_Txt.Text != "" ? Convert.ToInt32(edition_Txt.Text): null as int?,
                series= series_Txt.Text != "" ? Convert.ToInt32(series_Txt.Text): null as int?,
                url= url_Txt.Text,
                entrytype = GetEntryType.GetValueByEnum(GetEntryType.EntryType.Article)
            };


            bool result = AllFieldEmpty();
            if (!result)
            {
                _iBookService.Add(_book);
                SetFieldClear();
                UIElement parent = App.Current.MainWindow;
                parent.IsEnabled = true;
                main.DataGridMain.ItemsSource = _iBookService.GetAll();
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
                    _iBookService.Add(_book);
                    SetFieldClear();
                    main.DataGridMain.ItemsSource = _iBookService.GetAll();
                    UIElement parent = App.Current.MainWindow;
                    parent.IsEnabled = true;
                    this.Close();
                    //do yes stuff
                }
            }
        }
        public void SetFieldClear()
        {
            bibtexkey_Txt.Text = "";
            title_Txt.Text = "";
            author_Txt.Text = "";
            address_Txt.Text = "";
            month_Txt.Text = "";
            publisher_Txt.Text = "";
            edition_Txt.Text = "";
            note_Txt.Text = "";
            year_Txt.Text = "";
            volume_Txt.Text = "";
            series_Txt.Text = "";
            url_Txt.Text = "";
        }
        public bool AllFieldEmpty()
        {
            if (bibtexkey_Txt.Text == "" &&
            title_Txt.Text == "" &&
            author_Txt.Text == "" &&
            publisher_Txt.Text == "" &&
            address_Txt.Text == "" &&
            month_Txt.Text == "" &&
            edition_Txt.Text == "" &&
            series_Txt.Text == "" &&
            note_Txt.Text == "" &&
            year_Txt.Text == "" &&
            volume_Txt.Text == "" &&
            url_Txt.Text == "")
            {
                return true;
            }
            return false;
        }
        private void Cancel_Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            UIElement parent = App.Current.MainWindow;
            parent.IsEnabled = true;
        }
        private void shomaretextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            // xaml.cs code
            if (!char.IsDigit(e.Text, e.Text.Length - 1))
                e.Handled = true;
        }
    }
}
