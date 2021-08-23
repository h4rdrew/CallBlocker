using CallBlocker.Lib.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CallBlocker
{
    public class Teste
    {
        private readonly IDatabase _db;

        public Teste(IDatabase db)
        {
            _db = db;
        }
        public void TesteWhite(string numero)
        {
            _db.WhiteList.AddNumber_WhiteList(numero);
        }
    }
}
