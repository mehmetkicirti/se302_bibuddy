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
    public class DapperArticleDal : IArticleDal
    {
        private IDbConnection _iConnection;

        public DapperArticleDal()
        {
            _iConnection = DapperDbContext.GetDbConnection();
        }

        public void Add(article entity)
        {
            _iConnection.ExecuteScalar<article>(
                "INSERT INTO article (author, doi, journal, month, note, number, pages, title, volume, year," +
                " bibtexkey,entrytype) VALUES( @author, @doi, @journal, @month, @note, @number, @pages, @title," +
                " @volume, @year, @bibtexkey, @entrytype)", new
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

        public void AddByImport(article entity)
        {
            _iConnection.ExecuteScalar<article>(
               "INSERT INTO article (author, doi, journal, month, note, number, pages, title, volume, year," +
               " bibtexkey,entrytype) VALUES( @author, @doi, @journal, @month, @note, @number, @pages, @title," +
               " @volume, @year, @bibtexkey, @entrytype)", new
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

        public List<article> GetAll(string filter = null)
        {
            if (filter != null)
            {
                filter = filter.ToLower();
            }
            string query = "Select * from article";
            List<article> listvalues = _iConnection.Query<article>(query).ToList();

            if (String.IsNullOrEmpty(filter) || filter=="*")
            {
                 return listvalues;
            }
            if (filter.StartsWith("K. Oğuz") || filter.StartsWith("K. Oguz") || filter.StartsWith("K. oğuz") || filter.StartsWith("K. oguz") || filter.StartsWith("k. oguz"))
            {
                filter = "Kaya Oğuz".ToLower();
                return listvalues.Where(x => x.author.ToLower().Contains(filter)).ToList();
            }
            if (filter.Contains(".") && filter.Contains(".*"))
            {
                int index = filter.IndexOf(".*");
                filter = filter.Substring(0, index);
                return listvalues.Where(
                    x => x.author.ToLower().Contains(filter)
                   || x.bibtexkey.ToLower().Contains(filter)
                   || x.entrytype.ToLower().Contains(filter)
                   || x.year.Value.ToString().Contains(filter)
                   || x.journal.ToLower().Contains(filter)
                   || x.title.ToLower().Contains(filter)).ToList();
            }
            return listvalues.Where(
                    x => x.author.ToLower().Contains(filter) 
                    || x.bibtexkey.ToLower().Contains(filter)
                    || x.doi.ToLower().Contains(filter)
                    || x.entrytype.ToLower().Contains(filter)
                    || x.journal.ToLower().Contains(filter)
                    || x.month.Value.Equals(Convert.ToInt32(filter))
                    || x.year.Value.Equals(Convert.ToInt32(filter))
                    ).ToList();
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
               "UPDATE article SET author=@author, doi=@doi, entrytype=@entrytype, bibtexkey=@bibtexkey," +
               " journal=@journal, month=@month, note=@note, number=@number, pages=@pages, " +
               "title=@title, volume=@volume, year=@year where ID = @ID", new
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
