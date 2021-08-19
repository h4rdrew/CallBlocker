using CallBlocker.Lib.Interfaces;
using CallBlocker.Lib.Interfaces.DadosNumeros;
using Simple.Sqlite;
using System.IO;

namespace CallBlocker.DA.Database
{
    public class Database : IDatabase
    {
        private readonly string dbPath;
        private SqliteDB db;
        public Database(string dbPath)
        {
            var fileInfo = new FileInfo(dbPath);
            if (!fileInfo.Directory.Exists) fileInfo.Directory.Create();
            this.dbPath = dbPath;
        }

        public IWhiteList WhiteList { get; private set; }

        public void Config()
        {
            db = new SqliteDB(dbPath);
            WhiteList = new DadosNumeros.WhiteList(db);
        }
    }
}
