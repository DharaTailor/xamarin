using System;
using System.Collections.Generic;
using System.Text;

namespace Database
{
    public class ResignationDatabase : DatabaseBuilder
    {
        DatabaseHelper _databaseHelper;
        public ResignationDatabase(DatabaseHelper databaseHelper)
        {
            _databaseHelper = databaseHelper;
        }
        public override void SetUp()
        {
            _databaseHelper.ConnectDatabase(DatabaseName.Resignation);
            _databaseHelper.CreateTable<ResignationDetailTable>();
        }
    }
}
