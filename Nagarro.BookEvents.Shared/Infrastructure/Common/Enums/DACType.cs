namespace Nagarro.BookEvents.Shared
{
    /// <summary>
    /// Data Access Component Type
    /// </summary>
    public enum DACType
    {
        /// <summary>
        /// Undefined DAC (Default)
        /// </summary>
        Undefined = 0,

        [QualifiedTypeName("Nagarro.BookEvents.Data.dll", "Nagarro.BookEvents.Data.UserDAC")]
        UserDAC = 1,

        [QualifiedTypeName("Nagarro.BookEvents.Data.dll", "Nagarro.BookEvents.Data.EventDAC")]
        EventDAC = 2,

        [QualifiedTypeName("Nagarro.BookEvents.Data.dll", "Nagarro.BookEvents.Data.InvitesDAC")]
        InvitesDAC = 3,

        [QualifiedTypeName("Nagarro.BookEvents.Data.dll", "Nagarro.BookEvents.Data.CommentsDAC")]
        CommentsDAC = 4,

    }
}
