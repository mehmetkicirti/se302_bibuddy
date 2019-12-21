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
                 "INSERT INTO book (author, entrytype, month, note, address, edition, url, series, title, volume, year, bibtexkey) VALUES( @author, @entrytype, @month, @note, @address, @edition, @url, @series, @title, @volume, @year, @bibtexkey)", new
                 {
                     entity.author,
                     entity.entrytype,
                     entity.month,
                     entity.note,
                     entity.address,
                     entity.edition,
                     entity.url,
                     entity.series,
                     entity.title,
                     entity.volume,
                     entity.year,
                     entity.bibtexkey
                 });
        }

        public void AddByImport(book entity)
        {
            _iConnection.ExecuteScalar<book>(
                "INSERT INTO book (author, entrytype, month, note, address, edition, url, series, title, volume, year, bibtexkey) VALUES( @author, @entrytype, @month, @note, @address, @edition, @url, @series, @title, @volume, @year, @bibtexkey)", new
                {
                    entity.author,
                    entity.entrytype,
                    entity.month,
                    entity.note,
                    entity.address,
                    entity.edition,
                    entity.url,
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
            string q = $"Delete from book where ID = @ID";
            _iConnection.Execute(q,
                new
                {
                    ID
                });
        }

        public book Get(string filter = null)
        {
            throw new NotImplementedException();
        }

        public List<book> GetAll(string filter = null)
        {

            if (filter != null)
            {
                filter = filter.ToLower();
            }
            string query = "Select * from book";
            List<book> listvalues = _iConnection.Query<book>(query).ToList();
                return listvalues;
            
            //if (filter.StartsWith("K. Oğuz") || filter.StartsWith("K. Oguz") || filter.StartsWith("K. oğuz") || filter.StartsWith("K. oguz") || filter.StartsWith("k. oguz"))
            //{
            //    filter = "Kaya Oğuz".ToLower();
            //    return listvalues.Where(x => x.author.ToLower().Contains(filter)).ToList();
            //}
            //if (filter.Contains(".") && filter.Contains(".*"))
            //{
            //    int index = filter.IndexOf(".*");
            //    filter = filter.Substring(0, index);
            //    return listvalues.Where(x => x.author.ToLower().Contains(filter)
            //       || x.bibtexkey.ToLower().Contains(filter)
            //       || (x.doi == null ? x.doi.Contains("") : x.doi.ToLower().Contains(filter))
            //       || x.entrytype.ToLower().Contains(filter)
            //       || x.journal.ToLower().Contains(filter)
            //       || x.title.ToLower().Contains(filter)).ToList();
            //}
            //return listvalues.Where(
            //        x => x.author.ToLower().Contains(filter)
            //        || x.bibtexkey.ToLower().Contains(filter)
            //        || x.doi.ToLower().Contains(filter)
            //        || x.entrytype.ToLower().Contains(filter)
            //        || x.journal.ToLower().Contains(filter)
            //        || x.month.Value.Equals(Convert.ToInt32(filter))
            //        || x.year.Value.Equals(Convert.ToInt32(filter))
            //        ).ToList();
        }

        public List<book> GetAllByAuthorOrTitleIfNotExist(string author = null, string title = null)
        {
            string query = @"Select * from book";
            if (!String.IsNullOrEmpty(author) || !String.IsNullOrEmpty(title))
            {
                query += " Where ";
                if (!String.IsNullOrEmpty(author) && !String.IsNullOrEmpty(title))
                {
                    query += "author LIKE @value and title LIKE @value2";
                    return _iConnection.Query<book>(query, new { value = "%" + author + "%", value2 = "%" + title + "%" }).ToList();
                }
                else if (!String.IsNullOrEmpty(author))
                {
                    query += "author LIKE @value";
                    return _iConnection.Query<book>(query, new { value = "%" + author + "%" }).ToList();
                }
                else
                {
                    query += "title LIKE @value";
                    return _iConnection.Query<book>(query, new { value = "%" + title + "%" }).ToList();
                }
            }
            else
            {
                return _iConnection.Query<book>(query).ToList();
            }
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
