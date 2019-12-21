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
    /// Interaction logic for BookletView.xaml
    /// </summary>
    public partial class BookletView : Window
    {
        private readonly IBookletDal _iBookletService;
        public BookletView()
        {
            _iBookletService = InstanceFactory.GetInstance<DapperBookletDal>();
            InitializeComponent();
            DataContext = new booklet();
        }

        private void Add_Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = Application.Current.Windows.OfType<MainWindow>().First();
            booklet _booklet = new booklet()
            {
                bibtexkey = bibtexKey_Txt.Text,
                title = title_Txt.Text,
                address= address_Txt.Text,
                author=author_Txt.Text,
                entrytype=GetEntryType.GetValueByEnum(GetEntryType.EntryType.Booklet),
                howpublished=howpublished_Txt.Text,
                year = year_Txt.Text != "" ? Convert.ToInt32(year_Txt.Text) : null as int?,
                month = month_Txt.Text != "" ? Convert.ToInt32(month_Txt.Text) : null as int?,
                note=note_Txt.Text
            };
            bool result = AllFieldEmpty();
            if (!result)
            {
                _iBookletService.Add(_booklet);
                SetFieldClear();
                UIElement parent = App.Current.MainWindow;
                parent.IsEnabled = true;
                main.DataGridMain.ItemsSource = _iBookletService.GetAll();
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
                    _iBookletService.Add(_booklet);
                    SetFieldClear();
                    main.DataGridMain.ItemsSource = _iBookletService.GetAll();
                    UIElement parent = App.Current.MainWindow;
                    parent.IsEnabled = true;
                    this.Close();
                    //do yes stuff
                }
            }
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
            address_Txt.Text = "";
            month_Txt.Text = "";
            note_Txt.Text = "";
            note_Txt.Text = "";
            year_Txt.Text = "";
        }
        public bool AllFieldEmpty()
        {
            if (bibtexKey_Txt.Text == "" &&
            title_Txt.Text == "" &&
            author_Txt.Text == "" &&
            howpublished_Txt.Text == "" &&
            month_Txt.Text == "" &&
            address_Txt.Text == "" &&
            note_Txt.Text == "" &&
            year_Txt.Text == ""
                )
            {
                return true;
            }
            return false;
        }
    }
}
