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

namespace BiBuddy.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private readonly IArticleDal _articleService;
        private readonly IBookDal _bookService;
        public MainWindow()
        {
            _articleService = InstanceFactory.GetInstance<DapperArticleDal>();
            _bookService = InstanceFactory.GetInstance<DapperBookDal>();
            InitializeComponent();
            
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
            openFileDialog.InitialDirectory = @"c:\Users\ont_9\Desktop\ReadBibTex\ReadBibTex";
            openFileDialog.Filter = "BibTeX files (*.bib)|*.bib";
            openFileDialog.FilterIndex = 2;
            openFileDialog.RestoreDirectory = true;


            if (openFileDialog.ShowDialog() == true)
            {
                string path = openFileDialog.FileName;
                var parser = new BibParser(new StreamReader(path, Encoding.Default));
                var entries = parser.GetAllResult();



                foreach (var entry in entries)
                {
                    switch (entry.Type)
                    {
                        case "Article":
                            article _article = new article();
                            _article.author = entry.Author;
                            _article.title = entry.Title;
                            _article.journal = entry.Journal;
                            _article.year = Convert.ToInt32(entry.Year);
                            _article.pages = entry.Pages;
                            _article.bibtexkey = entry.Key;
                            _article.entrytype = GetEntryType.GetValueByEnum(GetEntryType.EntryType.Article);
                            _articleService.Add(_article);
                            MessageBox.Show("Added To Db Article");
                            break;
                        case "Book":
                            book _book = new book();
                            _book.author = entry.Author;
                            _book.title = entry.Title;
                            _book.address = entry.Address;
                            _book.bibtexkey = entry.Key;
                            _book.entrytype = GetEntryType.GetValueByEnum(GetEntryType.EntryType.Book);
                            _bookService.Add(_book);
                            MessageBox.Show("Added To Db Book");
                            break;
                        default:
                            break;
                            //if (entry.Type == "Article")
                            //{
                            //    article _article = new article();
                            //    _article.author = entry.Author;
                            //    _article.title = entry.Title;
                            //    _article.journal = entry.Journal;
                            //    _article.year = Convert.ToInt32(entry.Year);
                            //    _article.pages = entry.Pages;
                            //    articleService.Add(_article);
                            //}
                            //if (entry.Type == "Book")
                            //{
                            //    book _book = new book();
                            //    _book.author = entry.Author;
                            //    _book.title = entry.Title;
                            //    _book.journal = entry.Journal;
                            //    _book.year = Convert.ToInt32(entry.Year);
                            //    _book.address = entry.Address;
                            //}

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
        private void ListViewClickAddMenu(object sender, MouseButtonEventArgs e)
        {
            Window parentWindow = Window.GetWindow((DependencyObject)sender);
            if (parentWindow != null)
            {
                parentWindow.IsEnabled = false;
            }
            SelectEntry selectEntry = new SelectEntry();
            selectEntry.Show();
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
    }
}
