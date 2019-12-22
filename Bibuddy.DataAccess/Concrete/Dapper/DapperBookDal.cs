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
                 "INSERT INTO book (author, entrytype, month, note, address, edition, url, series, title, volume, year, bibtexkey, publisher) VALUES( @author, @entrytype, @month, @note, @address, @edition, @url, @series, @title, @volume, @year, @bibtexkey,@publisher)", new
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
                     entity.bibtexkey,
                     entity.publisher
                 });
        }
        public void Update(book entity)
        {
            _iConnection.ExecuteScalar<book>(
                "UPDATE book SET author=@author, publisher=@publisher, url=@url, entrytype=@entrytype, address=@address, edition=@edition ,bibtexkey=@bibtexkey," +
                "month=@month, note=@note, series=@series," +
                "title=@title, volume=@volume, year=@year where ID = @ID", new
                {
                    entity.series,
                    entity.entrytype,
                    entity.bibtexkey,
                    entity.author,
                    entity.publisher,
                    entity.edition,
                    entity.month,
                    entity.note,
                    entity.address,
                    entity.url,
                    entity.title,
                    entity.volume,
                    entity.year,
                    entity.ID
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
        public List<book> GetAll(string filter = null)
        {

            List<book> listvalues;
            string query = "Select * from book";
            if (filter != null)
            {
                filter = filter.ToLower();
            }
            if (String.IsNullOrEmpty(filter) || filter == "*")
            {
                listvalues = _iConnection.Query<book>(query).ToList();
                return listvalues;
            }
            if (filter.StartsWith("K. Oğuz") || filter.StartsWith("K. Oguz") || filter.StartsWith("K. oğuz") || filter.StartsWith("K. oguz") || filter.StartsWith("k. oguz"))
            {
                filter = "Kaya Oğuz".ToLower();
                query += " Where (year like @value) or (month like @value) or (CAST(volume as INTEGER) LIKE @value) or lower(author) || lower(title) || lower(bibtexkey) || lower(entrytype) || lower(publisher) LIKE @value";
                listvalues = _iConnection.Query<book>(query, new { value = '%' + filter + '%' }).ToList();
                return listvalues;
            }
            if (filter.Contains(".") && filter.Contains(".*"))
            {
                int index = filter.IndexOf(".*");
                filter = filter.Substring(0, index);
                query += " Where (year like @value) or (month like @value) or (CAST(volume as INTEGER) LIKE @value) or lower(author) || lower(title) || lower(bibtexkey) || lower(entrytype) || lower(publisher) LIKE @value";
                listvalues = _iConnection.Query<book>(query, new { value = '%' + filter + '%' }).ToList();
                return listvalues;
            }
            query += " Where (year like @value) or (month like @value) or (CAST(volume as INTEGER) LIKE @value) or lower(author) || lower(title) || lower(bibtexkey) || lower(entrytype) || lower(publisher) LIKE @value";
            listvalues = _iConnection.Query<book>(query, new { value = '%' + filter + '%' }).ToList();
            return listvalues;
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
            return _iConnection.Query<book>(
                 $"Select * from book where ID = {ID}").FirstOrDefault();
        }

       
    }
}
