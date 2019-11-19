using System;
using System.Collections.Generic;
using System.Text;

namespace Database
{
    public static class DatabasePath
    {
        public static string Path;
    }

    public class DatabaseManager
    {
        DatabaseHelper _databaseHelper;

        public DatabaseManager()
        {

        }

        public DatabaseManager(string path)
        {
            SetDatabasePath(path);
        }

        public void SetUp()
        {
            DatabaseBuilder databseBuilder = new ResignationDatabase(_databaseHelper);
            databseBuilder.SetUp();
        }

        public void SetDatabasePath(string path)
        {
            DatabasePath.Path = path;
            _databaseHelper = new DatabaseHelper(DatabaseName.Resignation);
        }
    }
}
