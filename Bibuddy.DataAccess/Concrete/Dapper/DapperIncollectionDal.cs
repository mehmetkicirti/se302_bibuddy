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
    public class DapperIncollectionDal : IIncollectionDal
    {

        private IDbConnection _iConnection;

        public DapperIncollectionDal()
        {
            _iConnection = DapperDbContext.GetDbConnection();
        }

        public void Add(incollection entity)
        {
            _iConnection.ExecuteScalar<incollection>(
               "INSERT INTO incollection (chapter, author, month, note, title, volume, year, address, type," +
               " bibtexkey, entrytype ,publisher, series, edition, booktitle, editor, pages) VALUES( @chapter, @author, @month, @note, @title," +
               " @volume, @year, @address, @type, @bibtexkey, @entrytype, @publisher, @series, @edition, @booktitle, @editor, @pages)", new
               {
                   entity.entrytype,
                   entity.bibtexkey,
                   entity.author,
                   entity.address,
                   entity.chapter,
                   entity.publisher,
                   entity.series,
                   entity.type,
                   entity.title,
                   entity.month,
                   entity.note,
                   entity.volume,
                   entity.edition,
                   entity.year,
                   entity.ID,
                   entity.booktitle,
                   entity.editor,
                   entity.pages,
               });
        }

        public int Count()
        {
            string query = @"SELECT COUNT(ID) FROM incollection";
            int count = _iConnection.ExecuteScalar<int>(query);
            return count;
        }

        public void Delete(int ID)
        {
            string q = $"Delete from incollection where ID = @ID";
            _iConnection.Execute(q,
                new
                {
                    ID
                });
        }

        public List<incollection> GetAll(string filter = null)
        {
            if (filter != null)
            {
                filter = filter.ToLower();
            }
            string query = "Select * from incollection";
            List<incollection> listvalues = _iConnection.Query<incollection>(query).ToList();

            //if (String.IsNullOrEmpty(filter) || filter == "*")
            //{
                return listvalues;
            //}
        }

        public List<incollection> GetAllByAuthorOrTitleIfNotExist(string author = null, string title = null)
        {
            string query = @"Select * from inbook";
            if (!String.IsNullOrEmpty(author) || !String.IsNullOrEmpty(title))
            {
                query += " Where ";
                if (!String.IsNullOrEmpty(author) && !String.IsNullOrEmpty(title))
                {
                    query += "author LIKE @value and title LIKE @value2";
                    return _iConnection.Query<incollection>(query, new { value = "%" + author + "%", value2 = "%" + title + "%" }).ToList();
                }
                else if (!String.IsNullOrEmpty(author))
                {
                    query += "author LIKE @value";
                    return _iConnection.Query<incollection>(query, new { value = "%" + author + "%" }).ToList();
                }
                else
                {
                    query += "title LIKE @value";
                    return _iConnection.Query<incollection>(query, new { value = "%" + title + "%" }).ToList();
                }
            }
            else
            {
                return _iConnection.Query<incollection>(query).ToList();
            }
        }

        public List<incollection> GetAllByYear(int? year)
        {
            string query = @"Select * from incollection";
            if (year.HasValue)
            {
                query += "Where year = @year";
            }
            return _iConnection.Query<incollection>(query, new { year }).ToList();
        }

        public incollection GetByID(int ID)
        {
            return _iConnection.Query<incollection>(
               $"Select * from incollection where ID = {ID}").FirstOrDefault();
        }

        public void Update(incollection entity)
        {
            _iConnection.ExecuteScalar<incollection>(
                "UPDATE incollection SET author=@author, entrytype=@entrytype, bibtexkey=@bibtexkey, booktitle=@booktitle, " +
                " month=@month, note=@note, chapter@chapter, pages=@pages, publisher=@publisher, series=@series, type=@type, " +
                "title=@title, editor=@editor, address=@address, edition=@edition, volume=@volume, year=@year where ID = @ID", new
                {
                    entity.entrytype,
                    entity.bibtexkey,
                    entity.author,
                    entity.address,
                    entity.chapter,
                    entity.publisher,
                    entity.series,
                    entity.type,
                    entity.title,
                    entity.month,
                    entity.note,
                    entity.volume,
                    entity.edition,
                    entity.year,
                    entity.ID,
                    entity.booktitle,
                    entity.editor,
                    entity.pages,
            
                });
        }
    }
}
