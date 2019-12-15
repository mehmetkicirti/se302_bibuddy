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
using Bibuddy.Business.Abstract;
using Bibuddy.Business.DI.Ninject;
using Bibuddy.Business.Concrete;
using BiBuddy.Entities.Concrete;

namespace BiBuddy.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

       // private readonly IBookService bookService = InstanceFactory.GetInstance<BookManager>();
        public MainWindow()
        {
            InitializeComponent();
            help.Text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Phasellus fermentum eros ut lorem dapibus pharetra. Etiam sit amet lectus dapibus, " +
                "congue augue sed, scelerisque diam. Aliquam pharetra risus mauris, non convallis orci placerat sodales. Cras quis urna vitae magna varius ornare. Praesent " +
                "aliquet luctus magna, id aliquam purus pretium ut. Etiam laoreet orci quis risus varius, non volutpat quam gravida. Vestibulum sed ultricies ex, at gravida " +
                "augue. Donec commodo ullamcorper tempus. Ut quis lacinia nunc. Fusce consectetur aliquam lectus at maximus. Integer pretium ultricies placerat. Quisque risus " +
                "magna, cursus sed ultricies vel, convallis nec risus. Integer consectetur sem vitae enim scelerisque convallis. Donec nulla nisl, pulvinar eget sodales et, " +
                "accumsan sed mauris. Vivamus et turpis tortor. Mauris vitae nulla suscipit, imperdiet tellus et, pellentesque massa. Suspendisse at fringilla urna. " +
                "Pellentesque non risus ligula. Quisque faucibus urna sed eros pulvinar, hendrerit finibus elit tempus. Morbi dignissim, urna et iaculis rhoncus, ipsum mi " +
                "laoreet neque, posuere bibendum arcu augue sit amet arcu.";
        }

        private void searchBib(object sender, RoutedEventArgs e)
        {
            d1.Visibility = Visibility.Collapsed;
            s3.Visibility = Visibility.Collapsed;
            s1.Visibility = Visibility.Visible;
        }

        private void BackClickAN(object sender, RoutedEventArgs e)
        {
            d1.Visibility = Visibility.Visible;
            s3.Visibility = Visibility.Visible;
            s1.Visibility = Visibility.Collapsed;
        }

        private void HelpClick(object sender, RoutedEventArgs e)
        {
            d1.Visibility = Visibility.Collapsed;
            s3.Visibility = Visibility.Collapsed;
            s2.Visibility = Visibility.Visible;
        }

        private void BackClickH(object sender, RoutedEventArgs e)
        {
            d1.Visibility = Visibility.Visible;
            s3.Visibility = Visibility.Visible;
            s2.Visibility = Visibility.Collapsed;
        }

        private void ArticleClick(object sender, RoutedEventArgs e)
        {
            AddPanels addP = new AddPanels();
            addP.Show();
            addP.sPanelArticleTxB.Visibility = Visibility.Visible;
            addP.sPanelArticleTBx.Visibility = Visibility.Visible;
        }

        private void ConferenceClick(object sender, RoutedEventArgs e)
        {
            AddPanels addP = new AddPanels();
            addP.Show();
            addP.sPanelConferenceTxB.Visibility = Visibility.Visible;
            addP.sPanelConferenceTBx.Visibility = Visibility.Visible;
        }

        private void BookletClick(object sender, RoutedEventArgs e)
        {
            AddPanels addP = new AddPanels();
            addP.Show();
            addP.sPanelBookletTxB.Visibility = Visibility.Visible;
            addP.sPanelBookletTBx.Visibility = Visibility.Visible;
        }

        private void BookClick(object sender, RoutedEventArgs e)
        {
            AddPanels addP = new AddPanels();
            addP.Show();
            addP.sPanelBookTxB.Visibility = Visibility.Visible;
            addP.sPanelBookTBx.Visibility = Visibility.Visible;
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {

        }
        private void Exit(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Are you sure to Exit ?", "BiBuddy Exit", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                System.Windows.Application.Current.Shutdown();
            }
        }

        private void IncollectionClick(object sender, RoutedEventArgs e)
        {
            AddPanels addP = new AddPanels();
            addP.Show();
            addP.sPanelIncollectionTxB.Visibility = Visibility.Visible;
            addP.sPanelIncollectionTBx.Visibility = Visibility.Visible;
        }

        private void InbookClick(object sender, RoutedEventArgs e)
        {
            AddPanels addP = new AddPanels();
            addP.Show();
            addP.sPanelInbookTxB.Visibility = Visibility.Visible;
            addP.sPanelInbookTBx.Visibility = Visibility.Visible;
        }

        private void ManuelClick(object sender, RoutedEventArgs e)
        {
            AddPanels addP = new AddPanels();
            addP.Show();
            addP.sPanelManualTxB.Visibility = Visibility.Visible;
            addP.sPanelManualTBx.Visibility = Visibility.Visible;
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

                book _book = new book();

                foreach( var entry in entries)
                {
                    _book.author = entry.Author;
                    //bookService.Add(_book);
                }

                
                
                //Read the contents of the file into a stream
                var fileStream = openFileDialog.OpenFile();

                using (StreamReader reader = new StreamReader(fileStream))
                {
                    fileContent = reader.ReadToEnd();
                }
            }
           
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
