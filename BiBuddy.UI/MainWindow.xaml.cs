using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
using BibTeXLibrary;
using BiBuddy.Entities.Concrete;
using Bibuddy.DataAccess.Abstract;
using Bibuddy.DataAccess.Core.DI.Ninject;
using Bibuddy.DataAccess.Concrete.Dapper;
using Bibuddy.DataAccess.Core.Utility;
using Bibuddy.DataAccess.Core.Parser;
using BiBuddy.UI.ViewModel;

namespace BiBuddy.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        


        private readonly IArticleDal _articleService;
        private readonly IBookDal _bookService;
        private readonly IBookletDal _bookletService;
        private readonly IConferenceDal _conferenceService;
        private readonly IInbookDal _inbookService;
        private readonly IIncollectionDal _incollectionService;
        private readonly IManualDal _manualService;

        public MainWindow()
        {
            _articleService = InstanceFactory.GetInstance<DapperArticleDal>();
            _bookService = InstanceFactory.GetInstance<DapperBookDal>();
            _bookletService = InstanceFactory.GetInstance<DapperBookletDal>();
            _conferenceService = InstanceFactory.GetInstance<DapperConferenceDal>();
            _inbookService = InstanceFactory.GetInstance<DapperInbookDal>();
            _incollectionService = InstanceFactory.GetInstance<DapperIncollectionDal>();
            _manualService = InstanceFactory.GetInstance<DapperManualDal>();

            InitializeComponent();
            var menuRegister = new List<SubItem>();
            menuRegister.Add(new SubItem("Article"));
            menuRegister.Add(new SubItem("Book"));
            menuRegister.Add(new SubItem("Booklet"));
            menuRegister.Add(new SubItem("InBook"));
            menuRegister.Add(new SubItem("Conference"));
            menuRegister.Add(new SubItem("Manual"));
            menuRegister.Add(new SubItem("InCollection"));
            
            var item0 = new ItemMenu("Add Type", menuRegister, MaterialDesignThemes.Wpf.PackIconKind.ViewDashboard);
           

            Menu.Children.Add(new UserControlMenuItem(item0));
            DataGridMain.ItemsSource = _articleService.GetAllByAuthorOrTitleIfNotExist();

        }
        private void Exit_Btn_Click(object sender, RoutedEventArgs e)
        {
                System.Windows.Application.Current.Shutdown();
        }
        private void BtnPopupExit_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Are you sure to Exit ?", "BibBuddy Exit", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                Application.Current.Shutdown();
            }

        }
        void btn_Import_Click(object sender, RoutedEventArgs e)
        {
            //Please check before .exe version
            string filePath = string.Empty;
            string fileContent = string.Empty;

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            openFileDialog.Filter = "BibTeX files (*.bib)|*.bib";
            openFileDialog.FilterIndex = 2;
            openFileDialog.RestoreDirectory = true;


            if (openFileDialog.ShowDialog() == true)
            {
                string path = openFileDialog.FileName;
                //var parser = new BibParser(new StreamReader(path, Encoding.Default));
                var parser = new BetterBibtexParser(new StreamReader(path, Encoding.Default));
                var entries = parser.GetAllResult();



                foreach (var entry in entries)
                {
                    switch (entry.Type)
                    {
                        case "Article":
                            article _article = new article
                            {
                                author = entry.Author,
                                title = entry.Title,
                                journal = entry.Journal,
                                year = Convert.ToInt32(entry.Year),
                                pages = entry.Pages,
                                bibtexkey = entry.Key,
                                entrytype = GetEntryType.GetValueByEnum(GetEntryType.EntryType.Article),
                                volume = Convert.ToInt32(entry.Volume),
                                number = Convert.ToInt32(entry.Number),
                                month = Convert.ToInt32(entry.Mouth),
                                note = entry.Note,
                                
                            };
                            _articleService.Add(_article);
                            Console.WriteLine("Added To Db Article");
                            break;
                        case "Book":
                            book _book = new book
                            {
                                author = entry.Author,
                                title = entry.Title,
                                address = entry.Address,
                                publisher = entry.Publisher,
                                year = Convert.ToInt32(entry.Year),
                                entrytype = GetEntryType.GetValueByEnum(GetEntryType.EntryType.Book),
                                //publisher = entry.Editor,
                                series = Convert.ToInt32(entry.Series),
                                edition = Convert.ToInt32(entry.Edition),
                                month = Convert.ToInt32(entry.Mouth),
                                note = entry.Note,
                                //bibtexkey = entry.Key,
                                //url = entry.url,
                                volume = Convert.ToInt32(entry.Volume),
                            };
                            if (entry.Number == null )
                            {
                                // !!!!!!!!!!!!!!!!!!!
                            }
                            _bookService.Add(_book);
                            Console.WriteLine("Added To Db Book");
                            break;
                        case "Booklet":
                            booklet _booklet = new booklet
                            {
                                title = entry.Title,
                                author = entry.Author,
                                address = entry.Address,
                                month = Convert.ToInt32(entry.Mouth),
                                year = Convert.ToInt32(entry.Year),
                                note = entry.Note,
                                bibtexkey = entry.Key,
                                howpublished = entry.Howpublished,
                            };
                            _bookletService.Add(_booklet);
                            Console.WriteLine("Added To Db Booklet");
                            break;
                        case "Conference":
                            conference _conference = new conference
                            {
                                title = entry.Title,
                                author = entry.Author,
                                booktitle = entry.Booktitle,
                                year = Convert.ToInt32(entry.Year),
                                editor = entry.Editor,
                                volume = Convert.ToInt32(entry.Volume),
                                series = Convert.ToInt32(entry.Series),
                                pages = entry.Pages,
                                organization = entry.Organization,
                                address = entry.Address,
                                month = Convert.ToInt32(entry.Mouth),
                                publisher = entry.Publisher,
                                note = entry.Note,
                                bibtexkey = entry.Key,
                            };
                            _conferenceService.Add(_conference);
                            Console.WriteLine("Added To Db Conference");
                            break;
                        case "Inbook":
                            inbook _inbook = new inbook
                            {
                                title = entry.Title,
                                author = entry.Author,
                                chapter = Convert.ToInt32(entry.Chapter),
                                publisher = entry.Publisher,
                                year = Convert.ToInt32(entry.Year),
                                volume = Convert.ToInt32(entry.Volume),
                                series = Convert.ToInt32(entry.Series),
                                type = entry.Type,
                                address = entry.Address,
                                edition = Convert.ToInt32(entry.Edition),
                                month = Convert.ToInt32(entry.Mouth),
                                note = entry.Note,
                                bibtexkey = entry.Key,

                            };
                            _inbookService.Add(_inbook);
                            Console.WriteLine("Added To Db Inbook");
                            break;
                        case "Incollection":
                            incollection _incollection = new incollection
                            {
                                month = Convert.ToInt32(entry.Mouth),
                                note = entry.Note,
                                bibtexkey = entry.Key,
                                author = entry.Author,
                                title = entry.Title,
                                booktitle = entry.Booktitle,
                                publisher = entry.Publisher,
                                year = Convert.ToInt32(entry.Year),
                                volume = Convert.ToInt32(entry.Volume),
                                series = Convert.ToInt32(entry.Series),
                                type = entry.Type,
                                address = entry.Address,
                                edition = Convert.ToInt32(entry.Edition),
                                chapter = Convert.ToInt32(entry.Chapter),
                                pages = entry.Pages,
                                editor = entry.Editor,

                            };
                            _incollectionService.Add(_incollection);
                            Console.WriteLine("Added To Db Incollection");
                            break;
                        case "Manual":
                            manual _manual = new manual
                            {
                                title = entry.Title,
                                author = entry.Author,
                                organization = entry.Organization,
                                address = entry.Address,
                                edition = Convert.ToInt32(entry.Edition),
                                month = Convert.ToInt32(entry.Mouth),
                                note = entry.Note,
                                bibtexkey = entry.Key,
                                year = Convert.ToInt32(entry.Year),

                            };
                            _manualService.Add(_manual);
                            Console.WriteLine("Added To Db Manual");
                            break;
                        default:
                            break;
                           
                    }
                    
                    
                }

                Console.WriteLine("Articles : " + _articleService.Count());
                Console.WriteLine("Books :" + _bookService.Count());
                //Read the contents of the file into a stream
                var fileStream = openFileDialog.OpenFile();

                using (StreamReader reader = new StreamReader(fileStream))
                {
                    fileContent = reader.ReadToEnd();
                }

                DataGridMain.ItemsSource = _articleService.GetAllByAuthorOrTitleIfNotExist();
                DataGridMain.ItemsSource = _bookService.GetAllByAuthorOrTitleIfNotExist();

            }

        }
        private void ButtonCloseMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonOpenMenu.Visibility = Visibility.Visible;
            ButtonCloseMenu.Visibility = Visibility.Collapsed;
            logo_school.Visibility = Visibility.Collapsed;
        }
        private void ButtonOpenMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonOpenMenu.Visibility = Visibility.Collapsed;
            ButtonCloseMenu.Visibility = Visibility.Visible;
            logo_school.Visibility = Visibility.Visible;
        }
        private void btn_search_Click(object sender, RoutedEventArgs e)
        {
            if (search_textbox.Text.Length > 0)
            {
                MessageBox.Show(search_textbox.Text);
                search_textbox.Text = "";
            }
        }
        private void github_page_click(object sender, MouseButtonEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/cemlc/se302_bibuddy");
        }
        private void exit_btn_click(object sender, MouseButtonEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Are you sure to Exit ?", "BibBuddy Exit", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                Application.Current.Shutdown();
            }
        }
        private List<object> list = new List<object>();
        private void IsCheckedExport(object sender, RoutedEventArgs e)
        {

            list.Add(DataGridMain.SelectedItem);
        }

        private void btn_Export_Click(object sender, MouseButtonEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "BibTeX files (*.bib) |*.bib | HTML File (*.html) |*.html";
            saveFileDialog.OverwritePrompt = true;
            saveFileDialog.CreatePrompt = true;
            if (saveFileDialog.ShowDialog() == true)
            {
                StreamWriter save = new StreamWriter(saveFileDialog.FileName);
                save.WriteLine(ExportOperations.GetImportFile(list));
                save.Close();
            }
        }
    }
}
