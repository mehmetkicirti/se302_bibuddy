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
    public class DapperManualDal : IManualDal
    {

        private IDbConnection _iConnection;

        public DapperManualDal()
        {
            _iConnection = DapperDbContext.GetDbConnection();
        }

        public void Add(manual entity)
        {
            _iConnection.ExecuteScalar<manual>(
               "INSERT INTO manual (entrytype, bibtexkey, title, author, organization, address, edition, month, year, note) VALUES(@entrytype, @bibtexkey, @title, @author, @organization, @addressi ,@edition, @month, @year, @note)", new
               {
                   entity.entrytype,
                   entity.bibtexkey,
                   entity.title,
                   entity.author,
                   entity.organization,
                   entity.address,
                   entity.edition,
                   entity.month,
                   entity.year,
                   entity.note
               });
        }

        public int Count()
        {
            string query = @"SELECT COUNT(ID) FROM manual";
            int count = _iConnection.ExecuteScalar<int>(query);
            return count;
        }

        public void Delete(int ID)
        {
            string q = $"Delete from manual where ID = @ID";
            _iConnection.Execute(q,
                new
                {
                    ID
                });
        }

        public manual Get(string filter = null)
        {
            throw new NotImplementedException();
        }

        public List<manual> GetAll(string filter = null)
        {
            if (filter != null)
            {
                filter = filter.ToLower();
            }
            string query = "Select * from manual";
            List<manual> listvalues = _iConnection.Query<manual>(query).ToList();

            //if (String.IsNullOrEmpty(filter) || filter == "*")
            //{
                return listvalues;
            //}
        }

        public List<manual> GetAllByAuthorOrTitleIfNotExist(string author = null, string title = null)
        {
            string query = @"Select * from inbook";
            if (!String.IsNullOrEmpty(author) || !String.IsNullOrEmpty(title))
            {
                query += " Where ";
                if (!String.IsNullOrEmpty(author) && !String.IsNullOrEmpty(title))
                {
                    query += "author LIKE @value and title LIKE @value2";
                    return _iConnection.Query<manual>(query, new { value = "%" + author + "%", value2 = "%" + title + "%" }).ToList();
                }
                else if (!String.IsNullOrEmpty(author))
                {
                    query += "author LIKE @value";
                    return _iConnection.Query<manual>(query, new { value = "%" + author + "%" }).ToList();
                }
                else
                {
                    query += "title LIKE @value";
                    return _iConnection.Query<manual>(query, new { value = "%" + title + "%" }).ToList();
                }
            }
            else
            {
                return _iConnection.Query<manual>(query).ToList();
            }
        }

        public List<manual> GetAllByYear(int? year)
        {
            string query = @"Select * from manual";
            if (year.HasValue)
            {
                query += "Where year = @year";
            }
            return _iConnection.Query<manual>(query, new { year }).ToList();
        }

        public manual GetByID(int ID)
        {

            return _iConnection.Query<manual>(
                     $"Select * from manual where ID = {ID}").FirstOrDefault();
        }

        public void Update(manual entity)
        {
            _iConnection.ExecuteScalar<manual>(
              "UPDATE manual SET entrytype=@entrytype, bibtexkey=@bibtexkey, title=@title, author=@author, organization=@organization," +
              " address=@address, edition=@edition, month=@month, year=@year, note=@note where ID = @ID", new
              {
                  entity.entrytype,
                  entity.bibtexkey,
                  entity.title,
                  entity.author,
                  entity.organization,
                  entity.address,
                  entity.edition,
                  entity.month,
                  entity.year,
                  entity.note,
                  entity.ID
              });
        }
    }
}