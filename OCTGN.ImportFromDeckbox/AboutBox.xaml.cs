using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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

            DataContext = this;
        }

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
