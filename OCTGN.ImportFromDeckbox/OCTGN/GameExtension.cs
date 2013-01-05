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
    }
}