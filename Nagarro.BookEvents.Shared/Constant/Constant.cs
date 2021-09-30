using System;

namespace Nagarro.BookEvents.Shared
{
    public static class Constant
    {
        public static string UserFailureResult = "Email id already exist";
        public static string EventFailureResult = "Event Not Deleted";
        public static string LoginFailureresult = "Invalid email or password";
        public static string EventValidationTitle = "Please enter title of your event";
        public static string EventValidationDate = "Please enter date of your event";
        public static string EventValidationLocation = "Please enter Location of your event";
        public static string EventValidationType = "Please enter Type of your event";
        public static string UserValidationEmail = "Please enter Valid Email";
        public static string UserValidationName = "Please enter your name";
        public static string UserValidationPasswordLength = "minimum length of password must be 5";
        public static string UserValidationPasswordChar = "Atleast One Special Character in Password";
        public static string EntityConversionException1 = "Entity type '{0}' must match with type specified in EntityMappingAttribute on type '{1}' !";
        public static string EntityConversionException2 = "Only one EntityMappingAttribute can be applied on type '{0}' !";
        public static string MappingEntity = "Property '{0}' should have EntityPropertyMappingAttribute !";
        public static string WrongEmailOrPassword = "Wrong Email or Password";
    }
}
