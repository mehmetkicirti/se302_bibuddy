using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Bibuddy.DataAccess.Core.Utility;
using BiBuddy.Entities.Concrete;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Bibuddy.DataAccess.Test.Dapper
{
    [TestClass]
    public class DapperTest
    {
        [TestMethod]
        public void ImportFile()
        {
            //DapperArticleDal articleDal = new DapperArticleDal();
            article _article = new article()
            {
                author="Deneme",
                bibtexkey="mehmetkicirti12",
                doi="deneme",
                journal="deneme2",
                month=1,
                year=1997,
                note="Testing of export file",
                pages="193--216",
                entrytype="article",
                title="deneme3"
            };

        /*    book _book = new book()
            {
                
                author = "deneme",
                bibtexkey = "myAwesomeKey",
                address = "denemeAddress",
                edition = 9,
                entrytype = "book",
                month = 13,
                note = "not",
                publisher = "asidkf",
                series = 5,
                title = "awesomeBook",
                url = "link",
                volume = 3,
                year = 1999
                
            
-            };*/

            book _book_ = new book();

            _book_.author = "deneme";
            _book_.bibtexkey = "myAwesomeKey";
            _book_.address = "denemeAddress";
            _book_.edition = 9;
            _book_.entrytype = "book";
            _book_.month = 13;
            _book_.note = "not";
            _book_.publisher = "asidkf";
            _book_.series = 5;
            _book_.title = "awesomeBook";
            _book_.url = "link";
            _book_.volume = 3;
            _book_.year = 1999;


            List<object> list=new List<object>();
            list.Add(_article);
            list.Add(_book_);
            ExportOperations.GetImportFile(list,"Article");
            //var result = articleDal.GetAll();
            ////expected=> beklenen 
            //Assert.(1, result.Count);
        }

        
    }
}
