using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows;
using OCTGN.ImportFromDeckbox.Util;

namespace OCTGN.ImportFromDeckbox
{
    /// <summary>
    /// The about box
    /// </summary>
    public partial class AboutBox : Window
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AboutBox" /> class.
        /// </summary>
        public AboutBox()
        {
            InitializeComponent();

            LoadVersionInformation();

            DataContext = this;
        }

        /// <summary>
        /// Gets or sets the version detail collection.
        /// </summary>
        /// <value>
        /// The version detail collection.
        /// </value>
        public IEnumerable<VersionDetails> VersionDetailCollection { get; set; }

        /// <summary>
        /// Gets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public string Description
        {
            get
            {
                return AssemblyInfo.AssemblyDescription;
            }
        }

        /// <summary>
        /// Gets the custom title.
        /// </summary>
        /// <value>
        /// The custom title.
        /// </value>
        public string CustomTitle
        {
            get
            {
                return Localization.AboutboxTitle + " - " + AssemblyInfo.AssemblyVersion;
            }
        }

        /// <summary>
        /// Loads the version information.
        /// </summary>
        public void LoadVersionInformation()
        {
            var document = EmbeddedResourceHelper.ReadEmbeddedResourceXDocument("VersionHistory.xml", Assembly.GetExecutingAssembly());

            var elements = document.Root.Elements("Version");
            VersionDetailCollection = elements.Select(e => new VersionDetails()
                                                               {
                                                                   Version = e.Attribute("Number").Value,
                                                                   Details = e.Value,
                                                               }).ToList();
        }
    }
}