using Simple.Brazilian.Formatters;
using System.Threading.Tasks;

namespace CallBlocker.Droid
{
    public class NumberManager
    {
        public static async Task<bool> NumeroPresenteWhiteListAsync(string incomingNumber)
        {
            var numbersWhiteList = await App.Database.GetNumberAsync();

            incomingNumber = Text.RemoveMask(incomingNumber);

            for (int i = 0; i < numbersWhiteList.Count; i++)
            {
                if (numeroEhIgual(incomingNumber, Text.RemoveMask(numbersWhiteList[i].Number)))
                    return true;
            }

            return false;
        }

        private static bool numeroEhIgual(string incomingNumber, string lista)
        {
            // Igualzin
            if (incomingNumber == lista) return true;
            // incoming TEM +55DDD e o lista não
            if (incomingNumber.EndsWith(lista)) return true;
            // lista TEM +55DDD e o incoming não
            if (lista.EndsWith(incomingNumber)) return true;

            // desformata
            return false;
        }
    }
}