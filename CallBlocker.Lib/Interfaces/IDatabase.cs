using CallBlocker.Lib.Interfaces.DadosNumeros;
using System;
using System.Collections.Generic;
using System.Text;

namespace CallBlocker.Lib.Interfaces
{
    public interface IDatabase
    {
        void Config();
        IWhiteList WhiteList { get; }
    }
}
