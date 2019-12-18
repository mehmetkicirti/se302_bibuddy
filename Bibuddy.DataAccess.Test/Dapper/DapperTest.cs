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
            List<object> list=new List<object>();
            list.Add(_article);
            list.Add(_article);
            ExportOperations.GetImportFile(list,"Article");
            //var result = articleDal.GetAll();
            ////expected=> beklenen 
            //Assert.(1, result.Count);
        }

        
    }
}
