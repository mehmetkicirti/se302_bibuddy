using System;
namespace BiBuddy.Entities.Utility
{
    public class ErrorMessages
    {
        #region Messages
        public const string AuthorMinLength = "Author text length greater than 2";
        public const string AuthorMaxLength = "Author text length less than 75";
        public const string TitleMinLength = "Title text length greater than 2";
        public const string TitleMaxLength = "Title text length less than 250";
        public const string JournalMinLength = "Journal text length greater than 2";
        public const string JournalMaxLength = "Journal text length less than 250";
        public const string PagesMinLength = "Pages text length greater than 2";
        public const string PagesMaxLength = "Pages text length less than 50";
        public static string YearRange = String.Format("Year is not valid. It should be between {0} and {1}", 1800, DateTime.Now.Year);
        public static string MonthRange = String.Format("Month is not valid. It should be between {0} and {1}", 0, 11);
        public const string NoteMinLength = "Note text length greater than 2";
        public const string NoteMaxLength = "Note text length less than 250";
        public const string AddressMinLength = "Address text length greater than 2";
        public const string AddressMaxLength = "Address text length less than 250";
        public const string ISBNMaxLength = "ISBN text length less than 50";
        public const string ISBNMinLength = "ISBN text length greater than 2";
        public const string HowPublishedMinLength = "HowPublished text length greater than 2";
        public const string HowPublishedMaxLength = "HowPublished text length less than 50";
        public const string BookTitleMinLength = "BookTitle text length greater than 2";
        public const string BookTitleMaxLength = "BookTitle text length less than 90";
        public const string EditorMaxLength = "Editor text length less than 80";
        public const string EditorMinLength = "Editor text length greater than 2";
        public const string OrganizationMinLength = "Organization text length greater than 2";
        public const string OrganizationMaxLength = "Organization text length less than 150";
        public const string PublisherMinLength = "Publisher text length greater than 2";
        public const string PublisherMaxLength = "Publisher text length less than 150"; 
        #endregion
    }
}
