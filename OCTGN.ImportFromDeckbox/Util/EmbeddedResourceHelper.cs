using System;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Xml.Linq;

namespace OCTGN.ImportFromDeckbox.Util
{
    /// <summary>
    /// Helper class to work with embedded resources.
    /// </summary>
    public static class EmbeddedResourceHelper
    {
        /// <summary>
        /// Reads the embedded resource string.
        /// </summary>
        /// <param name="resourceName">
        /// Name of the resource.
        /// <para>
        /// You don't need to fully qualify the resource name; This method will look up all available resource
        /// strings and tries to find a match using the <see cref="string.EndsWith(string,StringComparison)"/>
        /// method.
        /// </para>
        /// <para>
        /// This means, that you can call this method just with the file name of the embedded resource.
        /// </para>
        /// </param>
        /// <param name="assembly">The assembly which contains the embedded resource.</param>
        /// <returns>The embedded resource as string.</returns>
        /// <exception cref="System.InvalidOperationException">
        ///  This exception will be thrown when the resource could not be found.
        /// </exception>
        public static string ReadEmbeddedResourceString(string resourceName, Assembly assembly)
        {
            var nameList = assembly.GetManifestResourceNames();
            var embeddedResourceName = nameList.FirstOrDefault(n => n.EndsWith(resourceName, StringComparison.InvariantCultureIgnoreCase));

            if (string.IsNullOrEmpty(embeddedResourceName))
            {
                return null;
            }

            var result = string.Empty;

            using (var stream = assembly.GetManifestResourceStream(embeddedResourceName))
            {
                if (stream == null)
                {
                    var error = string.Format(
                        CultureInfo.InvariantCulture,
                        "Cannot find embedded resource '{0}({2})' in assembly '{1}'",
                        resourceName,
                        assembly.FullName,
                        embeddedResourceName);

                    throw new InvalidOperationException(error);
                }

                using (var sr = new StreamReader(stream))
                {
                    result = sr.ReadToEnd();
                }
            }

            return result;
        }

        /// <summary>
        /// Reads the embedded resource XDocument.
        /// </summary>
        /// <param name="resourceName">Name of the resource.</param>
        /// <param name="assembly">The assembly which contains the embedded resource.</param>
        /// <returns>The embedded resource as string.</returns>
        /// <exception cref="System.InvalidOperationException">
        ///  This exception will be thrown when the resource could not be found.
        /// </exception>
        public static XDocument ReadEmbeddedResourceXDocument(string resourceName, Assembly assembly)
        {
            return XDocument.Parse(ReadEmbeddedResourceString(resourceName, assembly));
        }
    }
}