using System.Linq;
using Octgn.Data;

namespace OCTGN.ImportFromDeckbox.OCTGN
{
    /// <summary>
    /// Extends the <see cref="CardModel"/> class.
    /// </summary>
    public static class CardModelExtension
    {
        /// <summary>
        /// Gets the type of the card.
        /// </summary>
        /// <param name="instanceToExtend">The instance to extend.</param>
        /// <returns>
        /// The card type as string or <see cref="string.Empty"/> when the
        /// type cannot be determined.
        /// </returns>
        public static string GetCardType(this CardModel instanceToExtend)
        {
            var found = instanceToExtend.Properties.Where(p => p.Key.Equals("Type")).FirstOrDefault();
            if (!string.IsNullOrEmpty(found.Key))
            {
                return found.Value.ToString();
            }

            return string.Empty;
        }

        /// <summary>
        /// Determines whether the has card has the specified typeor not.
        /// </summary>
        /// <param name="instanceToExtend">The instance to extend.</param>
        /// <param name="cardTypeToLookup">The card type to lookup.</param>
        /// <returns>
        ///   <c>true</c> if the card has the specified type; otherwise, <c>false</c>.
        /// </returns>
        public static bool HasCardType(this CardModel instanceToExtend, string cardTypeToLookup)
        {
            var found = instanceToExtend.Properties.Where(p => p.Key.Equals("Type")).FirstOrDefault();
            if (!string.IsNullOrEmpty(found.Key))
            {
                return found.Value.ToString().Equals(cardTypeToLookup);
            }

            return string.IsNullOrEmpty(cardTypeToLookup);
        }
    }
}