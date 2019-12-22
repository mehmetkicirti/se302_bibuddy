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

        public booklet Get(string filter = null)
        {
            throw new NotImplementedException();
        }

        public List<booklet> GetAll(string filter = null)
        {
            if (filter != null)
            {
                filter = filter.ToLower();
            }
            string query = "Select * from booklet";
            List<booklet> listvalues = _iConnection.Query<booklet>(query).ToList();

            //if (String.IsNullOrEmpty(filter) || filter == "*")
            //{
                return listvalues;
            //}
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
