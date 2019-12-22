using Bibuddy.DataAccess.Abstract;
using Bibuddy.DataAccess.Concrete.Dapper;
using Bibuddy.DataAccess.Core.DI.Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bibuddy.DataAccess.Core.Utility
{
    public class GetEntryType
    {
        private static IArticleDal _articleService = InstanceFactory.GetInstance<DapperArticleDal>();
        private static IBookDal _bookService = InstanceFactory.GetInstance<DapperBookDal>();
        private static IBookletDal _bookletService = InstanceFactory.GetInstance<DapperBookletDal>();
        private static IInbookDal _inbookService = InstanceFactory.GetInstance<DapperInbookDal>();
        private static IIncollectionDal _incollectionService = InstanceFactory.GetInstance<DapperIncollectionDal>();
        private static IManualDal _manualService = InstanceFactory.GetInstance<DapperManualDal>();
        private static IConferenceDal _conferenceService = InstanceFactory.GetInstance<DapperConferenceDal>();
        
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
        public static List<object> GetAllByTypes(string filter=null)
        {
            List<object> list = new List<object>();
            foreach (var article in _articleService.GetAll(filter))
            {
                list.Add(article);
            }
            foreach (var book in _bookService.GetAll(filter))
            {
                list.Add(book);
            }
            foreach (var booklet in _bookletService.GetAll(filter))
            {
                list.Add(booklet);
            }
            foreach (var conference in _conferenceService.GetAll(filter))
            {
                list.Add(conference);
            }
            foreach (var incollection in _incollectionService.GetAll(filter))
            {
                list.Add(incollection);
            }
            foreach (var manual in _manualService.GetAll(filter))
            {
                list.Add(manual);
            }
            foreach (var inbook in _inbookService.GetAll(filter))
            {
                list.Add(inbook);
            }
            return list;
        }
    }

}
