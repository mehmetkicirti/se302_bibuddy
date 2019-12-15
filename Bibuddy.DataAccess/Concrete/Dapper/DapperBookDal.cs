using Bibuddy.DataAccess.Abstract;
using Bibuddy.DataAccess.DatabaseContext.Dapper;
using BiBuddy.Entities.Concrete;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Bibuddy.DataAccess.Concrete.Dapper
{
    public class DapperBookDal : IBookDal
    {
        private IDbConnection _iConnection;
        public DapperBookDal()
        {
            _iConnection = DapperDbContext.GetDbConnection();
        }
        public void Add(book entity)
        {
            _iConnection.ExecuteScalar<book>(
                 "INSERT INTO book (author, journal, month, note, address, edition, isbn, series, title, volume, year, bibtexkey) VALUES( @author, @journal, @month, @note, @address, @edition, @isbn, @series, @title, @volume, @year, @bibtexkey)", new
                 {
                     entity.author,
                     entity.journal,
                     entity.month,
                     entity.note,
                     entity.address,
                     entity.edition,
                     entity.isbn,
                     entity.series,
                     entity.title,
                     entity.volume,
                     entity.year,
                     entity.bibtexkey
                 });
        }

        public int Count()
        {
            string query = @"SELECT COUNT(ID) FROM book";
            int count = _iConnection.ExecuteScalar<int>(query);
            return count;
        }

        public void Delete(int ID)
        {
            throw new NotImplementedException();
        }

        public book Get(Expression<Func<book, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<book> GetAll(Expression<Func<book, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<book> GetAllByAuthorOrTitleIfNotExist(string author = null, string title = null)
        {
            throw new NotImplementedException();
        }

        public List<book> GetAllByYear(int? year)
        {
            throw new NotImplementedException();
        }

        public book GetByID(int ID)
        {
            throw new NotImplementedException();
        }

        public void Update(book entity)
        {
            throw new NotImplementedException();
        }
    }
}
