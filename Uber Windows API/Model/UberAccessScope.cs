namespace Uwapi.Model
{
    /// <summary>
    /// Specifies the scope that the app needs.
    /// These values has to be in power of 2 so a BitWise or will work
    /// </summary>
    public enum UberAccessScope
    {
        Unknown = 0,
        Profile = 1,
        History = 2
    }
}