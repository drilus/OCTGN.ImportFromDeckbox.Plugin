using Octgn.Data;
using System.Collections.Generic;

namespace OCTGN.ImportFromDeckbox.OCTGN
{
    /// <summary>
    /// Reads card data from the SQLite database.
    /// </summary>
    public class ReadCardData
    {
        /// <summary>
        /// Reads the specified card models.
        /// </summary>
        /// <param name="gameId">The game id.</param>
        /// <param name="cardModels">The card models.</param>
        /// <returns></returns>
        public IEnumerable<CardData> Read(
            string gameId,
            IEnumerable<CardModel> cardModels)
        {
            var result = new List<CardData>();

            
            foreach (var item in cardModels)
            {
                var card = new CardData()
                {
                    Id = item.Id.ToString(),
                    Name = item.Name,
                    GameId = gameId,
                };

                result.Add(card);
            }

            return result;
        }
    }
}