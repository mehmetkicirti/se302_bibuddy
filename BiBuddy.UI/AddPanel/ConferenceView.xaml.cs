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
    /// Interaction logic for ConferenceView.xaml
    /// </summary>
    public partial class ConferenceView : Window
    {
        private readonly IConferenceDal _iConferenceService;

        public ConferenceView()
        {
            _iConferenceService = InstanceFactory.GetInstance<DapperConferenceDal>();
            InitializeComponent();
            DataContext = new conference();
        }

        private void Cancel_Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            UIElement parent = App.Current.MainWindow;
            parent.IsEnabled = true;
        }
        private void Add_Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = Application.Current.Windows.OfType<MainWindow>().First();
            conference _conference = new conference()
            {
                bibtexkey = bibtexkey_Txt.Text,
                title = title_Txt.Text,
                year = year_Txt.Text != "" ? Convert.ToInt32(year_Txt.Text) : null as int?,
                series = series_Txt.Text != "" ? Convert.ToInt32(series_Txt.Text) : null as int?,
                month = month_Txt.Text != "" ? Convert.ToInt32(month_Txt.Text) : null as int?,
                volume = volume_Txt.Text != "" ? Convert.ToInt32(volume_Txt.Text) : null as int?,
                author = author_Txt.Text,
                address = address_Txt.Text,
                pages = pages_Txt.Text,
                note = note_Txt.Text,
                booktitle = bookTitle_Txt.Text,
                organization = organization_Txt.Text,
                publisher = publisher_Txt.Text,
                editor = editor_Txt.Text,
                entrytype = GetEntryType.GetValueByEnum(GetEntryType.EntryType.Conference)
            };


            bool result = AllFieldEmpty();
            if (!result)
            {
                _iConferenceService.Add(_conference);
                SetFieldClear();
                UIElement parent = App.Current.MainWindow;
                parent.IsEnabled = true;
                main.DataGridMain.ItemsSource = _iConferenceService.GetAll();
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
                    _iConferenceService.Add(_conference);
                    SetFieldClear();
                    main.DataGridMain.ItemsSource = _iConferenceService.GetAll();
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
            bookTitle_Txt.Text = "";
            title_Txt.Text = "";
            author_Txt.Text = "";
            publisher_Txt.Text = "";
            month_Txt.Text = "";
            organization_Txt.Text = "";
            pages_Txt.Text = "";
            note_Txt.Text = "";
            year_Txt.Text = "";
            volume_Txt.Text = "";
            series_Txt.Text = "";
            address_Txt.Text = "";
            editor_Txt.Text = "";
        }
        public bool AllFieldEmpty()
        {
            if (bibtexkey_Txt.Text == "" &&
            title_Txt.Text == "" &&
            author_Txt.Text == "" &&
            publisher_Txt.Text == "" &&
            month_Txt.Text == "" &&
            organization_Txt.Text == "" &&
            pages_Txt.Text == "" &&
            note_Txt.Text == "" &&
            year_Txt.Text == "" &&
            bookTitle_Txt.Text == "" &&
            address_Txt.Text == "" &&
            volume_Txt.Text == "" &&
            editor_Txt.Text == "")
            {
                return true;
            }
            return false;
        }
        private void shomaretextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            // xaml.cs code
            if (!char.IsDigit(e.Text, e.Text.Length - 1))
                e.Handled = true;
        }
    }
}
