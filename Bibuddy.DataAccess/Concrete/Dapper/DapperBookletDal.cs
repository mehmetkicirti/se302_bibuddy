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
    public class DapperBookletDal : IBookletDal
    {

        private IDbConnection _iConnection;

        public DapperBookletDal()
        {
            _iConnection = DapperDbContext.GetDbConnection();
        }

        public void Add(booklet entity)
        {
            _iConnection.ExecuteScalar<booklet>(
                "INSERT INTO booklet (author, month, note, title, howpublished, " +
                "year, address, bibtexkey, entrytype) VALUES( @author, @month, @note," +
                " @title, @howpublished, @year, @address, @bibtexkey, @entrytype)", new
                {
                    entity.title,
                    entity.author,
                    entity.howpublished,
                    entity.address,
                    entity.month,
                    entity.note,
                    entity.year,
                    entity.bibtexkey,
                    entity.entrytype
                });
        }
    


        public int Count()
        {
            string query = @"SELECT COUNT(ID) FROM booklet";
            int count = _iConnection.ExecuteScalar<int>(query);
            return count;
        }

        public void Delete(int ID)
        {
            string q = $"Delete from booklet where ID = @ID";
            _iConnection.Execute(q,
                new
                {
                    ID
                });
        }

        public List<booklet> GetAll(string filter = null)
        {
            List<booklet> listvalues;
            string query = "Select * from booklet";
            if (filter != null)
            {
                filter = filter.ToLower();
            }
            if (String.IsNullOrEmpty(filter) || filter == "*")
            {
                listvalues = _iConnection.Query<booklet>(query).ToList();
                return listvalues;
            }

            if (filter.StartsWith("K. Oğuz") || filter.StartsWith("K. Oguz") || filter.StartsWith("K. oğuz") || filter.StartsWith("K. oguz") || filter.StartsWith("k. oguz") || filter.StartsWith("k. oğuz"))
            {
                filter = "Kaya Oğuz".ToLower();
                query += " Where (year like @value) or (month like @value) or lower(author) || lower(title) || lower(bibtexkey) || lower(entrytype) || lower(howpublished)  LIKE @value";
                listvalues = _iConnection.Query<booklet>(query, new { value = '%' + filter + '%' }).ToList();
                return listvalues;
            }
            if (filter.Contains(".") && filter.Contains(".*"))
            {
                int index = filter.IndexOf(".*");
                filter = filter.Substring(0, index);
                query += " Where (year like @value) or (month like @value) or lower(author) || lower(title) || lower(bibtexkey) || lower(entrytype) || lower(howpublished)  LIKE @value";
                listvalues = _iConnection.Query<booklet>(query, new { value = '%' + filter + '%' }).ToList();
                return listvalues;
            }
            query += " Where (year like @value) or (month like @value) or lower(author) || lower(title) || lower(bibtexkey) || lower(entrytype) || lower(howpublished)  LIKE @value";
            listvalues = _iConnection.Query<booklet>(query, new { value = '%' + filter + '%' }).ToList();
            return listvalues;
        }

        public List<booklet> GetAllByAuthorOrTitleIfNotExist(string author = null, string title = null)
        {
            string query = @"Select * from booklet";
            if (!String.IsNullOrEmpty(author) || !String.IsNullOrEmpty(title))
            {
                query += " Where ";
                if (!String.IsNullOrEmpty(author) && !String.IsNullOrEmpty(title))
                {
                    query += "author LIKE @value and title LIKE @value2";
                    return _iConnection.Query<booklet>(query, new { value = "%" + author + "%", value2 = "%" + title + "%" }).ToList();
                }
                else if (!String.IsNullOrEmpty(author))
                {
                    query += "author LIKE @value";
                    return _iConnection.Query<booklet>(query, new { value = "%" + author + "%" }).ToList();
                }
                else
                {
                    query += "title LIKE @value";
                    return _iConnection.Query<booklet>(query, new { value = "%" + title + "%" }).ToList();
                }
            }
            else
            {
                return _iConnection.Query<booklet>(query).ToList();
            }
        }

        public List<booklet> GetAllByYear(int? year)
        {
            string query = @"Select * from booklet";
            if (year.HasValue)
            {
                query += "Where year = @year";
            }
            return _iConnection.Query<booklet>(query, new { year }).ToList();
        }

        public booklet GetByID(int ID)
        {
            return _iConnection.Query<booklet>(
                $"Select * from booklet where ID = {ID}").FirstOrDefault();
        }

        public void Update(booklet entity)
        {
            _iConnection.ExecuteScalar<booklet>(
              "UPDATE booklet SET author=@author, entrytype=@entrytype, bibtexkey=@bibtexkey, month=@month, " +
              "note=@note, title=@title, year=@year, howpublished=@howpublished, address=@address where ID = @ID", new
              {
                  entity.title,
                  entity.author,
                  entity.howpublished,
                  entity.address,
                  entity.month,
                  entity.note,
                  entity.year,
                  entity.bibtexkey,
                  entity.entrytype
              });
        }
    }
}
