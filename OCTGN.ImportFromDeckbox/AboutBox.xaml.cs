using System.Collections.Generic;
using System.Windows;

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

            // TODO MW 05.01.2013: Read version info from embedded xml
            var collection = new List<VersionDetails>();
            collection.Add(new VersionDetails() { Version = "1.0.0.0", Details = "Initial release." });
            VersionDetailCollection = collection;

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
    }
}