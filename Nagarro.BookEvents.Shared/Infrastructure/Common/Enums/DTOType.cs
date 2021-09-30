namespace Nagarro.BookEvents.Shared
{
    /// <summary>
    /// Data Transfer Objects
    /// </summary>
    public enum DTOType
    {
        /// <summary>
        /// Undefined DTO (Default)
        /// </summary>
        Undefined = 0,

        [QualifiedTypeName("Nagarro.BookEvents.DTOModel.dll", "Nagarro.BookEvents.DTOModel.UserDTO")]
        UserDTO = 1,

        [QualifiedTypeName("Nagarro.BookEvents.DTOModel.dll", "Nagarro.BookEvents.DTOModel.EventDTO")]
        EventDTO = 2,

        [QualifiedTypeName("Nagarro.BookEvents.DTOModel.dll", "Nagarro.BookEvents.DTOModel.InvitesDTO")]
        InvitesDTO =3,

        [QualifiedTypeName("Nagarro.BookEvents.DTOModel.dll", "Nagarro.BookEvents.DTOModel.CommentsDTO")]
        CommentsDTO = 4
    }
}
