using System;
using System.Collections.Generic;
using System.Text;

namespace Database
{
   public  class ResignationRepo
    {
        DatabaseHelper databaseHelper;
        public string Message { get => databaseHelper.ErrorMessage; }

        public ResignationRepo()
        {
            databaseHelper = new DatabaseHelper(DatabaseName.Resignation);
        }

        public bool InsertOrUpdate(ResignationDetailTable detailTable)
        {
            databaseHelper.InsertOrReplace(detailTable);
            return databaseHelper.Result;
        }

        public List<ResignationDetailTable> GetEmployee()
        {
            return databaseHelper.SQLConnection.Table<ResignationDetailTable>().ToList();
        }

        public ResignationDetailTable GetUser(int id)
        {
            try
            {
                return databaseHelper.SQLConnection.Table<ResignationDetailTable>().Where(c => c.employeeResignationId == id).FirstOrDefault();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }
    }
}
