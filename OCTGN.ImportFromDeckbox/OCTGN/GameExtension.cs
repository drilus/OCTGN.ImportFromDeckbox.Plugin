using Octgn.Data;

namespace OCTGN.ImportFromDeckbox.OCTGN
{
    /// <summary>
    /// Extends the <see cref="Game"/> class.
    /// </summary>
    public static class GameExtension
    {
        /// <summary>
        /// Determines whether the given game is warhammer invasion.
        /// </summary>
        /// <param name="instanceToExtend">The instance to extend.</param>
        /// <returns>
        ///   <c>true</c> if the given game is warhammer invasion; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsWarhammerInvasion(this Game instanceToExtend)
        {
            return "e1e11562-efce-4379-9701-534f9717391f".Equals(instanceToExtend.Id.ToString());
        }
        
        /// <summary>
        /// Determines whether the given game is magic.
        /// </summary>
        /// <param name="instanceToExtend">The instance to extend.</param>
        /// <returns>
        ///   <c>true</c> if the given game is magic; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsMagic(this Game instanceToExtend)
        {
            return "a6c8d2e8-7cd8-11dd-8f94-e62b56d89593".Equals(instanceToExtend.Id.ToString());
        }
    }
}