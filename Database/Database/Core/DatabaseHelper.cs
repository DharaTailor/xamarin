using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Database
{
    public static class DatabaseName
    {
        public const string Resignation = "Resignation.db";
    }

    public class DatabaseHelper
    {
        SQLiteConnection _database;
        public string ErrorMessage { get; set; }
        public bool Result { get => _result == 1 ? true : false; }
        private int _result { get; set; }

        public SQLiteConnection SQLConnection { get => _database; }

        public DatabaseHelper(string name)
        {
            ConnectDatabase(name);
        }

        public void ConnectDatabase(string name)
        {
            var path = DatabasePath.Path + "/" + name;
            Console.WriteLine("DBPath --->" + path);
            _database = new SQLiteConnection(path);
        }

        public int CreateTable<T>() where T : new()
        {
            return (int)_database.CreateTable<T>();
        }

        public List<T> Query<T>(string query) where T : new()
        {
            try
            {
                var result = _database.Query<T>(query);
                return result;
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
                _result = 0;
                return null;
            }
        }

        public void InsertOrReplace<T>(T value)
        {
            try
            {
                _result = _database.InsertOrReplace(value);
            }
            catch (SQLiteException ex)
            {
                ErrorMessage = ex.Message;
                _result = 0;
            }
        }

        public int Delete<T>(T value)
        {
            try
            {
                _result = _database.Delete(value);
            }
            catch (SQLiteException ex)
            {
                ErrorMessage = ex.Message;
                _result = 0;
            }
            return _result;
        }

    }

}
