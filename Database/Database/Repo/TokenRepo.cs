using System;
using System.Collections.Generic;
using System.Text;

namespace Database
{
    public class TokenRepo
    {
        DatabaseHelper helper;

        public string Message { get => helper.ErrorMessage; }

        public TokenRepo()
        {
            helper = new DatabaseHelper(DatabaseName.Resignation);
        }

        public bool InsertOrUpdate(TokenTable tokenTable)
        {
            helper.InsertOrReplace(tokenTable);
            return helper.Result;
        }
    }
}
