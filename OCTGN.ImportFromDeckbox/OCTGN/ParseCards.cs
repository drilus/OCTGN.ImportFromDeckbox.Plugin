using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;

namespace OCTGN.ImportFromDeckbox.OCTGN
{
    /// <summary>
    /// Parses the cards from plain text.
    /// </summary>
    public class ParseCards
    {
        /// <summary>
        /// Parses the specified card text.
        /// </summary>
        /// <param name="inputText">The input text.</param>
        /// <param name="allCards">All cards.</param>
        /// <returns></returns>
        /// <exception cref="System.InvalidOperationException">This exception will be thrown when the input text couldn't be matched.</exception>
        public static IEnumerable<CardData> Parse(
            string inputText,
            IEnumerable<CardData> allCards)
        {
            var result = new List<CardData>();

            if (string.IsNullOrEmpty(inputText))
            {
                return result;
            }

            var regex = new Regex(
                RegularExpressions.AnalyzeCards,
                RegexOptions.CultureInvariant | RegexOptions.IgnoreCase | RegexOptions.IgnorePatternWhitespace | RegexOptions.Multiline | RegexOptions.Singleline);

            var match = regex.Match(inputText);
            if (!match.Success)
            {
                throw new InvalidOperationException(Localization.ParseErrorGeneral);
            }

            var numberGroups = match.Groups["Number"].Captures;
            var cardGroups = match.Groups["Card"].Captures;

            if (numberGroups.Count != cardGroups.Count)
            {
                var details = string.Format(
                    CultureInfo.CurrentUICulture,
                    Localization.ParseErrorLineMismatch,
                    numberGroups.Count,
                    cardGroups.Count);

                throw new InvalidOperationException(details);
            }

            for (int index = 0; index < numberGroups.Count; ++index)
            {
                var card = new CardData()
                {
                    Name = cardGroups[index].Value.ToString().Trim(),
                    Count = Convert.ToInt32(numberGroups[index].Value, CultureInfo.InvariantCulture),
                };

                var found = allCards.Where(c => c.Name.Equals(card.Name)).FirstOrDefault();
                if (found != null)
                {
                    card.CardType = found.CardType;
                }

                result.Add(card);
            }

            return result.OrderBy(c => c.CardType).ThenBy(c => c.Name).ToList();
        }
    }
}