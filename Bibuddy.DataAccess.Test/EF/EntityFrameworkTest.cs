using System;
using Bibuddy.DataAccess.Concrete;
using Bibuddy.DataAccess.DatabaseContext.Sqlite;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Bibuddy.DataAccess.Test.EF
{
    [TestClass]
    public class EntityFrameworkTest
    {
        [TestMethod]
        public void Get_list_all_articles_return()
        {
            DArticleDal articleDal = new DArticleDal(new SqliteContext());
            var result = articleDal.GetAll();
            //expected=> beklenen 
            Assert.AreEqual(1,result.Count);
        }

        [TestMethod]
        public void Get_All_with_parameter()
        {
            DArticleDal articleDal= new DArticleDal(new SqliteContext());
            var result = articleDal.GetAll(x => x.author.Contains("D"));
            Assert.AreEqual(1,result.Count);
        }
    }
}
