using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bibuddy.DataAccess.DatabaseContext.Dapper
{
    public class DapperDbContext
    {
        private static IDbConnection _dbConnection;
        private static string relativePath = @"BiBuddyDB.db";
        private static string con = Path.GetFullPath("se302_bibuddy");
        private static string[] path = con.Split(new string[] { "bin" }, StringSplitOptions.None);
        private static string fullPath = String.Format(@"Data Source={0}BiBuddyDB.db", path[0]);
        private static string oldDbFile = Path.Combine(path[0], relativePath);
        private static string currentPath = Directory.GetCurrentDirectory();
        private static string absolutePath = System.IO.Path.Combine(currentPath, relativePath);
        private static string fileNotExist = absolutePath;
        private static string connectionString = string.Format("Data Source={0}", absolutePath);
        public DapperDbContext()
        {
            #region Unneccessary
            //if (!File.Exists(fullPath))
            //{

            //    using (var con = new SQLiteConnection(connectionString))
            //    {
            //        con.Open();
            //        using (var cmd = new SQLiteCommand(con))
            //        {
            //            cmd.CommandText= @"CREATE TABLE article(
            //            ID INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT UNIQUE,
            //         author TEXT,
            //         title TEXT,
            //         journal TEXT,
            //         year INTEGER,
            //         number INTEGER,
            //         volume INTEGER,
            //         pages TEXT,
            //         note  TEXT,
            //         month INTEGER,
            //            bibtexKey TEXT,
            //            address TEXT
            //            )";
            //            cmd.ExecuteNonQuery();

            //            cmd.CommandText = @"CREATE TABLE book(
            //            ID INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT UNIQUE,
            //         author TEXT,
            //         title TEXT,
            //         journal TEXT,
            //         year INTEGER,
            //         volume INTEGER,
            //            series INTEGER,
            //         note  TEXT,
            //         edition INTEGER,
            //            month INTEGER,
            //            isbn TEXT,
            //            bibtexKey TEXT,
            //            address TEXT
            //            )";
            //            cmd.ExecuteNonQuery();

            //            cmd.CommandText = @"CREATE TABLE booklet(
            //            ID INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT UNIQUE,
            //         author TEXT NOT NULL,
            //         title TEXT NOT NULL,
            //            howpublished TEXT,
            //         year INTEGER,
            //         note  TEXT,
            //         month INTEGER,
            //            bibtexKey TEXT,
            //            address TEXT
            //            )";
            //            cmd.ExecuteNonQuery();

            //            cmd.CommandText = @"CREATE TABLE conference(
            //            ID INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT UNIQUE,
            //         author TEXT NOT NULL,
            //         title TEXT NOT NULL,
            //         booktitle TEXT NOT NULL,
            //         year INTEGER,
            //            editor TEXT,
            //         volume INTEGER,
            //            series INTEGER,
            //         pages TEXT,
            //         note  TEXT,
            //         month INTEGER,
            //            address TEXT,
            //            organization TEXT,
            //            publisher TEXT,
            //            bibtexKey TEXT
            //            )";
            //            cmd.ExecuteNonQuery();

            //            cmd.CommandText = @"CREATE TABLE inbook(
            //            ID INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT UNIQUE,
            //         author TEXT NOT NULL,
            //         title TEXT NOT NULL,
            //            chapter INTEGER NOT NULL,
            //            booktitle TEXT NOT NULL,
            //         year INTEGER,
            //         editor TEXT,
            //         edition TEXT,
            //            series INTEGER,
            //         volume INTEGER,
            //            address TEXT,
            //         pages TEXT,
            //         note  TEXT,
            //         month INTEGER,
            //            bibtexKey TEXT,
            //            series INTEGER,
            //            publisher TEXT
            //            )";
            //            cmd.ExecuteNonQuery();

            //            cmd.CommandText = @"CREATE TABLE incollection(
            //            ID INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT UNIQUE,
            //         author TEXT NOT NULL,
            //         title TEXT NOT NULL,
            //         journal TEXT,
            //         year INTEGER,
            //         number INTEGER,
            //         volume INTEGER,
            //         pages TEXT,
            //         note  TEXT,
            //         month INTEGER,
            //            bibtexKey TEXT,
            //            chapter INTEGER,
            //            address TEXT
            //            )";
            //            cmd.ExecuteNonQuery();

            //            cmd.CommandText = @"CREATE TABLE manual(
            //            ID INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT UNIQUE,
            //         author TEXT,
            //         title TEXT,
            //         year INTEGER,
            //         note  TEXT,
            //         month INTEGER,
            //            organization TEXT,
            //            edition INTEGER,
            //            bibtexKey TEXT,
            //            address TEXT
            //            )";
            //            cmd.ExecuteNonQuery();
            //        }

            //        con.Close();
            //    }

            //} 
            #endregion
            _dbConnection = new SQLiteConnection(fullPath);
        }
        public static IDbConnection GetDbConnection()
        {
            if (_dbConnection == null)
            {
                if (File.Exists(oldDbFile))
                {
                    _dbConnection = new SQLiteConnection(fullPath);
                    return _dbConnection;
                }
                else if (File.Exists(fileNotExist))
                {
                    _dbConnection = new SQLiteConnection(connectionString);
                    return _dbConnection;
                }
                else
                {
                    CreateNewDbFile(fileNotExist);
                    _dbConnection = new SQLiteConnection(connectionString);
                    return _dbConnection;
                }
            }
            return _dbConnection;
        }
        private static void CreateNewDbFile(string folder)
        {
            FileStream fs = File.Create(folder);
            fs.Close();
            using (var con = new SQLiteConnection(connectionString))
            {
                con.Open();
                using (var cmd = new SQLiteCommand(con))
                {
                    cmd.CommandText = @"CREATE TABLE article(
                        ID INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT UNIQUE,
	                    author TEXT,
	                    title TEXT,
	                    journal TEXT,
	                    year INTEGER,
	                    number INTEGER,
	                    volume INTEGER,
	                    pages TEXT,
	                    note  TEXT,
	                    month INTEGER,
                        bibtexKey TEXT,
                        entrytype TEXT,
                        doi TEXT
                        )";
                    cmd.ExecuteNonQuery();

                    cmd.CommandText = @"CREATE TABLE book(
                        ID INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT UNIQUE,
	                    author TEXT,
	                    title TEXT,
	                    publisher TEXT,
	                    year INTEGER,
	                    volume INTEGER,
                        series INTEGER,
	                    note  TEXT,
	                    edition INTEGER,
                        month INTEGER,
                        url TEXT,
                        bibtexKey TEXT,
                        entrytype TEXT,
                        address TEXT
                        )";
                    cmd.ExecuteNonQuery();

                    cmd.CommandText = @"CREATE TABLE booklet(
                        ID INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT UNIQUE,
	                    author TEXT,
	                    title TEXT,
                        howpublished TEXT,
	                    year INTEGER,
	                    note  TEXT,
	                    month INTEGER,
                        bibtexKey TEXT,
                        address TEXT,
                        entrytype TEXT
                        )";
                    cmd.ExecuteNonQuery();

                    cmd.CommandText = @"CREATE TABLE conference(
                        ID INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT UNIQUE,
	                    author TEXT,
	                    title TEXT,
	                    booktitle TEXT,
	                    year INTEGER,
                        editor TEXT,
	                    volume INTEGER,
                        series INTEGER,
	                    pages TEXT,
	                    note  TEXT,
	                    month INTEGER,
                        address TEXT,
                        organization TEXT,
                        publisher TEXT,
                        bibtexKey TEXT,
                        entrytype TEXT
                        )";
                    cmd.ExecuteNonQuery();

                    cmd.CommandText = @"CREATE TABLE inbook(
                        ID INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT UNIQUE,
	                    author TEXT,
	                    title TEXT,
                        chapter INTEGER,
	                    year INTEGER,
	                    type TEXT,
	                    edition TEXT,
	                    volume INTEGER,
                        address TEXT,
	                    pages TEXT,
	                    note  TEXT,
	                    month INTEGER,
                        bibtexKey TEXT,
                        series INTEGER,
                        publisher TEXT NOT NULL,
                        entrytype TEXT
                        )";
                    cmd.ExecuteNonQuery();

                    cmd.CommandText = @"CREATE TABLE incollection(
                        ID INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT UNIQUE,
	                    author TEXT,
	                    title TEXT,
                        booktitle TEXT,
                        publisher TEXT,
	                    year INTEGER,
                        editor TEXT,
                        series INTEGER,
	                    edition INTEGER,
	                    volume INTEGER,
	                    pages TEXT,
	                    note  TEXT,
	                    month INTEGER,
                        bibtexKey TEXT,
                        chapter INTEGER,
                        address TEXT,
                        entrytype TEXT,
                        type TEXT
                        )";
                    cmd.ExecuteNonQuery();

                    cmd.CommandText = @"CREATE TABLE manual(
                        ID INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT UNIQUE,
	                    author TEXT,
	                    title TEXT ,
	                    year INTEGER,
	                    note  TEXT,
	                    month INTEGER,
                        organization TEXT,
                        edition INTEGER,
                        bibtexKey TEXT,
                        address TEXT,
                        entrytype TEXT
                        )";
                    cmd.ExecuteNonQuery();
                }

                con.Close();
            }
        }
    }
    
}
