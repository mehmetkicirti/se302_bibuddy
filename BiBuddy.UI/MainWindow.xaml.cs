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
            DataGridMain.ItemsSource = GetEntryType.GetAllByTypes();

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
                try
                {
                    string path = openFileDialog.FileName;
                    //var parser = new BibParser(new StreamReader(path, Encoding.Default));
                    var parser = new BetterBibtexParser(new StreamReader(path, Encoding.Default));
                    var entries = parser.GetAllResult();

                    foreach (var entry in entries)
                    {
                        switch (entry.Type.ToLower())
                        {
                            case "article":
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
                            case "book":
                                book _book = new book
                                {
                                    bibtexkey = entry.Key,
                                    title = entry.Title,
                                    address = entry.Address,
                                    publisher = entry.Publisher,
                                    year = entry.Year != "" ? Convert.ToInt32(entry.Year) : null as int?,
                                    entrytype = GetEntryType.GetValueByEnum(GetEntryType.EntryType.Book),
                                    url = entry.URL,
                                    series = entry.Series != "" ? Convert.ToInt32(entry.Series) : null as int?,
                                    edition = entry.Edition != "" ? Convert.ToInt32(entry.Edition) : null as int?,
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
                            case "booklet":
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
                                    entrytype = GetEntryType.GetValueByEnum(GetEntryType.EntryType.Booklet)
                                };
                                _bookletService.Add(_booklet);
                                Console.WriteLine("Added To Db Booklet");
                                break;
                            case "conference":
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
                            case "inbook":
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
                            case "incollection":
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
                            case "manual":
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
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                DataGridMain.ItemsSource = GetEntryType.GetAllByTypes();
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
            var result = GetEntryType.GetAllByTypes(search_textbox.Text);
            DataGridMain.ItemsSource = result;
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

        private void btn_Export_Click(object sender, MouseButtonEventArgs e)
        {
            if (list.Count > 0)
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "BibTeX files (*.bib) |*.bib | HTML File (*.html) |*.html";
                saveFileDialog.OverwritePrompt = true;
                saveFileDialog.CreatePrompt = true;
                if (saveFileDialog.ShowDialog() == true)
                {
                    string[] arr = System.IO.Path.GetFileName(saveFileDialog.FileName).Split(new string[] { "//" }, StringSplitOptions.None);
                    if (arr[0].Contains(".bib"))
                    {
                        StreamWriter save = new StreamWriter(saveFileDialog.FileName);
                        save.WriteLine(ExportOperations.GetImportFile(list));
                        save.Close();
                        MessageBox.Show(System.IO.Path.GetFileName(saveFileDialog.FileName) + "has been created.");
                    }
                    else
                    {
                        StreamWriter save = new StreamWriter(saveFileDialog.FileName);
                        save.WriteLine(ExportOperations.getHTMLexport(list));
                        save.Close();
                        Console.WriteLine("html export alında");
                        MessageBox.Show(System.IO.Path.GetFileName(saveFileDialog.FileName) + "has been created.");
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

            if (list.Count > 0)
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
                DataGridMain.ItemsSource = GetEntryType.GetAllByTypes();
            }
            else if (list.Count <= 0)
            {
                Delete_Btn.IsEnabled = false;
            }
        }
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            Dictionary<string, string> getFieldName = new Dictionary<string, string>();
            object SaveRow = new object();
            SaveRow = ArticleDetails.DataContext;
            PropertyInfo[] newFields = SaveRow.GetType().GetProperties();
            article _article = new article();
            foreach (var field in newFields)
            {
                if (field.Name == "month")
                {
                    if (field.GetValue(SaveRow) != null)
                    {
                        getFieldName.Add(field.Name, field.GetValue(SaveRow).ToString());
                        continue;
                    }
                    getFieldName.Add(field.Name, "");
                    continue;
                }
                if (field.Name == "year")
                {
                    if (field.GetValue(SaveRow) != null)
                    {
                        getFieldName.Add(field.Name, field.GetValue(SaveRow).ToString());
                        continue;
                    }
                    getFieldName.Add(field.Name, "");
                    continue;
                }
                if (field.Name == "number")
                {
                    if (field.GetValue(SaveRow) != null)
                    {
                        getFieldName.Add(field.Name, field.GetValue(SaveRow).ToString());
                        continue;
                    }
                    getFieldName.Add(field.Name, "");
                    continue;
                }
                if (field.Name == "volume")
                {
                    if (field.GetValue(SaveRow) != null)
                    {
                        getFieldName.Add(field.Name, field.GetValue(SaveRow).ToString());
                        continue;
                    }
                    getFieldName.Add(field.Name, "");
                    continue;
                }
                if (field.Name == "Item")
                    continue;
                if (field.Name == "ID")
                {
                    if (field.GetValue(SaveRow) != null)
                    {
                        getFieldName.Add(field.Name, field.GetValue(SaveRow).ToString());
                        continue;
                    }
                    getFieldName.Add(field.Name, "");
                    continue;
                }
                if (field.Name == "bibtexkey")
                {
                    if (field.GetValue(SaveRow) != null)
                    {
                        getFieldName.Add(field.Name, field.GetValue(SaveRow).ToString());
                        continue;
                    }
                    getFieldName.Add(field.Name, "");
                    continue;
                }
                getFieldName.Add(field.Name, field.GetValue(SaveRow).ToString());
            }
            _article.ID = Convert.ToInt32(getFieldName["ID"]);
            _article.year =getFieldName["year"]==null || getFieldName["year"] == "" ? null as int? : Convert.ToInt32(getFieldName["year"]);
            _article.month = getFieldName["month"] == null || getFieldName["month"] == "" ? null as int? : Convert.ToInt32(getFieldName["month"]);
            _article.journal = getFieldName["journal"];
            _article.note = getFieldName["note"];
            _article.number = getFieldName["number"] == null || getFieldName["number"] == "" ? null as int? : Convert.ToInt32(getFieldName["number"]);
            _article.pages = getFieldName["pages"];
            _article.volume= getFieldName["volume"] == null || getFieldName["volume"] == "" ? null as int? : Convert.ToInt32(getFieldName["volume"]);
            _article.title = getFieldName["title"];
            _article.entrytype = getFieldName["entrytype"];
            _article.author = getFieldName["author"];
            _article.doi = getFieldName["doi"];
            _article.bibtexkey = getFieldName["bibtexkey"];
            _articleService.Update(_article);
            DataGridMain.ItemsSource = GetEntryType.GetAllByTypes();
            MessageBox.Show("Article : " + _article.title + " updated");
        }

        private void Row_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            EditGrid_Book.Visibility = Visibility.Collapsed;
            EditGrid_Article.Visibility = Visibility.Collapsed;
            EditGrid_Booklet.Visibility = Visibility.Collapsed;
            EditGrid_Con.Visibility = Visibility.Collapsed;

            object EditRow = new object();

            EditRow = DataGridMain.SelectedItem;


            PropertyInfo[] infos = EditRow.GetType().GetProperties();

            Dictionary<string, int> getFieldName = new Dictionary<string, int>();

            switch (EditRow.GetType().Name)
            {
                case "article":


                    foreach (var info in infos)
                    {
                        if (info.Name == "ID")
                        {
                            getFieldName.Add(info.Name, (int)info.GetValue(EditRow));

                            break;
                        }

                    }

                    ArticleDetails.DataContext = _articleService.GetByID(getFieldName["ID"]);
                    EditGrid_Article.Visibility = Visibility.Visible;

                    break;
                case "book":

                    foreach (var info in infos)
                    {
                        if (info.Name == "ID")
                        {
                            getFieldName.Add(info.Name, (int)info.GetValue(EditRow));
                            Console.WriteLine(getFieldName["ID"]);
                            break;
                        }
                    }

                    BookDetails.DataContext = _bookService.GetByID(getFieldName["ID"]);
                    EditGrid_Book.Visibility = Visibility.Visible;
                    break;


                case "booklet":

                    foreach (var info in infos)
                    {
                        if (info.Name == "ID")
                        {
                            getFieldName.Add(info.Name, (int)info.GetValue(EditRow));
                            Console.WriteLine(getFieldName["ID"]);
                            break;
                        }
                    }

                    BookletDetails.DataContext = _bookletService.GetByID(getFieldName["ID"]);
                    EditGrid_Booklet.Visibility = Visibility.Visible;
                    break;

                case "conference":

                    foreach (var info in infos)
                    {
                        if (info.Name == "ID")
                        {
                            getFieldName.Add(info.Name, (int)info.GetValue(EditRow));
                            Console.WriteLine(getFieldName["ID"]);
                            break;
                        }
                    }

                    ConDetails.DataContext = _conferenceService.GetByID(getFieldName["ID"]);
                    EditGrid_Con.Visibility = Visibility.Visible;
                    break;




            }


        }

        private void SaveButtonB_Click(object sender, RoutedEventArgs e)
        {
            object SaveRowB = new object();
            SaveRowB = BookDetails.DataContext;
            if (SaveRowB != null)
            {
                PropertyInfo[] newFieldsB = SaveRowB.GetType().GetProperties();
                book _book = new book();
                foreach (var field in newFieldsB)
                {
                    if (field.Name == "entrytype")
                    {
                        _book.entrytype = (string)field.GetValue(SaveRowB);

                    }
                    if (field.Name == "author")
                    {
                        _book.author = (string)field.GetValue(SaveRowB);

                    }
                    if (field.Name == "title")
                    {
                        _book.title = (string)field.GetValue(SaveRowB);
                    }
                    if (field.Name == "publisher")
                    {
                        _book.publisher = (string)field.GetValue(SaveRowB);
                    }
                    if (field.Name == "year")
                    {
                        _book.year = (int)field.GetValue(SaveRowB);
                    }
                    if (field.Name == "volume")
                    {
                        _book.volume = (int)field.GetValue(SaveRowB);
                    }
                    if (field.Name == "ID")
                    {
                        _book.ID = (int)field.GetValue(SaveRowB);

                    }
                    if (field.Name == "month")
                    {
                        _book.month = (int)field.GetValue(SaveRowB);
                    }
                    if (field.Name == "series")
                    {
                        _book.series = (int)field.GetValue(SaveRowB);
                    }
                    if (field.Name == "address")
                    {
                        _book.address = (string)field.GetValue(SaveRowB);
                    }
                    if (field.Name == "edition")
                    {
                        _book.edition = (int)field.GetValue(SaveRowB);
                    }
                    if (field.Name == "url")
                    {
                        _book.url = (string)field.GetValue(SaveRowB);
                    }
                    if (field.Name == "bibtexkey")
                    {
                        _book.bibtexkey = (string)field.GetValue(SaveRowB);
                    }
                    if (field.Name == "note")
                    {
                        _book.note = (string)field.GetValue(SaveRowB);
                    }

                }
                _bookService.Update(_book);
                DataGridMain.ItemsSource = GetEntryType.GetAllByTypes();
                MessageBox.Show("Book : " + _book.title + " updated");
            }

        }


        private void SaveButtonBlt_Click(object sender, RoutedEventArgs e)
        {
            object SaveRowB = new object();
            SaveRowB = BookletDetails.DataContext;
            if (SaveRowB != null)
            {
                PropertyInfo[] newFieldsB = SaveRowB.GetType().GetProperties();
                booklet _booklet = new booklet();
                foreach (var field in newFieldsB)
                {
                    if (field.Name == "entrytype")
                    {
                        _booklet.entrytype = (string)field.GetValue(SaveRowB);

                    }
                    if (field.Name == "author")
                    {
                        _booklet.author = (string)field.GetValue(SaveRowB);

                    }
                    if (field.Name == "title")
                    {
                        _booklet.title = (string)field.GetValue(SaveRowB);
                    }
                    if (field.Name == "year")
                    {
                        _booklet.year = (int)field.GetValue(SaveRowB);
                    }
                    if (field.Name == "ID")
                    {
                        _booklet.ID = (int)field.GetValue(SaveRowB);

                    }
                    if (field.Name == "bibtexkey")
                    {
                        _booklet.bibtexkey = (string)field.GetValue(SaveRowB);
                    }
                    if (field.Name == "address")
                    {
                        _booklet.address = (string)field.GetValue(SaveRowB);
                    }
                    if (field.Name == "note")
                    {
                        _booklet.note = (string)field.GetValue(SaveRowB);
                    }
                    if (field.Name == "howpublished")
                    {
                        _booklet.howpublished = (string)field.GetValue(SaveRowB);
                    }



                }
                _bookletService.Update(_booklet);
                DataGridMain.ItemsSource = GetEntryType.GetAllByTypes();
                MessageBox.Show("Booklet : " + _booklet.title + " updated");

            }
        }

        private void SaveButtonCon_Click(object sender, RoutedEventArgs e)
        {
            object SaveRowB = new object();
            SaveRowB = ConDetails.DataContext;
            if (SaveRowB != null)
            {
                PropertyInfo[] newFieldsB = SaveRowB.GetType().GetProperties();
                conference _conference = new conference();

                foreach (var field in newFieldsB)
                {
                    if (field.Name == "entrytype")
                    {
                        _conference.entrytype = (string)field.GetValue(SaveRowB);

                    }
                    if (field.Name == "author")
                    {
                        _conference.author = (string)field.GetValue(SaveRowB);

                    }
                    if (field.Name == "title")
                    {
                        _conference.title = (string)field.GetValue(SaveRowB);
                    }
                    if (field.Name == "booktitle")
                    {
                        _conference.booktitle = (string)field.GetValue(SaveRowB);
                    }
                    if (field.Name == "year")
                    {
                        _conference.year = (int)field.GetValue(SaveRowB);
                    }
                    if (field.Name == "ID")
                    {
                        _conference.ID = (int)field.GetValue(SaveRowB);

                    }
                    if (field.Name == "month")
                    {
                        _conference.month = (int)field.GetValue(SaveRowB);
                    }
                    if (field.Name == "series")
                    {
                        _conference.series = (int)field.GetValue(SaveRowB);
                    }
                    if (field.Name == "pages")
                    {
                        _conference.pages = (string)field.GetValue(SaveRowB);
                    }
                    if (field.Name == "volume")
                    {
                        _conference.volume = (int)field.GetValue(SaveRowB);
                    }
                    if (field.Name == "address")
                    {
                        _conference.address = (string)field.GetValue(SaveRowB);
                    }
                    if (field.Name == "organization")
                    {
                        _conference.organization = (string)field.GetValue(SaveRowB);
                    }
                    if (field.Name == "publisher")
                    {
                        _conference.publisher = (string)field.GetValue(SaveRowB);
                    }
                    if (field.Name == "note")
                    {
                        _conference.note = (string)field.GetValue(SaveRowB);
                    }
                    if (field.Name == "bibtexkey")
                    {
                        _conference.bibtexkey = (string)field.GetValue(SaveRowB);
                    }


                }
                _conferenceService.Update(_conference);
                DataGridMain.ItemsSource = GetEntryType.GetAllByTypes();
                MessageBox.Show("Conference : " + _conference.title + " updated");

            }
        }
    }
}
