using System;
namespace BiBuddy.Entities.ValidationRules
{
    public class ErrorMessages
    {
        #region Messages

        #region Author
        public const string AuthorIsRequired = "Author text is a required field";
        public const string AuthorMinLength = "Author text length greater than 2";
        public const string AuthorMaxLength = "Author text length less than 75";
        #endregion

        #region Title
        public const string TitleMinLength = "Title text length greater than 2";
        public const string TitleMaxLength = "Title text length less than 250";
        public const string TitleIsRequired = "Title text is a required field";
        #endregion

        #region Journal
        public const string JournalMinLength = "Journal text length greater than 2";
        public const string JournalMaxLength = "Journal text length less than 250";
        public const string JournalIsRequired = "Journal text is a required field";
        #endregion


        #region Pages
        public const string PagesMinLength = "Pages text length greater than 2";
        public const string PagesMaxLength = "Pages text length less than 50";
        #endregion

        #region Year
        public static string YearRange = String.Format("Year is not valid. It should be between {0} and {1}", DateTime.MinValue.Year, DateTime.Now.Year);
        #endregion

        #region Month
        public static string MonthRange = String.Format("Month is not valid. It should be between {0} and {1}", 1, 12);
        #endregion

        #region Note
        public const string NoteMinLength = "Note text length greater than 2";
        public const string NoteMaxLength = "Note text length less than 250";
        #endregion

        #region HowPublished
        //public const string HowPublishedIsRequired = "HowPublised is a required field";
        public const string HowPublishedMinLength = "HowPublished text length greater than 2";
        public const string HowPublishedMaxLength = "HowPublished text length less than 50";
        #endregion

        #region Address
        //public const string AddressIsRequired = "Address is a required field";
        public const string AddressMinLength = "Address text length greater than 2";
        public const string AddressMaxLength = "Address text length less than 250";
        #endregion

        #region Organization
        public const string OrganizationMinLength = "Organization text length greater than 2";
        public const string OrganizationMaxLength = "Organization text length less than 150";
        #endregion

        #region ISBN

        public const string ISBNMaxLength = "ISBN text length less than 50";
        public const string ISBNMinLength = "ISBN text length greater than 2";
        #endregion

        #region  BookTitle
        public const string BookTitleMinLength = "BookTitle text length greater than 2";
        public const string BookTitleMaxLength = "BookTitle text length less than 90";
        #endregion

        #region Editor
        public const string EditorMaxLength = "Editor text length less than 80";
        public const string EditorMinLength = "Editor text length greater than 2";
        #endregion

        #region Publisher
        public const string PublisherMinLength = "Publisher text length greater than 2";
        public const string PublisherMaxLength = "Publisher text length less than 150";
        #endregion




        #endregion
    }
}
