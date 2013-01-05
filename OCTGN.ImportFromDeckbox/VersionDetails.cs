using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OCTGN.ImportFromDeckbox
{
    /// <summary>
    /// This class contains a single version info.
    /// </summary>
    public sealed class VersionDetails
    {
        /// <summary>
        /// Gets or sets the version.
        /// </summary>
        /// <value>
        /// The version.
        /// </value>
        public string Version { get; set; }

        /// <summary>
        /// Gets or sets the details.
        /// </summary>
        /// <value>
        /// The details.
        /// </value>
        public string Details { get; set; }
    }
}
