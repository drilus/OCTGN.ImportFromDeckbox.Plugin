using Octgn.Data;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCTGN.ImportFromDeckbox.OCTGN
{
    /// <summary>
    /// Extracts cards from the regex matched cards for the new deck.
    /// </summary>
    public class ExtractCards
    {
        /// <summary>
        /// Matches the cards.
        /// </summary>
        /// <param name="octgnGame">The octgn game.</param>
        /// <param name="cardModels">The card models.</param>
        /// <param name="octgnCards">The octgn cards.</param>
        /// <param name="parsedCards">The parsed cards.</param>
        /// <returns>A collectoin of matched cards.</returns>
        /// <exception cref="System.InvalidOperationException">
        /// This exception will be thrown when cards cannot be matched.
        /// </exception>
        public static IEnumerable<Deck.Element> MatchCards(
            Game octgnGame,
            IEnumerable<CardModel> cardModels,
            IEnumerable<CardData> octgnCards,
            IEnumerable<CardData> parsedCards)
        {
            var result = new List<Deck.Element>();
            var errorCards = new StringBuilder();

            foreach (var parsedCard in parsedCards)
            {
                var trimmedName = parsedCard.Name.Trim();
                var found = octgnCards.FirstOrDefault(c => c.Name.Trim().Equals(trimmedName, StringComparison.OrdinalIgnoreCase));
                if (found == null)
                {
                    errorCards.AppendLine(parsedCard.Name);
                }
                else
                {
                    var card = cardModels.FirstOrDefault(c => c.Id.ToString().Equals(found.Id));
                    result.Add(new Deck.Element()
                    {
                        Card = card,
                        Quantity = (byte)parsedCard.Count,
                    });
                }
            }

            if (!string.IsNullOrEmpty(errorCards.ToString()))
            {
                var details = new InvalidOperationException(Localization.ErrorCannotFindCards + Environment.NewLine + errorCards.ToString());
                details.Data.Add("Cards", result);

                throw details;
            }

            return result;
        }
    }
}
