using System.Windows.Forms;

namespace OCTGN.ImportFromDeckbox
{
    using Octgn.Data;
    using Octgn.Library.Plugin;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    /// <summary>
    /// The import from Deckbox.org plugin
    /// </summary>
    public class ImportDeckFromDeckboxPlugin : IDeckBuilderPlugin
    {
        /// <summary>
        /// Menu items to add for the plugin.
        /// </summary>
        public IEnumerable<IPluginMenuItem> MenuItems
        {
            get
            {
                // Add your menu items here.
                return new List<IPluginMenuItem> { new PluginMenuItem() };
            }
        }

        /// <summary>
        /// Happens when the Deck Editor is opened.
        /// </summary>
        /// <param name="games">Game repository.</param>
        public void OnLoad(GamesRepository games)
        {
            // I'm showing a message box, but don't do this, unless it's for updates or something...but don't do it every time as it pisses people off.
            // MessageBox.Show("Hello!");
        }

        /// <summary>
        /// Plugin ID
        /// </summary>
        public Guid Id
        {
            get
            {
                // All plugins are required to have a unique GUID
                // http://www.guidgenerator.com/online-guid-generator.aspx
                return Guid.Parse("66818e8c-12e6-4f4f-b40a-1f5c2081bf99");
            }
        }

        /// <summary>
        /// Name of the plugin
        /// </summary>
        public string Name
        {
            get
            {
                return Localization.PluginName;
            }
        }

        /// <summary>
        /// Version of the plugin.
        /// </summary>
        public Version Version
        {
            get
            {
                // Version of the plugin.
                // This code will pull the version from the assembly.
                return Assembly.GetCallingAssembly().GetName().Version;
            }
        }

        /// <summary>
        /// Required minimum version of OCTGN for this plugin.
        /// </summary>
        public Version RequiredByOctgnVersion
        {
            get
            {
                // Don't allow this plugin to be used in any version less than 3.0.1.26
                return Version.Parse("3.0.1.26");
            }
        }
    }

    /// <summary>
    /// The plugin menu item
    /// </summary>
    public class PluginMenuItem : IPluginMenuItem
    {
        /// <summary>
        /// Name to display for the menu item.
        /// </summary>
        public string Name
        {
            get
            {
                return Localization.PluginMenuItem;
            }
        }

        /// <summary>
        /// This happens when the menu item is clicked.
        /// </summary>
        /// <param name="pluginController"></param>
        public void OnClick(IDeckBuilderPluginController pluginController)
        {
            // WHI: e1e11562-efce-4379-9701-534f9717391f

            // Find the first game with cards in it.
            var game = pluginController.Games.Games.FirstOrDefault(x => x.SelectCards(null).Rows.Count > 0);
            if (game == null)
            {
                MessageBox.Show("No Games Installed?!?!?");
                return;
            }

            // TODO: Select game in GUI

            // Before we make a deck, we need to make sure we load the correct game for the deck.
            pluginController.SetLoadedGame(game);

            var window = new MainWindow(new MainViewModel(pluginController));
            window.ShowDialog();
        }
    }
}