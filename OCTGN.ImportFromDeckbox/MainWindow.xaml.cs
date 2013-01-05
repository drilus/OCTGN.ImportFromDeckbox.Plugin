using System;
using System.Reflection;
using System.Windows;

namespace OCTGN.ImportFromDeckbox
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindow" /> class.
        /// </summary>
        /// <param name="viewModel">The view model.</param>
        public MainWindow(MainViewModel viewModel)
        {
            InitializeComponent();
            ViewModel = viewModel;
            this.DataContext = ViewModel;

            Title = string.Format(
                "DeckBox to OCTGN Converter - {0}",
                Assembly.GetExecutingAssembly().GetName().Version.ToString());
        }

        /// <summary>
        /// Gets the view model.
        /// </summary>
        /// <value>
        /// The view model.
        /// </value>
        public MainViewModel ViewModel { get; private set; }

        /// <summary>
        /// Called when the about button was clicked.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs" /> instance containing the event data.</param>
        private void OnAboutClick(object sender, RoutedEventArgs e)
        {
            var about = new AboutBox();
            about.Owner = this;
            about.ShowDialog();
        }

        /// <summary>
        /// Called when the copy to forum button was clicked.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs" /> instance containing the event data.</param>
        private void OnCopyToForum(object sender, RoutedEventArgs e)
        {
            ViewModel.CopyToForum();
        }

        /// <summary>
        /// Called when the cards are loaded.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs" /> instance containing the event data.</param>
        private void OnLoadCards(object sender, RoutedEventArgs e)
        {
            try
            {
                ViewModel.ReadCards();
            }
            catch (Exception error)
            {
                MessageBox.Show(
                    this,
                    error.Message,
                    string.Empty);
            }
        }

        /// <summary>
        /// Called when the deck shall be saved.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs" /> instance containing the event data.</param>
        private void OnParseAndSave(object sender, RoutedEventArgs e)
        {
            try
            {
                ViewModel.SaveDeck();
                Close();
            }
            catch (Exception error)
            {
                MessageBox.Show(
                    this,
                    error.Message,
                    string.Empty);
            }
        }

        /// <summary>
        /// Called when we shall paste from clipboard.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs" /> instance containing the event data.</param>
        private void OnPasteFromClipboard(object sender, RoutedEventArgs e)
        {
            ViewModel.PasteFromClipboard();
        }
    }
}