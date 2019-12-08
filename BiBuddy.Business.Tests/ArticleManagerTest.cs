using Bibuddy.Business.Concrete;
using Bibuddy.DataAccess.Abstract;
using Bibuddy.DataAccess.DatabaseContext.Sqlite;
using BiBuddy.Entities.Concrete;
using FluentValidation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace BiBuddy.Business.Tests
{
    [TestClass]
    public class ArticleManagerTest
    {
        //BeklenenException => Validation Hatası olması gerektigini söyledik.
        [ExpectedException(typeof(ValidationException))]
        [TestMethod]
        public void Article_Either_valid_or_not_check()
        {
            Mock<IArticleDal> mock = new Mock<IArticleDal>();
            ArticleManager articleManager = new ArticleManager(mock.Object,new UnitOfWork<SqliteContext>(new SqliteContext()));
            articleManager.Add(new article()
            {
                author = "Deneme",
                title = "Dneeme",
                journal = "Dneme",
                year = 2020,
                month = 13
            });
        }
    }
}
