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
using System.Reflection;

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
            Export_Btn.IsEnabled = false;
            Delete_Btn.IsEnabled = false;
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
            DataGridMain.ItemsSource = GetAllByTypes();

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
                            article _article = new article();
                            _article.doi = entry.Doi;
                            _article.author = entry.Author;
                            _article.title = entry.Title;
                            _article.pages = entry.Pages;
                            _article.bibtexkey = entry.Key;
                            _article.entrytype = GetEntryType.GetValueByEnum(GetEntryType.EntryType.Article);
                            _article.note = entry.Note;
                            _article.year = entry.Year != "" ? Convert.ToInt32(entry.Year) : null as int?;
                            _article.number = entry.Number != "" ? Convert.ToInt32(entry.Number) : null as int?;
                            _article.month = entry.Month != "" ? Convert.ToInt32(entry.Month) : null as int?;
                            _article.volume = entry.Volume != "" ? Convert.ToInt32(entry.Volume) : null as int?;
                            _article.journal = entry.Journal;
                            _articleService.Add(_article);
                            Console.WriteLine("Added To Db Article");
                            break;
                        case "Book":
                            book _book = new book
                            {
                                bibtexkey = entry.Key,
                                title = entry.Title,
                                address = entry.Address,
                                publisher = entry.Publisher,
                                year = entry.Year != "" ? Convert.ToInt32(entry.Year) : null as int?,
                                entrytype = GetEntryType.GetValueByEnum(GetEntryType.EntryType.Book),
                                url=entry.URL,
                                series = entry.Series != "" ? Convert.ToInt32(entry.Series):null as int?,
                                edition =entry.Edition != "" ? Convert.ToInt32(entry.Edition):null as int?,
                                month = entry.Month != "" ? Convert.ToInt32(entry.Month) : null as int?,
                                note = entry.Note,
                                volume = entry.Volume != "" ? Convert.ToInt32(entry.Volume) : null as int?
                            };
                            if (entry.Author != "" && entry.Editor != "")
                                _book.author = entry.Author;
                            else if (entry.Author != "")
                                _book.author = entry.Author;
                            else
                                _book.author = entry.Editor;

                            // ----------------------------------------------------

                            if (entry.Volume != "" && entry.Number != "")
                                _book.volume = entry.Volume != "" ? Convert.ToInt32(entry.Volume) : null as int?;
                            else if (entry.Volume != "")
                                _book.volume = entry.Volume != "" ? Convert.ToInt32(entry.Volume) : null as int?;
                            else
                                _book.volume = entry.Number != "" ? Convert.ToInt32(entry.Number) : null as int?;

                            _bookService.Add(_book);
                            Console.WriteLine("Added To Db Book");
                            break;
                        case "Booklet":
                            booklet _booklet = new booklet
                            {
                                title = entry.Title,
                                author = entry.Author,
                                address = entry.Address,
                                month = entry.Month != "" ? Convert.ToInt32(entry.Month) : null as int?,
                                year = entry.Year != "" ? Convert.ToInt32(entry.Year) : null as int?,
                                note = entry.Note,
                                bibtexkey = entry.Key,
                                howpublished = entry.Howpublished,
                                entrytype=GetEntryType.GetValueByEnum(GetEntryType.EntryType.Booklet)
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
                                year = entry.Year != "" ? Convert.ToInt32(entry.Year) : null as int?,
                                editor = entry.Editor,
                                volume = entry.Volume != "" ? Convert.ToInt32(entry.Volume) : null as int?,
                                series = entry.Series != "" ? Convert.ToInt32(entry.Series) : null as int?,
                                pages = entry.Pages,
                                organization = entry.Organization,
                                address = entry.Address,
                                month = entry.Month != "" ? Convert.ToInt32(entry.Month) : null as int?,
                                publisher = entry.Publisher,
                                note = entry.Note,
                                bibtexkey = entry.Key,
                                entrytype = GetEntryType.GetValueByEnum(GetEntryType.EntryType.Conference)
                            };
                            // ----------------------------------------------------
                            if (entry.Volume != "" && entry.Number != "")
                                _conference.volume = entry.Volume != "" ? Convert.ToInt32(entry.Volume) : null as int?;
                            else if (entry.Volume != "")
                                _conference.volume = entry.Volume != "" ? Convert.ToInt32(entry.Volume) : null as int?;
                            else
                                _conference.volume = entry.Number != "" ? Convert.ToInt32(entry.Number) : null as int?;
                            // ----------------------------------------------------
                            _conferenceService.Add(_conference);
                            Console.WriteLine("Added To Db Conference");
                            break;
                        case "Inbook":
                            inbook _inbook = new inbook
                            {
                                title = entry.Title,
                                chapter = entry.Chapter != "" ? Convert.ToInt32(entry.Chapter) : null as int?,
                                publisher = entry.Publisher,
                                year = entry.Year != "" ? Convert.ToInt32(entry.Year) : null as int?,
                                series = entry.Series != "" ? Convert.ToInt32(entry.Series) : null as int?,
                                type = entry.Type,
                                address = entry.Address,
                                edition = entry.Edition != "" ? Convert.ToInt32(entry.Edition) : null as int?,
                                month = entry.Month != "" ? Convert.ToInt32(entry.Month) : null as int?,
                                note = entry.Note,
                                bibtexkey = entry.Key,
                                entrytype = GetEntryType.GetValueByEnum(GetEntryType.EntryType.InBook)
                            };
                            // -------------------------------------------------------
                            if (entry.Author != "" && entry.Editor != "")
                                _inbook.author = entry.Author;
                            else if (entry.Author != "")
                                _inbook.author = entry.Author;
                            else
                                _inbook.author = entry.Editor;
                            // -------------------------------------------------------
                            if (entry.Volume != "" && entry.Number != "")
                                _inbook.volume = entry.Volume != "" ? Convert.ToInt32(entry.Volume) : null as int?;
                            else if (entry.Volume != "")
                                _inbook.volume = entry.Volume != "" ? Convert.ToInt32(entry.Volume) : null as int?;
                            else
                                _inbook.volume = entry.Number != "" ? Convert.ToInt32(entry.Number) : null as int?;
                            // -------------------------------------------------------
                            _inbookService.Add(_inbook);
                            Console.WriteLine("Added To Db Inbook");
                            break;
                        case "Incollection":
                            incollection _incollection = new incollection
                            {
                                month = entry.Month != "" ? Convert.ToInt32(entry.Month) : null as int?,
                                note = entry.Note,
                                bibtexkey = entry.Key,
                                author = entry.Author,
                                title = entry.Title,
                                booktitle = entry.Booktitle,
                                publisher = entry.Publisher,
                                year = entry.Year != "" ? Convert.ToInt32(entry.Year) : null as int?,
                                volume = entry.Volume != "" ? Convert.ToInt32(entry.Volume) : null as int?,
                                series = entry.Series != "" ? Convert.ToInt32(entry.Series) : null as int?,
                                type = entry.Type,
                                address = entry.Address,
                                edition = entry.Edition != "" ? Convert.ToInt32(entry.Edition) : null as int?,
                                chapter = entry.Chapter != "" ? Convert.ToInt32(entry.Chapter) : null as int?,
                                pages = entry.Pages,
                                editor = entry.Editor,
                                entrytype = GetEntryType.GetValueByEnum(GetEntryType.EntryType.InCollection)
                            };
                            // -------------------------------------------------------
                            if (entry.Volume != "" && entry.Number != "")
                                _incollection.volume = entry.Volume != "" ? Convert.ToInt32(entry.Volume) : null as int?;
                            else if (entry.Volume != "")
                                _incollection.volume = entry.Volume != "" ? Convert.ToInt32(entry.Volume) : null as int?;
                            else
                                _incollection.volume = entry.Number != "" ? Convert.ToInt32(entry.Number) : null as int?;
                            // -------------------------------------------------------
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
                                edition = entry.Edition != "" ? Convert.ToInt32(entry.Edition) : null as int?,
                                month = entry.Month != "" ? Convert.ToInt32(entry.Month) : null as int?,
                                note = entry.Note,
                                bibtexkey = entry.Key,
                                year = entry.Year != "" ? Convert.ToInt32(entry.Year) : null as int?,
                                entrytype = GetEntryType.GetValueByEnum(GetEntryType.EntryType.Manual)
                            };
                            _manualService.Add(_manual);
                            Console.WriteLine("Added To Db Manual");
                            break;
                        default:
                            break;
                    }
                }

                DataGridMain.ItemsSource = GetAllByTypes();
                Console.WriteLine("Articles : " + _articleService.Count());
                Console.WriteLine("Books :" + _bookService.Count());
                //Read the contents of the file into a stream
                var fileStream = openFileDialog.OpenFile();

                using (StreamReader reader = new StreamReader(fileStream))
                {
                    fileContent = reader.ReadToEnd();
                }
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
            Export_Btn.IsEnabled = true;
            Delete_Btn.IsEnabled = true;
            list.Add(DataGridMain.SelectedItem);
        }
        private List<object> GetAllByTypes()
        {
            List<object> list = new List<object>();
            foreach (var article in _articleService.GetAll())
            {
                list.Add(article);
            }
            foreach (var book in _bookService.GetAll())
            {
                list.Add(book);
            }
            foreach (var booklet in _bookletService.GetAll())
            {
                list.Add(booklet);
            }
            foreach (var conference  in _conferenceService.GetAll())
            {
                list.Add(conference);
            }
            foreach (var incollection in _incollectionService.GetAll())
            {
                list.Add(incollection);
            }
            foreach (var manual in _manualService.GetAll())
            {
                list.Add(manual);
            }
            foreach (var inbook in _inbookService.GetAll())
            {
                list.Add(inbook);
            }
            return list;
        }
        private void btn_Export_Click(object sender, MouseButtonEventArgs e)
        {
            if (list.Count>0)
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "BibTeX files (*.bib) |*.bib | HTML File (*.html) |*.html";
                saveFileDialog.OverwritePrompt = true;
                saveFileDialog.CreatePrompt = true;
                if (saveFileDialog.ShowDialog() == true)
                {
                    if (saveFileDialog.Filter == ".bib")
                    {
                        StreamWriter save = new StreamWriter(saveFileDialog.FileName);
                        save.WriteLine(ExportOperations.GetImportFile(list));
                        save.Close();
                    }
                    else
                    {
                        StreamWriter save = new StreamWriter(saveFileDialog.FileName);
                        save.WriteLine(ExportOperations.getHTMLexport(list));
                        save.Close();
                        Console.WriteLine("html export alında");
                    }

                }
            }
            else
            {
                Export_Btn.IsEnabled = false;
            }
        }

        private void UnCheckedExport(object sender, RoutedEventArgs e)
        {
            list.Remove(DataGridMain.SelectedItem);
            if (list.Count > 0)
            {
                Export_Btn.IsEnabled = true;
                Delete_Btn.IsEnabled = true;
            }
            else if (list.Count <= 0)
            {
                Export_Btn.IsEnabled = false;
                Delete_Btn.IsEnabled = false;
            }
        }
        private void Btn_Delete_Click(object sender, MouseButtonEventArgs e)
        {
            
            if (list.Count>0)
            {
                Dictionary<string, int> getfieldName;
                foreach (object type in list)
                {
                    PropertyInfo[] fields = type.GetType().GetProperties();
                    switch (type.GetType().Name)
                    {
                        case "article":
                            getfieldName = new Dictionary<string, int>();
                            foreach (var field in fields)
                            {
                                if (field.Name == "ID")
                                {
                                    getfieldName.Add(field.Name, (int)field.GetValue(type));
                                    break;
                                }
                            }
                            _articleService.Delete(getfieldName["ID"]);
                            break;
                        case "book":
                            getfieldName = new Dictionary<string, int>();
                            foreach (var field in fields)
                            {
                                if (field.Name == "ID")
                                {
                                    getfieldName.Add(field.Name, (int)field.GetValue(type));
                                    break;
                                }
                            }
                            _bookService.Delete(getfieldName["ID"]);
                            break;
                        case "inbook":
                            getfieldName = new Dictionary<string, int>();
                            foreach (var field in fields)
                            {
                                if (field.Name == "ID")
                                {
                                    getfieldName.Add(field.Name, (int)field.GetValue(type));
                                    break;
                                }
                            }
                            _inbookService.Delete(getfieldName["ID"]);
                            break;
                        case "incollection":
                            getfieldName = new Dictionary<string, int>();
                            foreach (var field in fields)
                            {
                                if (field.Name == "ID")
                                {
                                    getfieldName.Add(field.Name, (int)field.GetValue(type));
                                    break;
                                }
                            }
                            _incollectionService.Delete(getfieldName["ID"]);
                            break;
                        case "manual":
                            getfieldName = new Dictionary<string, int>();
                            foreach (var field in fields)
                            {
                                if (field.Name == "ID")
                                {
                                    getfieldName.Add(field.Name, (int)field.GetValue(type));
                                    break;
                                }
                            }
                            _manualService.Delete(getfieldName["ID"]);
                            break;
                        case "booklet":
                            getfieldName = new Dictionary<string, int>();
                            foreach (var field in fields)
                            {
                                if (field.Name == "ID")
                                {
                                    getfieldName.Add(field.Name, (int)field.GetValue(type));
                                    break;
                                }
                            }
                            _bookletService.Delete(getfieldName["ID"]);
                            break;
                        case "conference":
                            getfieldName = new Dictionary<string, int>();
                            foreach (var field in fields)
                            {
                                if (field.Name == "ID")
                                {
                                    getfieldName.Add(field.Name, (int)field.GetValue(type));
                                    break;
                                }
                            }
                            _conferenceService.Delete(getfieldName["ID"]);
                            break;
                        default:
                            break;
                    }
                }
                list.Clear();
                Export_Btn.IsEnabled = false;
                Delete_Btn.IsEnabled = false;
                DataGridMain.ItemsSource=GetAllByTypes();
            }
            else if (list.Count <= 0)
            {
                Delete_Btn.IsEnabled = false;
            }
        }
    }
}
