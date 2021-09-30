namespace Nagarro.BookEvents.Shared
{
    /// <summary>
    /// Business Domain Component Type
    /// </summary>
    public enum BDCType
    {
        /// <summary>
        /// Undefined BDC (Default)
        /// </summary>
        Undefined = 0,

        [QualifiedTypeName("Nagarro.BookEvents.Business.dll", "Nagarro.BookEvents.Business.UserBDC")]
        UserBDC = 1,

        [QualifiedTypeName("Nagarro.BookEvents.Business.dll", "Nagarro.BookEvents.Business.EventBDC")]
        EventBDC = 2,

        [QualifiedTypeName("Nagarro.BookEvents.Business.dll", "Nagarro.BookEvents.Business.InvitesBDC")]
        InvitesBDC = 3,

        [QualifiedTypeName("Nagarro.BookEvents.Business.dll", "Nagarro.BookEvents.Business.CommentsBDC")]
        CommentsBDC = 4

    }
}
