using System;
using System.Collections.Generic;
using System.Text;

namespace CallBlocker.Lib.Interfaces.DadosNumeros
{
    public interface IWhiteList
    {
        void AddNumber_WhiteList(string number, string name);
    }
}
