using System;
using System.Collections.Generic;
using System.Text;
using CallBlocker.Lib.Interfaces.DadosNumeros;
using Simple.Sqlite;
using CallBlocker.DA.Models.DadosNumeros;

namespace CallBlocker.DA.Database.DadosNumeros
{
    public class WhiteList : IWhiteList
    {
        SqliteDB DB;
        public WhiteList(SqliteDB DB)
        {
            this.DB = DB;
            DB.CreateTables().Add<WhiteList_Model_DA>().Commit();
        }
        public void AddNumber_WhiteList(string number)
        {
            throw new NotImplementedException();
        }
    }
}
