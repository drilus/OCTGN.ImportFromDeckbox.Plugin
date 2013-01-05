using Octgn.Data;
using Octgn.Library.Plugin;
using OCTGN.ImportFromDeckbox.OCTGN;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Web;
using System.Windows;

namespace OCTGN.ImportFromDeckbox
{
    /// <summary>
    /// The main view model.
    /// </summary>
    public class MainViewModel : INotifyPropertyChanged
    {
        private bool _isBusy = false;
        private Game _selectedGame;
        private CardModel _selectedWarhammerInvasionCapital;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainViewModel" /> class.
        /// </summary>
        /// <param name="pluginController">The plugin controller.</param>
        public MainViewModel(IDeckBuilderPluginController pluginController)
        {
            PluginController = pluginController;

            GameDefinitions = PluginController.Games.Games.ToList();
            SelectedGame = GameDefinitions.FirstOrDefault();
        }

        /// <summary>
        /// Occurs when a property has changed.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Gets the card count.
        /// </summary>
        /// <value>
        /// The card count.
        /// </value>
        public int CardCount
        {
            get
            {
                return Cards != null ? Cards.Count() : 0;
            }
        }

        /// <summary>
        /// Gets the cards.
        /// </summary>
        /// <value>
        /// The cards.
        /// </value>
        public IEnumerable<CardData> Cards { get; private set; }

        /// <summary>
        /// Gets a value indicating whether this instance has error.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance has error; otherwise, <c>false</c>.
        /// </value>
        public bool HasError
        {
            get
            {
                return !string.IsNullOrEmpty(ErrorDetails);
            }
        }

        /// <summary>
        /// Gets or sets the error details.
        /// </summary>
        /// <value>
        /// The error details.
        /// </value>
        public string ErrorDetails { get; set; }

        /// <summary>
        /// Gets or sets the error hint.
        /// </summary>
        /// <value>
        /// The error hint.
        /// </value>
        public string ErrorHint { get; set; }

