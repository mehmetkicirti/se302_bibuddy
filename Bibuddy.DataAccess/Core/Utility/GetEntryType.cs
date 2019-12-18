using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bibuddy.DataAccess.Core.Utility
{
    public class GetEntryType
    {
        public static string GetValueByEnum(EntryType entryType)
        {
            switch (entryType)
            {
                case EntryType.Article:
                    return "Article";
                case EntryType.Book:
                    return "Book";
                case EntryType.Booklet:
                    return "Booklet";
                case EntryType.Conference:
                    return "Conference";
                case EntryType.InBook:
                    return "InBook";
                case EntryType.InCollection:
                    return "InCollection";
                case EntryType.InProceedings:
                    return "InProceedings";
                case EntryType.Manual:
                    return "Manual";
                default:
                    return "Does not supported.";
            }
        }
        public enum EntryType
        {
            Article,
            Book,
            Booklet,
            Conference,
            InBook,
            InCollection,
            InProceedings,
            Manual
        }
    }
    
}
