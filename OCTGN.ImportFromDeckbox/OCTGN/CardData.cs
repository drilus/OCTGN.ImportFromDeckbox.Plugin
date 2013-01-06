namespace OCTGN.ImportFromDeckbox.OCTGN
{
    /// <summary>
    /// This class contains the card data read from the SQLite database.
    /// </summary>
    public sealed class CardData
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        /// <value>
        /// The id.
        /// </value>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the count.
        /// </summary>
        /// <value>
        /// The count.
        /// </value>
        public int Count { get; set; }

        /// <summary>
        /// Gets or sets the game id.
        /// </summary>
        /// <value>
        /// The game id.
        /// </value>
        public string GameId { get; set; }

        /// <summary>
        /// Gets or sets the card type.
        /// </summary>
        /// <value>
        /// The card type.
        /// </value>
        public string CardType { get; set; }
    }
}