        /// <summary>
        /// Gets the game definitions.
        /// </summary>
        /// <value>
        /// The game definitions.
        /// </value>
        public IEnumerable<Game> GameDefinitions { get; private set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is busy.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is busy; otherwise, <c>false</c>.
        /// </value>
        public bool IsBusy
        {
            get { return _isBusy; }
            set
            {
                _isBusy = value;
                FirePropertyChanged("IsBusy");
            }
        }

        /// <summary>
        /// Gets a value indicating whether the current loaded game is warhammer invasion.
        /// </summary>
        /// <value>
        /// <c>true</c> if the current loaded game is warhammer invasion; otherwise, <c>false</c>.
        /// </value>
        public bool IsWarhammerInvasion
        {
            get
            {
                return _selectedGame != null ? _selectedGame.IsWarhammerInvasion() : false;
            }
        }

        /// <summary>
        /// Gets all cards of selected game.
        /// </summary>
        /// <value>
        /// All cards of selected game.
        /// </value>
        public IEnumerable<CardModel> AllCardsOfSelectedGame { get; private set; }

        /// <summary>
        /// Gets the matched cards.
        /// </summary>
        /// <value>
        /// The matched cards.
        /// </value>
        public IEnumerable<Deck.Element> MatchedCards { get; private set; }

        /// <summary>
        /// Gets the matched card summary.
        /// </summary>
        /// <value>
        /// The matched card summary.
        /// </value>
        public string MatchedCardSummary
        {
            get
            {
                if (MatchedCards != null)
                {
                    var quantity = MatchedCards.Select(c => (int)c.Quantity).Sum();

                    var matchedSummary = string.Format(
                        CultureInfo.InvariantCulture,
                        "{0} ({1} Distinct)",
                        quantity,
                        MatchedCards.Count());

                    return matchedSummary;
                }
                else
                {
                    return "---";
                }
            }
        }

        /// <summary>
        /// Gets the parsed card count.
        /// </summary>
        /// <value>
        /// The parsed card count.
        /// </value>
        public int ParsedCardCount
        {
            get
            {
                return ParsedCards != null ? ParsedCards.Count() : 0;
            }
        }

        /// <summary>
        /// Gets the parsed cards.
        /// </summary>
        /// <value>
        /// The parsed cards.
        /// </value>
        public IEnumerable<CardData> ParsedCards { get; private set; }

        /// <summary>
        /// Gets the plugin controller.
        /// </summary>
        /// <value>
        /// The plugin controller.
        /// </value>
        public IDeckBuilderPluginController PluginController { get; private set; }

        /// <summary>
        /// Gets or sets the selected game.
        /// </summary>
        /// <value>
        /// The selected game.
        /// </value>
        public Game SelectedGame
        {
            get
            {
                return _selectedGame;
            }

            set
            {
                try
                {
                    IsBusy = true;

                    _selectedGame = value;

                    FirePropertyChanged("SelectedGame");
                    FirePropertyChanged("IsWarhammerInvasion");

                    AllCardsOfSelectedGame = _selectedGame.SelectCardModels(null).ToList();

                    UpdateCapitals();

                    ReadCards();
                    ParseCardsFromText();
                }
                finally
                {
                    IsBusy = false;
                }
            }
        }

        /// <summary>
        /// Gets or sets the selected warhammer invasion capital.
        /// </summary>
        /// <value>
        /// The selected warhammer invasion capital.
        /// </value>
        public CardModel SelectedWarhammerInvasionCapital
        {
            get
            {
                return _selectedWarhammerInvasionCapital;
            }

            set
            {
                _selectedWarhammerInvasionCapital = value;

                Properties.Settings.Default.LastCapital = value != null ? value.Name : string.Empty;
                Properties.Settings.Default.Save();
                FirePropertyChanged("SelectedWarhammerInvasionCapital");
            }
        }

        /// <summary>
        /// Gets or sets the text to parse.
        /// </summary>
        /// <value>
        /// The text to parse.
        /// </value>
        public string TextToParse
        {
            get
            {
                return Properties.Settings.Default.TextToParse;
            }

            set
            {
                Properties.Settings.Default.TextToParse = value;
                Properties.Settings.Default.Save();

                FirePropertyChanged("TextToParse");

                ParseCardsFromText();
            }
        }

        /// <summary>
        /// Gets the warhammer invasion capitals.
        /// </summary>
        /// <value>
        /// The warhammer invasion capitals.
        /// </value>
        public IEnumerable<CardModel> WarhammerInvasionCapitals { get; private set; }

        /// <summary>
        /// Copies to forum.
        /// </summary>
        public void CopyToForum()
        {
            var forum = new StringBuilder();

            foreach (var matched in MatchedCards)
            {
                var link = string.Format(
                    CultureInfo.InvariantCulture,
                    "{0} [url=http://deckbox.org/whi/{1}]{2}[/url]",
                    matched.Quantity,
                    HttpUtility.UrlEncode(matched.Card.Name),
                    matched.Card.Name);

                forum.AppendLine(link);
            }

            Clipboard.SetText(forum.ToString());
        }

        /// <summary>
        /// Fires the property changed.
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        public void FirePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        /// <summary>
        /// Parses the cards from text.
        /// </summary>
        public void ParseCardsFromText()
        {
            try
            {
                ErrorDetails = string.Empty;
                ErrorHint = string.Empty;

                ParsedCards = ParseCards.Parse(TextToParse);
                MatchedCards = ExtractCards.MatchCards(
                    SelectedGame,
                    AllCardsOfSelectedGame,
                    Cards,
                    ParsedCards);
            }
            catch (Exception error)
            {
                ErrorDetails = error.Message;
                ErrorHint = Localization.ErrorHintParseError;
            }
            finally
            {
                FirePropertyChanged("ParsedCards");
                FirePropertyChanged("ParsedCardCount");
                FirePropertyChanged("ErrorHint");
                FirePropertyChanged("HasError");
                FirePropertyChanged("ErrorDetails");
                FirePropertyChanged("MatchedCardSummary");
            }
        }

        /// <summary>
        /// Reads all available cards from OCTGN.
        /// </summary>
        public void ReadCards()
        {
            var reader = new ReadCardData();
            Cards = reader.Read(SelectedGame.Id.ToString(), AllCardsOfSelectedGame);

            FirePropertyChanged("Cards");
            FirePropertyChanged("CardCount");
        }

        /// <summary>
        /// Saves the deck.
        /// </summary>
        public void SaveDeck()
        {
            var deck = new Deck(SelectedGame);

            // It's weird, but this is how you add a card.
            var sectionIndex = 0;

            if (IsWarhammerInvasion)
            {
                // Warhammer invasion: Cards are stored in section 1
                sectionIndex = 1;

                // Add selected capital here
                if (_selectedWarhammerInvasionCapital != null)
                {
                    deck.Sections[0].Cards.Add(new Deck.Element()
                        {
                            Quantity = 1,
                            Card = _selectedWarhammerInvasionCapital,
                        });
                }
            }

            foreach (var matched in MatchedCards)
            {
                deck.Sections[sectionIndex].Cards.Add(matched);
            }

            // Load that mother.
            PluginController.LoadDeck(deck);
        }

        /// <summary>
        /// Pastes from clipboard.
        /// </summary>
        public void PasteFromClipboard()
        {
            var clipboard = Clipboard.GetText();
            if (!string.IsNullOrEmpty(clipboard))
            {
                TextToParse = clipboard;
            }
        }

        /// <summary>
        /// Updates the capitals.
        /// </summary>
        private void UpdateCapitals()
        {
            if (_selectedGame.IsWarhammerInvasion()
                && (WarhammerInvasionCapitals == null || !WarhammerInvasionCapitals.Any()))
            {
                var condition = "[Name] LIKE '%Capital'";

                var cardModels = SelectedGame.SelectCardModels(new[] { condition });
                var count = cardModels.Count();

                var capitals = new List<CardModel>();
                for (int index = 0; index < count; ++index)
                {
                    capitals.Add(cardModels.ElementAt(index));
                }

                WarhammerInvasionCapitals = capitals;

                if (!string.IsNullOrEmpty(Properties.Settings.Default.LastCapital)
                    && WarhammerInvasionCapitals.Any())
                {
                    SelectedWarhammerInvasionCapital = WarhammerInvasionCapitals
                        .Where(c => c.Name.Equals(Properties.Settings.Default.LastCapital))
                        .FirstOrDefault();
                }

                if (null == SelectedWarhammerInvasionCapital)
                {
                    SelectedWarhammerInvasionCapital = WarhammerInvasionCapitals.First();
                }
            }
        }
    }
}