using Bibuddy.DataAccess.Abstract;
using Bibuddy.DataAccess.DatabaseContext.Dapper;
using BiBuddy.Entities.Concrete;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;

namespace Bibuddy.DataAccess.Concrete.Dapper
{
    public class DapperArticleDal:IArticleDal
    {
        private IDbConnection _iConnection;
        public DapperArticleDal()
        {
            _iConnection = DapperDbContext.GetDbConnection();
        }

        public void Add(article entity)
        {
            _iConnection.ExecuteScalar<article>(
                "INSERT INTO article (author, doi, journal, month, note, number, pages, title, volume, year, address, bibtexkey,entrytype) VALUES( @author, @doi, @journal, @month, @note, @number, @pages, @title, @volume, @year, @bibtexkey, @entrytype)", new
                {
                    entity.doi,
                    entity.entrytype,
                    entity.author,
                    entity.journal,
                    entity.month,
                    entity.note,
                    entity.number,
                    entity.pages,
                    entity.title,
                    entity.volume,
                    entity.year,
                    entity.bibtexkey
                });
        }

        public int Count()
        {
            string query = @"SELECT COUNT(ID) FROM article";
            int count = _iConnection.ExecuteScalar<int>(query);
            return count;
        }

        public void Delete(int ID)
        {
            string q = $"Delete from article where ID = @ID";
            _iConnection.Execute(q,
                new
                {
                    ID
                });
        }

        public article Get(Expression<Func<article, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<article> GetAll(Expression<Func<article, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<article> GetAllByAuthorOrTitleIfNotExist(string author = null, string title = null)
        {
            string query = @"Select * from article";
            if (!String.IsNullOrEmpty(author) || !String.IsNullOrEmpty(title))
            {
                query += " Where ";
                if (!String.IsNullOrEmpty(author) && !String.IsNullOrEmpty(title))
                {
                    query += "author LIKE @value and title LIKE @value2";
                    return _iConnection.Query<article>(query, new { value = "%" + author + "%", value2 = "%" + title + "%" }).ToList();
                }
                else if (!String.IsNullOrEmpty(author))
                {
                    query += "author LIKE @value";
                    return _iConnection.Query<article>(query, new { value = "%" + author + "%" }).ToList();
                }
                else
                {
                    query += "title LIKE @value";
                    return _iConnection.Query<article>(query, new { value = "%" + title + "%" }).ToList();
                }
            }
            else
            {
                return _iConnection.Query<article>(query).ToList();
            }
        }

        public List<article> GetAllByYear(int? year)
        {
            string query = @"Select * from article";
            if (year.HasValue)
            {
                query += "Where year = @year";
            }
            return _iConnection.Query<article>(query, new { year }).ToList();
        }

        public article GetByID(int ID)
        {
            return _iConnection.Query<article>(
                $"Select * from article where ID = {ID}").FirstOrDefault();
        }

        public void Update(article entity)
        {
            _iConnection.ExecuteScalar<article>(
               "UPDATE article SET author=@author, doi=@doi, entrytype=@entrytype, bibtexkey=@bibtexkey journal=@journal, month=@month, note=@note, number=@number, pages=@pages, title=@title, volume=@volume, year=@year where ID = @ID", new
               {
                   entity.doi,
                   entity.entrytype,
                   entity.bibtexkey,
                   entity.author,
                   entity.journal,
                   entity.month,
                   entity.note,
                   entity.number,
                   entity.pages,
                   entity.title,
                   entity.volume,
                   entity.year,
                   entity.ID
               });
        }
    }
}
