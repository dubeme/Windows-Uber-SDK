namespace Uwapi.Model
{
    /// <summary>
    /// Specifies the scope that the app needs.
    /// These values has to be in power of 2 so a BitWise or will work
    /// </summary>
    public enum UberAccessScope
    {
        /// <summary>
        /// Unknown scope.
        /// </summary>
        Unknown = 0,
        /// <summary>
        /// Access to the users profile.
        /// </summary>
        Profile = 1,
        /// <summary>
        /// Access to the users history.
        /// </summary>
        History = 2
    }
}